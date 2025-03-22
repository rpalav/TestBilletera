using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BilleteraAPI.Application.Commands
{
    public record UpdateBilleteraCommand(int idBilletera, BilleteraDto Billetera) : IRequest<BilleteraEntity>;

    public class UpdateBilleteraCommandHandler : IRequestHandler<UpdateBilleteraCommand, BilleteraEntity>
    {
        private readonly IBilleteraRepository _billeteraRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BilleteraDto> _validator;


        public UpdateBilleteraCommandHandler(
            IBilleteraRepository billeteraRepository,
            IMapper mapper,
            IValidator<BilleteraDto> validator)
        {
            _billeteraRepository = billeteraRepository;
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

            return await _billeteraRepository.UpdateBilleteraAsync(request.idBilletera, billeteraEntity);
        }
    }

}
