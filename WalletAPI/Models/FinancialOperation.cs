using System;

namespace WalletAPI.Models
{
    public record FinancialOperation(decimal Amount, OperationType Type, DateTimeOffset At);
}