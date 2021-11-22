using System;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Models;
using WalletAPI.Repositories;

namespace WalletAPI.GraphQL
{
    public class Query
    {
        public Wallet? GetWallet(Guid id, [FromServices] IWalletRepository walletRepository)
        {
            return walletRepository.Get(id);
        }
    }
}