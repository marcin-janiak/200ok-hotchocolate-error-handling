using System;

namespace WalletAPI.Models
{
    public interface IWithdrawalResult
    {
        public record Valid(Guid WalletId, decimal WithdrawnAmount) : IWithdrawalResult;
        public record NotFound(Guid WalletId) : IWithdrawalResult;
        public record InsufficientFunds(Guid WalletId, decimal Amount) : IWithdrawalResult;
    }
}