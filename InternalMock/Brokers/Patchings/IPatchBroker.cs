// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;

namespace InternalMock.Brokers.Patchings
{
    public interface IPatchBroker
    {
        MethodInfo PatchMethods(MethodInfo originalMethodInfo, MethodInfo additionalMethodInfo);
        void UnpatchAll();
    }
}
