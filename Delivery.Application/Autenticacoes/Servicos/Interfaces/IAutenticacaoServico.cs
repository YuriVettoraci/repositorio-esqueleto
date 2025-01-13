using Delivery.DataTransfer.Autenticacoes.Requests;
using Delivery.DataTransfer.Autenticacoes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacaoServico
    {
        AutenticacaoResponse Login(LoginRequest request);
        AutenticacaoResponse Registro(RegistroRequest request);
    }
}
