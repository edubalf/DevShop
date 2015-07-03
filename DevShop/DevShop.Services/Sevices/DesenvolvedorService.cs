using DevShop.Domain.Contracts.Services;
using System;
using DevShop.Domain.Models;
using DevShop.Infraestructure.Repositories;
using DevShop.Services.Externo;
using DevShop.Domain.Contracts.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace DevShop.Services.Sevices
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private DesenvolvedorRepository _repository = new DesenvolvedorRepository();

        private readonly GitHub gitHub = new GitHub();

        public List<Desenvolvedor> Buscar()
        {
            return _repository.Buscar();
        }

        public Desenvolvedor Obter(string usuarioGitHub)
        {
            var desenvolvedor = _repository.Obter(usuarioGitHub);

            desenvolvedor.IncluirUsuarioGitHub(gitHub.ObterUsuario(desenvolvedor.Usuario));

            return desenvolvedor;
        }

        public Desenvolvedor Incluir(string usuarioGitHub, decimal precoHora)
        {
            var dev = new Desenvolvedor(usuarioGitHub, precoHora);

            if (gitHub.ObterUsuario(dev.Usuario) != null)
            {
                _repository.Incluir(dev);
            }
            else
            {
                dev.Mensagens.Add("O usuário não possui GitHub");
            }

            return dev;
        }

        public void Atualizar(string usuarioGitHub, decimal precoHora)
        {
            var dev = _repository.Obter(usuarioGitHub);

            dev.AlterarPreco(precoHora);

            _repository.Atualizar(dev);
        }

        public void Remover(string usuarioGitHub)
        {
            var dev = _repository.Obter(usuarioGitHub);

            _repository.Remover(dev);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
