// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using InternalMock.Brokers.Reflections;
using InternalMock.Services.Foundations.Reflections;
using Moq;
using Tynamix.ObjectFiller;

namespace InternalMock.Tests.Unit.Services.Foundations.Reflections
{
    public partial class ReflectionServiceTests
    {
        private readonly Mock<IReflectionBroker> reflectionBrokerMock;
        private readonly IReflectionService reflectionService;

        public ReflectionServiceTests()
        {
            this.reflectionBrokerMock = new Mock<IReflectionBroker>();

            this.reflectionService = new ReflectionService(
                reflectionBroker: this.reflectionBrokerMock.Object);
        }

        private static string GetRandomMethodName() =>
            new MnemonicString().GetValue();

        private static Type GetRandomType()
        {
            int randomNumber =
                new IntRange(0, 3).GetValue();

            return randomNumber switch
            {
                0 => typeof(String),
                1 => typeof(Int64),
                _ => typeof(Boolean)
            };
        }

        private static MethodInfo CreateRandomMethodInfo()
        {
            return new DynamicMethod("", null, null);
        }
    }
}
