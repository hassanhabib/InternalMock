﻿// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;
using InternalMock.Brokers.Reflections;

namespace InternalMock.Services.Foundations.Reflections
{
    public partial class ReflectionService : IReflectionService
    {
        private readonly IReflectionBroker reflectionBroker;

        public ReflectionService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public MethodInfo RetrieveMethodInformation(Type type, string methodName) =>
        TryCatch(() =>
        {
            ValidateMethodInformation(type, methodName);

            return this.reflectionBroker.GetMethodInfo(type, methodName);
        });
    }
}
