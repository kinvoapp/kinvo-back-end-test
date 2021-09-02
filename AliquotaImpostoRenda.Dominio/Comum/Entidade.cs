using System;

namespace AliquotaImpostoRenda.Dominio.Comum
{
    public class Entidade
    {
        public int Id { get; set; }
        public DateTime Createad { get; set; } = DateTime.UtcNow;
        public DateTime Updatead { get; set; } = DateTime.UtcNow;
    }
}
