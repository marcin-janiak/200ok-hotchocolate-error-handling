using HotChocolate.Types;
using WalletAPI.Models;

namespace WalletAPI.GraphQL
{
    public class DepositResultType : UnionType<IDepositResult>
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            base.Configure(descriptor);

            descriptor.Type<ObjectType<IDepositResult.Valid>>();
            descriptor.Type<ObjectType<IDepositResult.NotFound>>();
        }
    }
}