﻿using Pantec.E3Proxy;
using Pantec.E3Wrapper.Core.Application.Entities.Base;
using Pantec.E3Wrapper.Core.Application.Entities.Extensions;
using Pantec.E3Wrapper.Core.Domain.Interfaces;

namespace Pantec.E3Wrapper.Core.Application.Entities
{
    /// <inheritdoc cref="ISupply" />
    /// <summary>
    /// Implementation of ISupply interface
    /// </summary>
    public class E3Supply : ProxyWrapperBase<E3SupplyProxy>, ISupply
    {
        public E3Supply(E3Job job)
            : base(job, () => new E3SupplyProxy(job.Proxy.CreateSupplyObject()))
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

        #region Implementation of IE3NamedReadonly

        /// <inheritdoc />
        public string GetName() => Proxy.GetName();

        #endregion

        #region Implementation of IE3Named

        /// <inheritdoc />
        public bool SetName(string name) => Proxy.SetName(name).CastToBool();

        /// <inheritdoc />
        public string Name
        {
            get => GetName();
            set => Proxy.SetName(value);
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