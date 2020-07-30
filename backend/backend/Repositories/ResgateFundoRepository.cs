using System;
using src.Database;
using src.Models;

namespace src.Repositories
{
    public class ResgateFundoRepository : BaseRepository<ResgateFundo>, IResgateFundoRepository
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="kinvoContext">Contexto usado no service</param>
        public ResgateFundoRepository(KinvoDbContext kinvoContext) : base(kinvoContext) { }

    }
}
