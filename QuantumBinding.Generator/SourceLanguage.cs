namespace QuantumBinding.Generator;

/// <summary>The language the headers are read as. C++ by default; C for a C API whose headers carry C++ wrappers
/// under <c>__cplusplus</c>, which C reading leaves out together with the C++ standard headers they include.</summary>
public enum SourceLanguage
{
    Cpp,

    C
}
