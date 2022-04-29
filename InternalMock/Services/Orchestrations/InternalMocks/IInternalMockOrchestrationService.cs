// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace InternalMock.Services.Orchestrations.InternalMocks
{
    public interface IInternalMockOrchestrationService
    {
        void Mock(
            string internalMethodName,
            Type type,
            Exception exception);

        void UnpatchMethods();
    }
}
