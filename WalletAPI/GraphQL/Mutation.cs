using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Models;
using WalletAPI.Repositories;

namespace WalletAPI.GraphQL
{
    public class Mutation
    {
        public Guid OpenNewWallet([FromServices] IWalletRepository walletRepository)
        {
            var id = Guid.NewGuid();
            walletRepository.Add(new Wallet(id,
                new List<FinancialOperation>()));

            return id;
        }

        public IDepositResult Deposit(Guid id, decimal amount, [FromServices] IWalletRepository walletRepository)
        {
            var wallet = walletRepository.Get(id);

            if (wallet is null)
            {
                return new IDepositResult.NotFound(id);
            }

            wallet.Deposit(amount);

            return new IDepositResult.Valid(id,
                amount);
        }

        public IWithdrawalResult Withdraw(Guid id, decimal amount, [FromServices] IWalletRepository walletRepository)
        {
            try
            {
                var wallet = walletRepository.Get(id);

                if (wallet is null)
                {
                    return new IWithdrawalResult.NotFound(id);
                }

                wallet.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                //log exception?

                return new IWithdrawalResult.InsufficientFunds(id,
                    amount);
            }

            return new IWithdrawalResult.Valid(id,
                amount);
        }
    }
}