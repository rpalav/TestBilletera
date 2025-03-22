using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BilleteraAPI.Application.Commands
{
    public record DeleteBilleteraCommand(int idBilletera) : IRequest<bool>;

    public class DeleteBilleteraCommandHandler : IRequestHandler<DeleteBilleteraCommand, bool>
    {
        private readonly IBilleteraRepository _billeteraRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BilleteraDto> _validator;


        public DeleteBilleteraCommandHandler(
            IBilleteraRepository billeteraRepository,
            IMapper mapper,
            IValidator<BilleteraDto> validator)
        {
            _billeteraRepository = billeteraRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteBilleteraCommand request, CancellationToken cancellationToken)
        {         
            return await _billeteraRepository.DeleteBilleteraAsync(request.idBilletera);
        }
    }
}
