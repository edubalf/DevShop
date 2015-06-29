using DevShop.Domain.Contracts.Services;
using System;
using DevShop.Domain.Models;
using DevShop.Infraestructure.Repositories;
using DevShop.Services.Externo;

namespace DevShop.Services.Sevices
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private readonly DesenvolvedorRepository desenvolvedorRepository = new DesenvolvedorRepository();
        private readonly GitHub gitHub = new GitHub();

        public Desenvolvedor Obter(string usuarioGitHub)
        {
            var desenvolvedor = desenvolvedorRepository.Obter(usuarioGitHub);

            desenvolvedor.IncluirUsuarioGitHub(gitHub.ObterUsuario(desenvolvedor.Usuario));

            return desenvolvedor;
        }

        public Desenvolvedor Incluir(Desenvolvedor desenvolvedor)
        {
            if (gitHub.ObterUsuario(desenvolvedor.Usuario) != null)
            {
                desenvolvedorRepository.Incluir(desenvolvedor);
            }
            else
            {
                desenvolvedor.Mensagens.Add("O usuário não possui GitHub");
            }

            return desenvolvedor;
        }

        public void Atualizar(Desenvolvedor desenvolvedor)
        {
            desenvolvedorRepository.Atualizar(desenvolvedor);
        }

        public void Remover(Desenvolvedor desenvolvedor)
        {
            desenvolvedorRepository.Remover(desenvolvedor);
        }

        public void Dispose()
        {
            desenvolvedorRepository.Dispose();
            this.Dispose();
        }
    }
}
