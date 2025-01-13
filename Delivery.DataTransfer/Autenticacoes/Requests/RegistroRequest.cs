using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DataTransfer.Autenticacoes.Requests
{
    public record RegistroRequest(
      string Nome,
      string Sobrenome,
      string Email,
      string Senha
    );
}
