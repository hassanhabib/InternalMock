// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using InternalMock.Brokers.Patchings;
using InternalMock.Brokers.Reflections;
using InternalMock.Models.Extensions;
using InternalMock.Services.Foundations.Patchings;
using InternalMock.Services.Foundations.Reflections;
using InternalMock.Services.Orchestrations.InternalMocks;

namespace InternalMock.Extensions
{
    public static class InternalMockExtensions
    {
        private static IInternalMockOrchestrationService InternalMockOrchestrationService;

        public static MockedMethod Mock(this object service, string methodName)
        {
            return new MockedMethod
            {
                Type = service.GetType(),
                MethodName = methodName
            };
        }

        public static void Throws(this MockedMethod mockedMethod, Exception exception)
        {
            InternalMockOrchestrationService = CreateMockService();

            InternalMockOrchestrationService.Mock(
                mockedMethod.MethodName,
                mockedMethod.Type,
                exception);
        }

        public static void ClearAllOtherCalls(this object service) =>
            InternalMockOrchestrationService.UnpatchMethods();

        private static IInternalMockOrchestrationService CreateMockService()
        {
            var reflectionBroker = new ReflectionBroker();
            var patchBroker = new PatchBroker();
            var reflectionService = new ReflectionService(reflectionBroker);
            var patchService = new PatchService(patchBroker);

            return new InternalMockOrchestrationService(
                reflectionService,
                patchService);
        }
    }
}
