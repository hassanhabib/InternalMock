// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
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
        public void ShouldThrowServiceExceptionOnRetrieveMethodInfoIfExceptionOccurs()

        {
            // given
            string nullMethodName = null;
            Type someType = GetRandomType();
            Type inputType = someType;

            var invalidReflectionException =
                new InvalidRefelctionException();

            invalidReflectionException.AddData(
                key: "type",
                values: "Type is required");

            invalidReflectionException.AddData(
                key: "methodName",
                values: "Text is required");

            var reflectionValidationException =
                new ReflectionValidationException(invalidReflectionException);

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
