using MovieApi.Services.Enums;

namespace MovieApi.Services.Common;

/// <summary>
/// DI uses a default service type, Specify this type using this attribute
/// </summary>
public class RegistrationOptions : Attribute
{
    public RegistrationOptions(Lifetime lifetime = Lifetime.Scoped, bool ignore = false)
    {
        Lifetime = lifetime;
        Ignore = ignore;
    }
    
    public Lifetime Lifetime { get; }
    public bool Ignore { get; }
}