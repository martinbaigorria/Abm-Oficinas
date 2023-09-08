using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maer.Domain;
using Maer.Domain.MaestrosEmpresas;
using NHibernate.Validator.Cfg.Loquacious;

namespace Maer.Data.ValidationDefs
{
    public class OficinaValidation : ValidationDef<Oficina>
    {
        public OficinaValidation()
        {
            // TODO Hay que cambiar el mensaje de NotNullableAndNotEmpty y en gral todos los mensajes de error
            Define(x => x.Descripcion).NotNullableAndNotEmpty();
            //Define(x => x.CotizacionActual).GreaterThanOrEqualTo(0).WithMessage("La cotización debe ser mayor a cero.");
        }
    }

    // TODO: chequear que este validation se corra al guardar moneda
    public class OficinaEmpresaValidation : ValidationDef<OficinaEmpresa>
    {
        public OficinaEmpresaValidation()
        {
        }
    }

}

