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

        List<Desenvolvedor> Buscar();

        Desenvolvedor Incluir(string usuarioGitHub, decimal precoHora);

        void Atualizar(string usuarioGitHub, decimal precoHora);

        void Remover(string usuarioGitHub);
    }
}
