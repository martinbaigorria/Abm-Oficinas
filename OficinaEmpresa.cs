namespace  Maer.Domain.MaestrosEmpresas
{
    public class OficinaEmpresa : IIdentifiable, IMaestroEmpresa
    {
        public virtual int Id { get; set; } 
        
        public virtual Empresa Empresa { get; set; }
        public virtual Oficina Oficina { get; set; }
        
    }
}
