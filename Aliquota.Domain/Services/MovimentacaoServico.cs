using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Aliquota.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Services
{
    public class MovimentacaoServico : IMovimentacaoServico
    {
        private readonly IMovimentacaoRepositorio _repositorio;
    }
}