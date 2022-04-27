// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class ReflectionValidationException : Exception
    {
        public ReflectionValidationException(Exception innerException) :
            base(message: "Reflection validation error ocurred please fix issue anr try again", innerException)
        {}
    }
}
