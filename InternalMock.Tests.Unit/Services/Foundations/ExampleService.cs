using System;

namespace InternalMock.Tests.Unit.Services.Foundations
{
    public class ExampleService
    {
        delegate void VoidFunction();

        public void DoStuff()
        {
            TryCatch(() =>
            {
                DoPrivateStuff();
            });
        }

        void TryCatch(VoidFunction voidFunction)
        {
            try
            {
                voidFunction();
            }
            catch (NullReferenceException exception)
            {
                // illustrative only
                throw exception;
            }
        }

        void DoPrivateStuff() { }
    }
}
