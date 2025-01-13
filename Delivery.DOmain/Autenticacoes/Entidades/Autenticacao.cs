using Delivery.Domain.Autenticacoes.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Autenticacoes.Entidades
{
    public class Autenticacao
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual ExemploAuthEnum AuthEnum { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual string Token { get; protected set; }
        public virtual DateTime DataCriacao { get; protected set; }
    }
}
