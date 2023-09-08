using FluentNHibernate.Mapping;
using Maer.Domain;

namespace Maer.Data.Mappings
{
    public sealed class OficinaMap : ClassMap<Oficina>
    {
        public OficinaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Codigo);
            Map(x => x.Descripcion);
            HasMany(x => x.DatosxEmpresa).AsBag().Cascade.AllDeleteOrphan();
            Map(x => x.CantidadEmpleados);
            Map(x => x.Observacion);

        }
    }
}
