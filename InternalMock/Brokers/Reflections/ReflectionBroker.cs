// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;

namespace InternalMock.Brokers.Reflections
{
    public class ReflectionBroker : IReflectionBroker
    {
        public MethodInfo GetMethodInfo(Type type, string methodName)
        {
            return type.GetMethod(
                methodName,
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        }
    }
}
