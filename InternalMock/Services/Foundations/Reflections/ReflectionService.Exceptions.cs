// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;
using InternalMock.Models.Refelctions.Exceptions;

namespace InternalMock.Services.Foundations.Reflections
{
    public partial class ReflectionService
    {
        private delegate MethodInfo ReturningMethodInfoFunction();

        private MethodInfo TryCatch(ReturningMethodInfoFunction returningMethodInfoFunction)
        {
            try
            {
                return returningMethodInfoFunction();
            }
            catch (InvalidRefelctionException invalidMethodNameException)
            {
                var reflectionValidationException =
                    new ReflectionValidationException(invalidMethodNameException);

                throw reflectionValidationException;
            }
        }
    }
}
