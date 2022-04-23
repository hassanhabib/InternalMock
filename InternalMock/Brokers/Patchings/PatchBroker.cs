// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
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

        public MethodInfo PatchMethods(MethodInfo original, MethodInfo additional) =>
            this.harmony.Patch(original, new HarmonyMethod(additional));

        public void UnpatchAll() => this.harmony.UnpatchAll();
    }
}
