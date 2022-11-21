// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
                throw exception;
            }
        }

        void DoPrivateStuff() { }
    }
}
