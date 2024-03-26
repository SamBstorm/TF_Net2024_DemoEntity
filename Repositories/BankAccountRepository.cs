using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net2024_DemoEntity.Contexts;
using TF_Net2024_DemoEntity.Entities;

namespace TF_Net2024_DemoEntity.Repositories
{
    public class BankAccountRepository
    {
        public BankAccount Insert(BankAccount entity)
        {
			try
			{
				using (DemoContext context = new DemoContext())
				{
					context.BankAccounts.Add(entity);
					context.SaveChanges();
					return entity;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public BankAccount GetById(string accountNumber) {
			try
			{
				using (DemoContext context = new DemoContext())
				{
					BankAccount account = context.BankAccounts
						.Include(b => b.Titular)
						.SingleOrDefault(b => b.AccountNumber == accountNumber);
					if (account is null) throw new ArgumentOutOfRangeException(nameof(accountNumber));
					return account;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public void Delete(string accountNumber)
        {
            try
            {
                using (DemoContext context = new DemoContext())
                {
                    BankAccount account = context.BankAccounts.SingleOrDefault(b => b.AccountNumber == accountNumber);
                    if (account is null) throw new ArgumentOutOfRangeException(nameof(accountNumber));
					context.BankAccounts.Remove(account);
					context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
