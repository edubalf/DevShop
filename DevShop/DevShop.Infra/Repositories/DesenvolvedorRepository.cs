using DevShop.Domain.Contracts.Repositories;
using System;
using DevShop.Domain.Models;
using NHibernate;
using DevShop.Infraestructure.Context;
using DevShop.Resourse;
using System.Linq;
using NHibernate.Linq;

namespace DevShop.Infraestructure.Repositories
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        public Desenvolvedor Obter(string usuario)
        {
            Desenvolvedor retorno = null;

            using (ISession session = DevShopContext.AbrirSessao())
            {
                try
                {
                    retorno = session.QueryOver<Desenvolvedor>()
                        .Where(x => x.Usuario == usuario)
                        .List()
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    TratarException.NHibernateException(ex);
                }
            }

            return retorno;
        }

        public void Incluir(Desenvolvedor desenvolvedor)
        {
            using (ISession session = DevShopContext.AbrirSessao())
            {
                using (ITransaction tr = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(desenvolvedor);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        TratarException.NHibernateException(ex, tr);
                    }
                }
            }
        }

        public void Atualizar(Desenvolvedor desenvolvedor)
        {
            using (ISession session = DevShopContext.AbrirSessao())
            {
                using (ITransaction tr = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(desenvolvedor);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        TratarException.NHibernateException(ex, tr);
                    }
                }
            }
        }

        public void Remover(Desenvolvedor desenvolvedor)
        {
            using (ISession session = DevShopContext.AbrirSessao())
            {
                using (ITransaction tr = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(desenvolvedor);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        TratarException.NHibernateException(ex, tr);
                    }
                }
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
