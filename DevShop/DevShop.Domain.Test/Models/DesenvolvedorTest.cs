using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevShop.Domain.Models;

namespace DevShop.Domain.Test.Models
{
    [TestClass]
    public class DesenvolvedorTest
    {
        [TestMethod]
        public void DesenvolvedorValido()
        {
            var valor = 10.00m;

            var desenvolvedor = new Desenvolvedor("edubalf", valor);

            Assert.IsTrue(desenvolvedor.Valido);
            Assert.AreEqual(desenvolvedor.Usuario, "edubalf");
            Assert.AreEqual(desenvolvedor.PrecoHora, valor);
        }

        [TestMethod]
        public void TrocarPrecoHora()
        {
            var valor = 10.00m;

            var desenvolvedor = new Desenvolvedor("edubalf", valor);

            valor = 11.00m;

            desenvolvedor.AlterarPreco(valor);

            Assert.AreEqual(desenvolvedor.PrecoHora, valor);
        }
    }
}
