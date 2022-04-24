// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Reflection;
using Moq;
using Xunit;

namespace InternalMock.Tests.Unit.Services.Foundations.Patchings
{
    public partial class PatchServiceTests
    {
        [Fact]
        public void ShouldPatchMethods()
        {
            // given
            MethodInfo randomOriginalMethodInfo =
                CreateRandomMethodInfo();

            MethodInfo originalMethodInfo =
                randomOriginalMethodInfo;

            MethodInfo randomAdditionalMethodInfo =
                CreateRandomMethodInfo();

            MethodInfo additionalMethodInfo =
                randomAdditionalMethodInfo;

            MethodInfo randomPatchedMethodInfo =
                CreateRandomMethodInfo();

            // when
            this.patchService.PatchMethods(
                originalMethodInfo,
                additionalMethodInfo);

            // then

            this.patchBrokerMock.Verify(broker =>
                broker.PatchMethods(
                    originalMethodInfo,
                    additionalMethodInfo),
                        Times.Once);

            this.patchBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldUnpatchMethods()
        {
            // given . when
            this.patchService.UnpatchMethods();

            // then
            this.patchBrokerMock.Verify(broker =>
                broker.UnpatchAll(),
                    Times.Once);

            this.patchBrokerMock.VerifyNoOtherCalls();
        }
    }
}
