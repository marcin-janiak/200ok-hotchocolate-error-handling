using System;

namespace WalletAPI.Models
{
    public class InsufficientBalanceException : Exception
    {
        public decimal RequestedAmount { get; }

        public InsufficientBalanceException(decimal requestedAmount) : base(
            $"Insufficient balance to withdraw {requestedAmount}")
        {
            RequestedAmount = requestedAmount;
        }
    }
}