namespace QuantumBinding.Generator;

/// <summary>The platform the headers are read for. It decides what the C types are - on Windows a long is 32 bits
/// and size_t an unsigned long long, on Linux and macOS both are 64 bits - and which of the headers' platform branches
/// clang takes. It is the target's, not the machine's the generator runs on, so the same headers give the same
/// bindings wherever they are generated.</summary>
public enum TargetPlatform
{
    Windows,

    Linux,

    MacOS
}
