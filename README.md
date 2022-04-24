<p align="center">
  <img width="25%" height="25%" src="https://github.com/hassanhabib/InternalMock/blob/master/InternalMock/InternalMock.png">
</p>


# InternalMock

This is a beta release please use carefully.

This library allows you to mock internal private static methods in your service - please watch the following videos for context:

Example of usage:

```csharp
        [Fact(DisplayName = "Awesome solution")]
        public void ShouldThrowServiceExceptionOnStartIfServiceErrorOccurrs3()
        {
            // given
            var exception = new Exception();

            this.expressionService.Mock(
                "GetCarrot",
                exception);

            // when
            Action getStartExpressionAction = () =>
                this.expressionService.GetStartExpression();

            // then
            ExpressionServiceException expressionServiceException =
                Assert.Throws<ExpressionServiceException>(
                    getStartExpressionAction);

            Assert.True(expressionServiceException.InnerException
                is FailedExpressionServiceException);

            this.expressionService.ClearAllOtherCalls();
        }

```


For more information contact Hassan Habib: hassanhabib@live.com
