using System;
using System.Collections.Generic;
using System.Linq;
using WalletAPI.Models;

namespace WalletAPI.Repositories
{
    public class InMemoryWalletRepository : IWalletRepository
    {
        public InMemoryWalletRepository()
        {
            _wallets = new List<Wallet>() { };
        }

        private List<Wallet> _wallets;

        public Wallet? Get(Guid id)
        {
            return _wallets.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Wallet wallet)
        {
            _wallets.Add(wallet);
        }
    }
}