using DevShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Contracts.Repositories
{
    public interface IDesenvolvedorRepository : IDisposable
    {
        List<Desenvolvedor> Buscar();

        Desenvolvedor Obter(string usuarioGitHub);

        void Incluir(Desenvolvedor desenvolvedor);

        void Atualizar(Desenvolvedor desenvolvedor);

        void Remover(Desenvolvedor desenvolvedor);
    }
}
