using DevShop.Domain.Models;
using FluentNHibernate.Mapping;

namespace DevShop.Infraestructure.Map
{
    public class DesenvolvedorMap : ClassMap<Desenvolvedor>
    {
        public DesenvolvedorMap()
        {
            Id(x => x.CodDesenvolvedor);

            Map(x => x.UsuarioGitHub)
                .Not.Nullable()
                .Length(150);

            Map(x => x.PrecoHora)
                .Not.Nullable();
        }
    }
}
