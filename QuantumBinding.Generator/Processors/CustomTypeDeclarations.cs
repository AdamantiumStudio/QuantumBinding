using System.Linq;
using QuantumBinding.Generator.AST;
using QuantumBinding.Generator.Types;

namespace QuantumBinding.Generator.Processors;

internal static class CustomTypeDeclarations
{
    /// <summary>The declaration a custom type names. A typedef of a struct (C's typedef struct _x {...} x) names the
    /// struct, and the type takes the struct's name - only when the struct is there.</summary>
    internal static Declaration FindCustomTypeDeclaration(this ASTContext context, BindingType type)
    {
        if (!type.IsCustomType(out CustomType custom))
        {
            return null;
        }

        if (DeclarationUnit.DummyTypes.TryGetValue(custom.Name, out string realTypeName) &&
            context.FindDeclaration(realTypeName) is { } real)
        {
            custom.Name = realTypeName;
            return real;
        }

        return context.FindDeclaration(custom.Name);
    }

    /// <summary>The declaration of that name in any of the translation units.</summary>
    internal static Declaration FindDeclaration(this ASTContext context, string name)
    {
        foreach (var unit in context.TranslationUnits)
        {
            var declaration = unit.Declarations.FirstOrDefault(x => x.Name == name);
            if (declaration != null)
            {
                return declaration;
            }
        }

        return null;
    }
}
