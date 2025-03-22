using AutoMapper;
using BilleteraAPI.Application.Constantes;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Exceptions;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BilleteraAPI.Application.Commands
{
    public record UpdateBilleteraCommand(int idBilletera, BilleteraDto Billetera) : IRequest<BilleteraEntity>;

    public class UpdateBilleteraCommandHandler : IRequestHandler<UpdateBilleteraCommand, BilleteraEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<BilleteraDto> _validator;


        public UpdateBilleteraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<BilleteraDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BilleteraEntity> Handle(UpdateBilleteraCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Billetera, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var billeteraEntity = _mapper.Map<BilleteraEntity>(request.Billetera);
            billeteraEntity.UpdatedAt = DateTime.UtcNow;

            var billetera = await _unitOfWork.Billeteras.GetBilleteraByIdAsync(request.Billetera.Id);
            if (billetera is null)
            {
                throw new ExcepcionNegocio(ErroresNegocio.Billetera.MensajeNoEncontrada, ErroresNegocio.Billetera.CodigoNoEncontrada);
            }

            var result = await _unitOfWork.Billeteras.UpdateBilleteraAsync(request.idBilletera, billeteraEntity);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }

}
