using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevShop.Services.Externo;
using DevShop.Domain.Models;

namespace DevShop.Services.Test.Externo
{
    [TestClass]
    public class GitHubTest
    {
        [TestMethod]
        public void UsuarioValido()
        {
            var gitHub = new GitHub();

            var usuario = gitHub.ObterUsuario("edubalf");

            Assert.AreEqual(8027415, usuario.id);
        }

        [TestMethod]
        public void UsuarioInvalido()
        {
            var gitHub = new GitHub();

            var usuario = gitHub.ObterUsuario("eduba");

            Assert.IsNull(usuario);
        }
    }
}
