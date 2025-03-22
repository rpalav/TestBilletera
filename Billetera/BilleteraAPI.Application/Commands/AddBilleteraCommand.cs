using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Application.Commands
{
    public record AddBilleteraCommand(BilleteraEntity Billetera): IRequest<BilleteraEntity>;

    public class AddBilleteraCommandHandler(IBilleteraRepository billeteraRepository)
        : IRequestHandler<AddBilleteraCommand, BilleteraEntity>
    {
        public async Task<BilleteraEntity> Handle(AddBilleteraCommand request, CancellationToken cancellationToken)
        {
            return await billeteraRepository.AddBilleteraAsync(request.Billetera)
        }
    }
}
