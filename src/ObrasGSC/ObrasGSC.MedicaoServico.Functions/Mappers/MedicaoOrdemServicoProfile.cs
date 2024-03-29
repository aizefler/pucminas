﻿using AutoMapper;
using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Functions.Dtos;

namespace AHS.Freshservice.Application.Mappers
{
    public class MedicaoOrdemServicoProfile : Profile
    {
        public MedicaoOrdemServicoProfile()
        {
            CreateMap<MedicaoOrdemServicoPagamento, MedicaoPagamentoDto>()
                .ForMember(d => d.Situacao, o => o.MapFrom(s => s.Situacao.ToString()))
                .ForMember(d => d.FornecedorNome, o => o.MapFrom(s => s.Fornecedor.Descricao))
                .ForMember(d => d.FornecedorCNPJ, o => o.MapFrom(s => s.Fornecedor.CNPJ));

            CreateMap<Obra, ObrasDto>();
        }
    }
}
