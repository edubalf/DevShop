using DevShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Contracts.Services
{
    public interface IDesenvolvedorService : IDisposable
    {
        Desenvolvedor Obter(string usuarioGitHub);

        Desenvolvedor Incluir(Desenvolvedor desenvolvedor);

        void Atualizar(Desenvolvedor desenvolvedor);

        void Remover(Desenvolvedor desenvolvedor);
    }
}
