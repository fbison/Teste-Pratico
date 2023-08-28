
using AutoMapper;
using System;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Models;

namespace TestePratico.Application.Mapping
{
    public class CandidaturaMapper : Profile
    {
        /// <summary>
        /// Mapeamento De transações
        /// </summary>
        public CandidaturaMapper()
        {

            CreateMap<Candidatura, CriarCandidaturaRequest>()
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga))
            .ReverseMap()
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga));

            CreateMap<Candidatura, EditarCandidaturaRequest>()
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga))
            .ReverseMap()
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga));

            CreateMap<Candidatura, ObterCandidaturaResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FkIdUsuario, opt => opt.MapFrom(src => src.FkIdUsuario))
            .ForMember(dest => dest.FkIdVaga, opt => opt.MapFrom(src => src.FkIdVaga));

        }

    }

}