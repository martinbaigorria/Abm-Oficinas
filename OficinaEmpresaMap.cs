using FluentNHibernate.Mapping;
using Maer.Domain;
using Maer.Domain.MaestrosEmpresas;

namespace Maer.Data.Mappings.MaestrosEmpresas
{
    public sealed class OficinaEmpresaMap : ClassMap<OficinaEmpresa>
    {
        public OficinaEmpresaMap()
        {
            Table("EmpresasXMoneda");
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.Empresa);
            References(x => x.Oficina);

        }
    }
}