// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using InternalMock.Services.Foundations.Patchings;
using InternalMock.Services.Foundations.Reflections;

namespace InternalMock.Services.Orchestrations.InternalMocks
{
    public class InternalMockOrchestrationService : IInternalMockOrchestrationService
    {
        private readonly IReflectionService reflectionService;
        private readonly IPatchService patchService;

        public InternalMockOrchestrationService(
            IReflectionService reflectionService,
            IPatchService patchService)
        {
            this.reflectionService = reflectionService;
            this.patchService = patchService;
        }

        public void Mock(string internalMethodName, Type type, Exception exception)
        {
            throw new NotImplementedException();
        }

        private static void ThrowException(Exception exception) => throw exception;
    } 
}
