using Delivery.Application.Autenticacoes.Servicos.Interfaces;
using Delivery.DataTransfer.Autenticacoes.Requests;
using Delivery.DataTransfer.Autenticacoes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Autenticacoes.Interfaces
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        public AutenticacaoResponse Login(LoginRequest request)
        {
            return new AutenticacaoResponse(Guid.NewGuid(), "nome", "sobrenome", "email", "token");
        }

        public AutenticacaoResponse Registro(RegistroRequest request)
        {
            return new AutenticacaoResponse(Guid.NewGuid(), "nome", "sobrenome", "email", "token");
        }
    }
}
