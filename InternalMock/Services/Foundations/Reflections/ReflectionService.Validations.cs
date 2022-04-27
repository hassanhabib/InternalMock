// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using InternalMock.Models.Refelctions.Exceptions;

namespace InternalMock.Services.Foundations.Reflections
{
    public partial class ReflectionService
    {
        private void ValidateMethodName(string methodName)
        {
            if (methodName == null)
            {
                throw new InvalidMethodNameException();
            }
        }
    }
}
