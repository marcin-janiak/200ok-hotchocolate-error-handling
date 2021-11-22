using System;

namespace WalletAPI.Models
{
    public interface IDepositResult
    {
        public record Valid(Guid WalletId, decimal DepositedAmount) : IDepositResult;

        public record NotFound(Guid WalletId) : IDepositResult;
    }
}