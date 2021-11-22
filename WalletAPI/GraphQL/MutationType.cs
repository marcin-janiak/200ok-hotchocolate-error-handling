using HotChocolate.Types;

namespace WalletAPI.GraphQL
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(x => x.Withdraw(default,
                    default,
                    default!))
                .Type<WithdrawResultType>();

            descriptor.Field(x => x.Deposit(default,
                    default,
                    default!))
                .Type<DepositResultType>();
        }
    }
}