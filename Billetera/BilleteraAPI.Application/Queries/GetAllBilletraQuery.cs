﻿using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;
using BilleteraAPI.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Application.Queries
{
    public record GetAllBilleteraQuery() : IRequest<IEnumerable<BilleteraDto>>;

    public class GetAllBilleteraQueryHandler : IRequestHandler<GetAllBilleteraQuery, IEnumerable<BilleteraDto>>
    {
        private readonly IBilleteraRepository _billeteraRepository;
        private readonly IMapper _mapper;

        public GetAllBilleteraQueryHandler(
            IBilleteraRepository billeteraRepository,
            IMapper mapper)
        {
            _billeteraRepository = billeteraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BilleteraDto>> Handle(GetAllBilleteraQuery request, CancellationToken cancellationToken)
        {
            var billeteras = await _billeteraRepository.GetBilleterasAsync();
            return _mapper.Map<IEnumerable<BilleteraDto>>(billeteras);
        }
    }
}
