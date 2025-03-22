using BilleteraAPI.Application.Constantes;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Exceptions;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Enums;
using BilleteraAPI.Domain.Interfaces;
using MediatR;

namespace BilleteraAPI.Application.Commands
{
    public class TransferenciaBilleteraCommand
    {
        public record TransferirBilleteraCommand(TransferenciaDto Transferencia) : IRequest<Unit>;
        public class TransferirBilleteraCommandHandler : IRequestHandler<TransferirBilleteraCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;


            public TransferirBilleteraCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(TransferirBilleteraCommand request, CancellationToken cancellationToken)
            {
                var billeteraOrigen = await _unitOfWork.Billeteras.GetBilleteraByIdAsync(request.Transferencia.OrigenBilleteraId);
                if (billeteraOrigen == null)
                {
                    throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeNoEncontrada, ErroresNegocio.Billetera.CodigoNoEncontrada);
                }

                var billeteraDestino = await _unitOfWork.Billeteras.GetBilleteraByIdAsync(request.Transferencia.DestinoBilleteraId);
                if (billeteraDestino == null)
                {
                    throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeNoEncontrada, ErroresNegocio.Billetera.CodigoSaldoInsuficiente);
                }
                if (billeteraOrigen.Balance < request.Transferencia.Amount)
                {
                    throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeSaldoInsuficiente, ErroresNegocio.Billetera.CodigoSaldoInsuficiente);
                }

                if (request.Transferencia.OrigenBilleteraId == request.Transferencia.DestinoBilleteraId)
                {
                    throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeTransferenciaMismaBilletera, ErroresNegocio.Billetera.CodigoTransferenciaMismaBilletera);
                }

                billeteraOrigen.Balance -= request.Transferencia.Amount;
                billeteraDestino.Balance += request.Transferencia.Amount;

                var movimientoDebito = new HistorialMovimientoEntity
                {
                    WalletId = billeteraOrigen.Id,
                    Amount = request.Transferencia.Amount,
                    Type = TipoMovimiento.Debito,
                    CreatedAt = DateTime.UtcNow
                };

                var movimientoCredito = new HistorialMovimientoEntity
                {
                    WalletId = billeteraDestino.Id,
                    Amount = request.Transferencia.Amount,
                    Type = TipoMovimiento.Credito,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.HistorialMovimientos.AddAsync(movimientoDebito);
                await _unitOfWork.HistorialMovimientos.AddAsync(movimientoCredito);

                await _unitOfWork.Billeteras.UpdateBilleteraAsync(request.Transferencia.OrigenBilleteraId, billeteraOrigen);
                await _unitOfWork.Billeteras.UpdateBilleteraAsync(request.Transferencia.DestinoBilleteraId, billeteraDestino);

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }
        }
    }
}
