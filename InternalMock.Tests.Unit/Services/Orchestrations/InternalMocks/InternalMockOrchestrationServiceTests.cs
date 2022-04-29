// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using InternalMock.Services.Foundations.Patchings;
using InternalMock.Services.Foundations.Reflections;
using InternalMock.Services.Orchestrations.InternalMocks;
using Moq;
using Tynamix.ObjectFiller;

namespace InternalMock.Tests.Unit.Services.Orchestrations.InternalMocks
{
    public partial class InternalMockOrchestrationServiceTests
    {
        private readonly Mock<IReflectionService> reflectionServiceMock;
        private readonly Mock<IPatchService> patchServiceMock;
        private readonly IInternalMockOrchestrationService internalMockOrchestrationService;

        public InternalMockOrchestrationServiceTests()
        {
            this.reflectionServiceMock = new Mock<IReflectionService>();
            this.patchServiceMock = new Mock<IPatchService>();

            this.internalMockOrchestrationService = new InternalMockOrchestrationService(
                reflectionService: this.reflectionServiceMock.Object,
                patchService: this.patchServiceMock.Object);
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

        private static int GetRandomNumber() =>
            new IntRange(2, 10).GetValue();

        private static Type[] GetRandomTypes()
        {
            int randomNumber = GetRandomNumber();

            return Enumerable.Range(start: 0, count: randomNumber)
                .Select(item => GetRandomType()).ToArray();
        }

        private static MethodInfo CreateRandomMethodInfo()
        {
            string randomMethodName = GetRandomMethodName();
            Type randomType = GetRandomType();
            Type[] randomTypes = GetRandomTypes();

            return new DynamicMethod(
                name: randomMethodName,
                returnType: randomType,
                parameterTypes: randomTypes);
        }
    }
}
