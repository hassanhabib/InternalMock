// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using InternalMock.Models.Refelctions.Exceptions;
using Moq;
using Xunit;

namespace InternalMock.Tests.Unit.Services.Foundations.Reflections
{
    public partial class ReflectionServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionRetrieveMethodInfoIfMethodNameIsNull()
        {
            // given
            string nullMethodName = null;
            Type someType = GetRandomType();
            Type inputType = someType;

            var invalidMethodNameException =
                new InvalidMethodNameException();

            var reflectionValidationException =
                new ReflectionValidationException(invalidMethodNameException);

            // when
            Action retrieveMethodInformationAction = () =>
                this.reflectionService.RetrieveMethodInformation(
                    inputType,
                    nullMethodName);

            // then
            Assert.Throws<ReflectionValidationException>(
                retrieveMethodInformationAction);

            this.reflectionBrokerMock.Verify(broker =>
              broker.GetMethodInfo(inputType, nullMethodName),
                  Times.Never);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
