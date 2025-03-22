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
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBilleteraCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBilleteraCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Billeteras.DeleteBilleteraAsync(request.idBilletera);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
