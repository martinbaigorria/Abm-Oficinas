using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maer.DataTransferObjects.General;
using Maer.Domain;
using Maer.Domain.Exceptions;
using Maer.Domain.MaestrosEmpresas;

namespace Maer.Services.Support.TypeConverters
{
    public class OficinaTypeConverter : MaerTypeConverter<OficinaDTO, Oficina>
    {
        protected override Oficina ConvertCore(OficinaDTO source)
        {
            try
            {
                Oficina Oficina = null;
               
                if (Oficina == null) Oficina = new Oficina();

                //moneda.CotizacionActual = source.CotizacionActual;
                Oficina.Descripcion = source.Descripcion;
                Oficina.Codigo = source.Codigo;
                Oficina.CantidadEmpleados = source.CantidadEmpleados;
                Oficina.Observacion = source.Observacion;




                var empresas = EmpresaServices.GetAllByMultiple(x => x.Id, source.EmpresasSeleccionadas);

                foreach (var emp in source.Empresas)
                {
                    var e = emp.EmpresaId != 0 ? empresas.FirstOrDefault(x => x.Id == emp.EmpresaId) : new Empresa();
                    if (e == null) continue;

                    var OficinaEmpresa = Oficina.DatosxEmpresa.FirstOrDefault(x => x.Empresa.Id == emp.EmpresaId);

                    if (OficinaEmpresa == null)
                    {
                        OficinaEmpresa = new OficinaEmpresa();
                        Oficina.DatosxEmpresa.Add(OficinaEmpresa);
                    }

                    OficinaEmpresa.Oficina = Oficina;
                    OficinaEmpresa.Empresa = e;

                }

                foreach (var empresaId in source.EmpresasSeleccionadas)
                {
                    var empresa = EmpresaServices.Get(empresaId);
                    Oficina.AddEmpresa(empresa);
                }


                var deEliminados = Oficina.DatosxEmpresa.Where(de => source.EmpresasSeleccionadas.All(es => es != de.Empresa.Id)).ToList();
                foreach (var dee in deEliminados)
                    Oficina.DatosxEmpresa.Remove(dee);

                return Oficina;
            }
            catch (SigaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw new SigaException("Hubo un error al guardar oficina", ex, ex.StackTrace);
            }
        }
    }
}
