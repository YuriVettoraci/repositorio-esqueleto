using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DataTransfer.Autenticacoes.Responses
{
    public record AutenticacaoResponse(
      Guid Id,
      string Nome,
      string Sobrenome,
      string Email,
      string Token
    );
}
