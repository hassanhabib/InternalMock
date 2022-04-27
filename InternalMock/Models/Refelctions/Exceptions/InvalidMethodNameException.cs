// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class InvalidMethodNameException : Exception
    {
        public InvalidMethodNameException() :
            base(message: "Method name cannot be null")
        { }
    }
}
