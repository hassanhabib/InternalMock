// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class InvalidRefelctionException : Xeption
    {
        public InvalidRefelctionException()
            : base(message: "Invalid reflection. Please correct the errors and try again.")
        { }
    }
}
