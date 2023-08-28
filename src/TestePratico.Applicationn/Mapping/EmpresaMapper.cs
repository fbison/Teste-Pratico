
using AutoMapper;
using System;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Models;

namespace TestePratico.Application.Mapping
{
    public class EmpresaMapper : Profile
    {
        /// <summary>
        /// Mapeamento De transações
        /// </summary>
        public EmpresaMapper()
        {

            CreateMap<Empresa, CriarEmpresaRequest>()
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ReverseMap()
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Empresa, EditarEmpresaRequest>()
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ReverseMap()
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));



            CreateMap<Empresa, ObterEmpresaResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

        }

    }

}