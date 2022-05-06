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
            Type someType = GetRandomType();
            Type inputType = someType;
            string someName = GetRandomMethodName();
            string inputName = someName;

            Exception exception = new Exception();

            var failedReflectionServiceException =
                new FailedReflectionServiceException(exception);

            var expectedReflectionServiceException =
                new ReflectionServiceException(failedReflectionServiceException);

            this.reflectionBrokerMock.Setup(broker =>
                broker.GetMethodInfo(It.IsAny<Type>(), It.IsAny<string>()))
                    .Throws(exception);

            // when
            Action retrieveMethodInformationAction = () =>
                this.reflectionService.RetrieveMethodInformation(
                    inputType,
                    inputName);

            // then
            Assert.Throws<ReflectionServiceException>(
                retrieveMethodInformationAction);

            this.reflectionBrokerMock.Verify(broker =>
              broker.GetMethodInfo(inputType, inputName),
                  Times.Once);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
