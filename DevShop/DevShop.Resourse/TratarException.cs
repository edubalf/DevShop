using NHibernate;
using System;

namespace DevShop.Resourse
{
    public class TratarException
    {
        public static void NHibernateException(Exception ex, ITransaction transaction)
        {
            if (!transaction.WasCommitted)
            {
                transaction.Rollback();
            }

            throw ex;
        }

        public static void Exception(Exception ex)
        {
            throw ex;
        }
    }
}
