using System.Collections.Generic;
using Maer.Domain.Attributes;
using Maer.Domain.Browser;
using Maer.Domain.MaestrosEmpresas;

namespace  Maer.Domain
{
    [Numerador(TipoNumerador.Secuencial, Descripcion ="Oficina")]
    public class Oficina : IIdentifiable, IMaestro<OficinaEmpresa>,  IInterfazSiga
    {
        public virtual int Id { get; set; } 
        
        [Ignorar]
        public virtual int IdSiga { get; set; }
        [Ignorar]
        public virtual int Codigo { get; set; }
        [Label("Descripción"), NotAllowBlank]
        public virtual string Descripcion { get; set; }

        [Label("Observacion"), NotAllowBlank]
        public virtual string Observacion { get; set; }

        [Ignorar]
        public virtual IList<OficinaEmpresa> DatosxEmpresa { get; set; }

        [Label("Cantidad de Empleados"), NotAllowBlank]
        public virtual int CantidadEmpleados { get; set; }

        public Oficina()
        {
            DatosxEmpresa = new List<OficinaEmpresa>();
        }

       

      

        #region Equals y HashCode
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var oficina = obj as Oficina;
            if (oficina == null) return false;

            if (!this.Descripcion.ToLower().Equals(oficina.Descripcion.ToLower())) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.Descripcion.ToLower().GetHashCode();
        }
        #endregion
    }
}