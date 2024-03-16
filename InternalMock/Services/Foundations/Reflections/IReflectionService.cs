// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;

namespace InternalMock.Services.Foundations.Reflections
{
    public interface IReflectionService
    {
        MethodInfo RetrieveMethodInformation(Type type, string methodName);
    }
}
