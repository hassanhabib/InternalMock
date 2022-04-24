// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;
using InternalMock.Brokers.Patchings;

namespace InternalMock.Services.Foundations.Patchings
{
    public class PatchService : IPatchService
    {
        private readonly IPatchBroker patchBroker;

        public PatchService(IPatchBroker patchBroker) =>
            this.patchBroker = patchBroker;

        public void PatchMethods(
            MethodInfo originalMethodInfo,
            MethodInfo additionalMethoInfo)
        {
            this.patchBroker.PatchMethods(
                originalMethodInfo,
                additionalMethoInfo);
        }

        public void UnpatchMethods() =>
            throw new System.NotImplementedException();
    }
}
