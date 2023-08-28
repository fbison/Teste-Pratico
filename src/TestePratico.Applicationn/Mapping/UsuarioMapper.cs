
using AutoMapper;
using System;
using TestePratico.Application.DTOs;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Models;

namespace TestePratico.Application.Mapping
{
    public class UsuarioMapper : Profile
    {
        /// <summary>
        /// Mapeamento De transações
        /// </summary>
        public UsuarioMapper()
        {
            CreateMap<UsuarioWithToken, LoginResponse>()
              .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
              .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Usuario.Login))
              .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Usuario.Tipo));

            CreateMap<Usuario, CriarUsuarioRequest>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao))
            .ReverseMap()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao));

            CreateMap<Usuario, EditarUsuarioRequest>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao))
            .ReverseMap()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao));



            CreateMap<Usuario, ObterUsuarioResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao));

            CreateMap<Usuario, ObterDadosUsuarioLogado>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao));
        }

    }

}