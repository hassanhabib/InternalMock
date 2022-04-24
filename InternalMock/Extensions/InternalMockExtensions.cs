// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using InternalMock.Brokers.Patchings;
using InternalMock.Brokers.Reflections;
using InternalMock.Services.Foundations.Patchings;
using InternalMock.Services.Foundations.Reflections;
using InternalMock.Services.Orchestrations.InternalMocks;

namespace InternalMock.Extensions
{
    public static class InternalMockExtensions
    {
        private static IInternalMockOrchestrationService InternalMockOrchestrationService;

        public static void Mock(this object service, string methodName, Exception exception)
        {
            InternalMockOrchestrationService = CreateMockService();

            InternalMockOrchestrationService.Mock(
                methodName,
                service.GetType(),
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
