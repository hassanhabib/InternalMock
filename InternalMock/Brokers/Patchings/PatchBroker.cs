// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;
using HarmonyLib;

namespace InternalMock.Brokers.Patchings
{
    public class PatchBroker : IPatchBroker
    {
        private readonly Harmony harmony;

        public PatchBroker() =>
            this.harmony = new Harmony("InternalMock");

        public MethodInfo PatchMethods(MethodInfo originalMethodInfo, MethodInfo additionalMethodInfo) =>
            this.harmony.Patch(originalMethodInfo, new HarmonyMethod(additionalMethodInfo));

        public void UnpatchAll() => this.harmony.UnpatchAll();
    }
}
