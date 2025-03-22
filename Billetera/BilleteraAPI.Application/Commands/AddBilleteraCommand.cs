using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BilleteraAPI.Application.Commands
{
    public record AddBilleteraCommand(BilleteraDto Billetera) : IRequest<BilleteraEntity>;

    public class AddBilleteraCommandHandler : IRequestHandler<AddBilleteraCommand, BilleteraEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<BilleteraDto> _validator;


        public AddBilleteraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<BilleteraDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BilleteraEntity> Handle(AddBilleteraCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Billetera, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var billeteraEntity = _mapper.Map<BilleteraEntity>(request.Billetera);

            billeteraEntity.CreatedAt = DateTime.UtcNow;
            billeteraEntity.UpdatedAt = DateTime.UtcNow;
            var result = await _unitOfWork.Billeteras.AddBilleteraAsync(billeteraEntity);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
