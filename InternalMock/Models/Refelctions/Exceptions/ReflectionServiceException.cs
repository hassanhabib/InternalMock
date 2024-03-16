// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class ReflectionServiceException : Xeption
    {
        public ReflectionServiceException(Xeption innerException)
            : base(message: "Reflection service excpetion occurred, please contact support", innerException)
        { }
    }
}
