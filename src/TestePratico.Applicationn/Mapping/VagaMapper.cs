
using AutoMapper;
using System;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Models;

namespace TestePratico.Application.Mapping
{
    public class VagaMapper : Profile
    {
        /// <summary>
        /// Mapeamento De transações
        /// </summary>
        public VagaMapper()
        {

            CreateMap<Vaga, CriarVagaRequest>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa))
            .ReverseMap()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa));

            CreateMap<Vaga, EditarVagaRequest>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa))
            .ReverseMap()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa));



            CreateMap<Vaga, ObterVagaResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salario))
            .ForMember(dest => dest.FkIdEmpresa, opt => opt.MapFrom(src => src.FkIdEmpresa));

        }

    }

}