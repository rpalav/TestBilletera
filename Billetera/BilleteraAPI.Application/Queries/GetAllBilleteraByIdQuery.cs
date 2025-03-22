using AutoMapper;
using BilleteraAPI.Application.Constantes;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Exceptions;
using BilleteraAPI.Domain.Interfaces;
using MediatR;

namespace BilleteraAPI.Application.Queries
{
    public record GetAllBilleteraByIdQuery(int idBilletera) : IRequest<BilleteraDto>;

    public class GetAllBilleteraByIdQueryHandler : IRequestHandler<GetAllBilleteraByIdQuery, BilleteraDto>
    {
        private readonly IBilleteraRepository _billeteraRepository;
        private readonly IMapper _mapper;

        public GetAllBilleteraByIdQueryHandler(
            IBilleteraRepository billeteraRepository,
            IMapper mapper)
        {
            _billeteraRepository = billeteraRepository;
            _mapper = mapper;
        }

        public async Task<BilleteraDto> Handle(GetAllBilleteraByIdQuery request, CancellationToken cancellationToken)
        {
            var billetera = await _billeteraRepository.GetBilleteraByIdAsync(request.idBilletera);
            if (billetera is null)
            {
                throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeNoEncontrada, ErroresNegocio.Billetera.CodigoNoEncontrada);
            }

            var billeteras = await _billeteraRepository.GetBilleteraByIdAsync(request.idBilletera);
            return _mapper.Map<BilleteraDto>(billeteras);
        }
    }
}
