namespace Maer.DataTransferObjects.General
{
    public class OficinaDTO : DTOMaster<OficinaEmpresaDTO>
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public int Codigo { get; set; }
        public int CantidadEmpleados { get; set; }

    }
}