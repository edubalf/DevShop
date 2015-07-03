using DevShop.Domain.Contracts.Repositories;
using System;
using DevShop.Domain.Models;
using NHibernate;
using DevShop.Infraestructure.Context;
using DevShop.Resourse;
using System.Linq;
using NHibernate.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DevShop.Infraestructure.Repositories
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        public List<Desenvolvedor> Buscar()
        {
            List<Desenvolvedor> retorno = null;

            using (ISession session = DevShopContext.AbrirSessao())
            {
                try
                {
                    retorno = session.Query<Desenvolvedor>().ToList();
                }
                catch (Exception ex)
                {
                    TratarException.Exception(ex);
                }
            }

            return retorno;
        }

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
                    TratarException.Exception(ex);
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
