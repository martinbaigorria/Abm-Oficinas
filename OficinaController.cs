using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Maer.Common.IoC;
using Maer.Domain;
using Maer.Domain.Browser;
using Maer.Domain.General;
using Web.Support;
using Maer.Services;
using Maer.DataTransferObjects.General;
using System.Linq;
using Maer.Domain.MaestrosEmpresas;
using System;

namespace Web.Controllers
{
    [EntityName("Oficina", "la")]
    public class OficinaController : EntityServiceController<IOficinaServices, Oficina, OficinaDTO>
    {
        private readonly IOficinaServices _oficinaServices;

        public OficinaController(IOficinaServices oficinaServices)
        {
            _oficinaServices = oficinaServices;
        }

        public ActionResult GetOficinas(int oficinaId)
        {
            var oficinas = _oficinaServices.GetAllById<Oficina>(oficinaId).OrderBy(x => x.Codigo);
            var viewModel = Mapper.Map<IEnumerable<Oficina>, IEnumerable<ComboViewModel>>(oficinas);

            return Data(viewModel);
        }
        // Add other actions specific to the OficinaController here
    }
}
