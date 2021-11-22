using System;
using WalletAPI.Models;

namespace WalletAPI.Repositories
{
    public interface IWalletRepository
    {
        Wallet? Get(Guid id);
        void Add(Wallet wallet);
    }
}