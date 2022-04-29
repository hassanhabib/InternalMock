// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace InternalMock.Tests.Unit.Services.Foundations.Reflections
{
    public partial class ReflectionServiceTests
    {
        [Fact]
        public void ShouldRetrieveMethodInfo()
        {
            // given
            Type randomType = GetRandomType();
            Type inputType = randomType;
            string randomMethodName = GetRandomMethodName();
            string inputMethodName = randomMethodName;
            MethodInfo randomMethodInfo = CreateRandomMethodInfo();
            MethodInfo retrievedMethodInfo = randomMethodInfo;
            MethodInfo expectedMethodInfo = retrievedMethodInfo.DeepClone();

            this.reflectionBrokerMock.Setup(broker =>
                broker.GetMethodInfo(inputType, inputMethodName))
                    .Returns(retrievedMethodInfo);

            // when
            MethodInfo actualMethodInfo =
                this.reflectionService.RetrieveMethodInformation(
                    inputType,
                    inputMethodName);

            // then
            actualMethodInfo.Should().BeSameAs(expectedMethodInfo);

            this.reflectionBrokerMock.Verify(broker =>
                broker.GetMethodInfo(inputType, inputMethodName),
                    Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
