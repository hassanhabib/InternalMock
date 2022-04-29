// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using InternalMock.Models.Refelctions.Exceptions;

namespace InternalMock.Services.Foundations.Reflections
{
    public partial class ReflectionService
    {
        private void ValidateMethodInformation(Type type, string methodName)
        {
            Validate
                (
                    (Rule: IsInvalid(type), Parameter: nameof(type)),
                    (Rule: IsInvalid(methodName), Parameter: nameof(methodName))
                );
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalid(Type type) => new
        {
            Condition = type == default,
            Message = "Type is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidReflectionException = new InvalidRefelctionException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidReflectionException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidReflectionException.ThrowIfContainsErrors();
        }
    }
}
