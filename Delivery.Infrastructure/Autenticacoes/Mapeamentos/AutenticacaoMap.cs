using Delivery.Domain.Autenticacoes.Entidades;
using Delivery.Domain.Autenticacoes.Enumeradores;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;



namespace Delivery.Infrastructure.Autenticacoes.Mapeamentos
{
    public class AutenticacaoMap : ClassMap<Autenticacao>
    {
        public AutenticacaoMap()
        {
            Table("autenticacao");
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(x => x.Email).Column("email");
            Map(x => x.Senha).Column("senha");
            Map(x => x.DataCriacao).Column("datacriacao");
            Map(x => x.Token).Column("token");
            Map(x => x.Nome).Column("nome");
            Map(x => x.AuthEnum).Column("authenum").CustomType<ExemploAuthEnum>();
        }
    }
}
