using DevShop.Domain.Models.Erro;
using System;

namespace DevShop.Domain.Models
{
    public class Desenvolvedor : Error
    {
        #region Properties

        public virtual Guid CodDesenvolvedor { get; protected set; }
        public virtual string Usuario { get; protected set; }
        public virtual decimal PrecoHora { get; protected set; }
        public UsuarioGitHub UsuarioGitHub { get; protected set; }

        #endregion

        #region Contructor

        public Desenvolvedor(string usuario, decimal precoHora)
        {
            NotEmpty(usuario, "O usuário do GitHub é obrigatório.");
            ValidarPreco(precoHora);

            if (Valido)
            {
                CodDesenvolvedor = Guid.NewGuid();
                Usuario = usuario;
                PrecoHora = precoHora;
            }
        }

        #endregion

        #region Methods

        public void AlterarPreco(decimal precoHora)
        {
            ValidarPreco(precoHora);

            if (Valido)
            {
                PrecoHora = precoHora;
            }
        }

        public void IncluirUsuarioGitHub(UsuarioGitHub usuarioGitHub)
        {
            Equals(usuarioGitHub.login, Usuario, "O usuario do GitHub deve ser igual ao usuario atual");

            if (Valido)
            {
                UsuarioGitHub = usuarioGitHub;
            }
        }

        private void ValidarPreco(decimal precoHora)
        {
            True(precoHora > 0, "O preço é obrigatório.");
        }

        #endregion
    }
}
