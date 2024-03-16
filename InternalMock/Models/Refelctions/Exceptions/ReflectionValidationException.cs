// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class ReflectionValidationException : Xeption
    {
        public ReflectionValidationException(Xeption innerException) :
            base(message: "Reflection validation error ocurred please fix errors and try again",
                innerException)
        { }
    }
}
