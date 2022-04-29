// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace InternalMock.Models.Refelctions.Exceptions
{
    public class FailedReflectionServiceException : Xeption
    {
        public FailedReflectionServiceException(Exception innerException)
            : base(message: "Failed reflection exception occurred, please contact support", innerException)
        { }
    }
}
