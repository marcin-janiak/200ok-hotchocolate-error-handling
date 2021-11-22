using System;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace WalletAPI.GraphQL
{
    public class CustomUnionTypesNamingConventions : DefaultNamingConventions
    {
        public override NameString GetTypeName(Type type)
        {
            return type.DeclaringType is null ? type.Name : $"{type.Name}{RemoveIFromDeclaringInterfaceName(type)}";
        }

        public override NameString GetTypeName(Type type, TypeKind kind)
        {
            var name = type.DeclaringType is null ? type.Name : $"{type.Name}{RemoveIFromDeclaringInterfaceName(type)}";

            if (kind == TypeKind.Union)
            {
                return new NameString(name.Substring(1) + "Union");
            }

            return new NameString(name);
        }

        private string RemoveIFromDeclaringInterfaceName(Type type)
        {
            if (type.DeclaringType is not null && type.DeclaringType.IsInterface)
            {
                return type.DeclaringType.Name.Substring(1);
            }

            return type.DeclaringType is null ? string.Empty : type.DeclaringType.Name;
        }
    }
}