// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;
using InternalMock.Services.Orchestrations.InternalMocks;
using Moq;
using Xunit;

namespace InternalMock.Tests.Unit.Services.Orchestrations.InternalMocks
{
    public partial class InternalMockOrchestrationServiceTests
    {
        [Fact]
        public void ShouldMockMethods()
        {
            // given
            Type randomType = GetRandomType();
            Type inputType = randomType;
            string randomMethodName = GetRandomMethodName();
            string inputMethodName = randomMethodName;
            var exception = new Exception();

            MethodInfo originalMethodInfo =
                CreateRandomMethodInfo();

            MethodInfo additionalMethodInfo =
                CreateRandomMethodInfo();

            this.reflectionServiceMock.Setup(service =>
                service.RetrieveMethodInformation(
                    inputType,
                    inputMethodName))
                        .Returns(originalMethodInfo);

            this.reflectionServiceMock.Setup(service =>
                service.RetrieveMethodInformation(
                    typeof(InternalMockOrchestrationService),
                    "ThrowException"))
                        .Returns(additionalMethodInfo);

            // when
            this.internalMockOrchestrationService.Mock(
                inputMethodName,
                inputType,
                exception);

            // then
            this.reflectionServiceMock.Verify(service =>
              service.RetrieveMethodInformation(
                  inputType,
                  inputMethodName),
                    Times.Once);

            this.reflectionServiceMock.Verify(service =>
                service.RetrieveMethodInformation(
                    typeof(InternalMockOrchestrationService),
                    "ThrowException"),
                        Times.Once);

            this.patchServiceMock.Verify(service =>
                service.PatchMethods(
                    originalMethodInfo,
                    additionalMethodInfo),
                        Times.Once);

            this.reflectionServiceMock.VerifyNoOtherCalls();
            this.patchServiceMock.VerifyNoOtherCalls();
        }
    }
}
