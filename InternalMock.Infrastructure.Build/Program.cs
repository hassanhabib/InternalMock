// ---------------------------------------------------------------
// Copyright (c) Hassan Habib, Ricardo Cruz, Mabrouk Mahdhi
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var adotnetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = ".Net",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "master" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Check Out"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setup Dot Net Version",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "6.0.*"
                    }
                },

                new RestoreTask
                {
                    Name = "Restore"
                },

                new DotNetBuildTask
                {
                    Name = "Build"
                },

                new TestTask
                {
                    Name = "Test"
                }
            }
        }
    }
};

adotnetClient.SerializeAndWriteToFile(githubPipeline, "../../../../.github/workflows/dotnet.yml");