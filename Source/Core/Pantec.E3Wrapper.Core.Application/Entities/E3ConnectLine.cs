using Pantec.E3Proxy;
using Pantec.E3Wrapper.Core.Application.Entities.Base;
using Pantec.E3Wrapper.Core.Domain.Interfaces;

namespace Pantec.E3Wrapper.Core.Application.Entities
{
    /// <inheritdoc cref="IConnectLine" />
    /// <summary>
    /// Implementation of IConnectLine interface
    /// </summary>
    public class E3ConnectLine : ProxyWrapperBase<E3ConnectLineProxy>, IConnectLine
    {
        public E3ConnectLine(E3Job job)
            : base(job, () => new E3ConnectLineProxy(job.Proxy.CreateConnectLineObject()))
        {
        }

        #region Implementation of IE3Identificated

        /// <inheritdoc />
        public int GetId() => Proxy.GetId();

        /// <inheritdoc />
        public int SetId(int id) => Proxy.SetId(id);

        /// <inheritdoc />
        public int Id
        {
            get => GetId();
            set => SetId(value);
        }

        #endregion

        #region Implementation of IE3IdentificatedGlobal

        /// <inheritdoc />
        public string GlobalId => GetGlobalId();

        /// <inheritdoc />
        public string GetGlobalId() => ((IJob)Parent).GetGidOfId(Id);

        /// <inheritdoc />
        public int SetId(string globalId) => Proxy.SetId(((IJob)Parent).GetIdOfGid(globalId));

        #endregion
    }
}