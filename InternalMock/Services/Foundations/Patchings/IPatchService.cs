// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;

namespace InternalMock.Services.Foundations.Patchings
{
    public interface IPatchService
    {
        void PatchMethods(MethodInfo originalMethodInfo, MethodInfo additionalMethoInfo);
    }
}
