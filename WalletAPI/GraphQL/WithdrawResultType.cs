using HotChocolate.Types;
using WalletAPI.Models;

namespace WalletAPI.GraphQL
{
    public class WithdrawResultType : UnionType<IWithdrawalResult>
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            base.Configure(descriptor);

            descriptor.Type<ObjectType<IWithdrawalResult.Valid>>();
            descriptor.Type<ObjectType<IWithdrawalResult.NotFound>>();
            descriptor.Type<ObjectType<IWithdrawalResult.InsufficientFunds>>();
        }
    }
}