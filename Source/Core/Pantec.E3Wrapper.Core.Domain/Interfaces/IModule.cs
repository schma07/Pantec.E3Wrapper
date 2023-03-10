using Pantec.E3Proxy;
using Pantec.E3Wrapper.Core.Domain.Interfaces.Proxy;

namespace Pantec.E3Wrapper.Core.Domain.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Interface for class-wrapper of e3Module COM object
    /// </summary>
    public interface IModule : IProxyProvider<E3ModuleProxy>,
        IE3Identificated, IE3Named, IE3IdentificatedGlobal, IE3Attributed
    {
    }
}