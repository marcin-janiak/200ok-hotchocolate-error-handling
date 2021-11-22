using System;
using System.Collections.Generic;
using System.Linq;

namespace WalletAPI.Models
{
    public class Wallet
    {
        public Guid Id { get; }
        public ICollection<FinancialOperation> Operations { get; }
        
        public Wallet(Guid id, ICollection<FinancialOperation> operations)
        {
            Id = id;
            Operations = operations;
        }

        public decimal GetBalance()
        {
            return Operations.Sum(x => x.Type == OperationType.Deposit ? x.Amount : -x.Amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > GetBalance())
            {
                throw new InsufficientBalanceException(amount);
            }

            Operations.Add(new FinancialOperation(amount,
                OperationType.Withdrawal,
                DateTimeOffset.UtcNow));
        }

        public void Deposit(decimal amount)
        {
            Operations.Add(new FinancialOperation(amount,
                OperationType.Deposit,
                DateTimeOffset.UtcNow));
        }
    }
}