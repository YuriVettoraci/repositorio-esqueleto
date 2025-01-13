using AutoMapper;
using Delivery.DataTransfer.Autenticacoes.Responses;
using Delivery.Domain.Autenticacoes.Entidades;
using Delivery.Domain.Autenticacoes.Enumeradores;
using Delivery.Domain.Utilitarios.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Autenticacoes.Profiles
{
    public class AutenticacaoProfile : Profile
    {
        public AutenticacaoProfile()
        {
            CreateMap<ExemploAuthEnum, EnumValue>().ConvertUsing(src => src.GetValue());
            CreateMap<Autenticacao, AutenticacaoResponse>();
        }
    }
}
