// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AzureService
{
    public partial class AzureServiceClient
    {
        public AzureServiceClient(TokenCredential credential, ArmEnvironment environment, AzureServiceClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(environment.Endpoint, nameof(environment.Endpoint));

            options ??= new AzureServiceClientOptions();

            _endpoint = environment.Endpoint;
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, new string[] { environment.DefaultScope }) });
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }
    }
}
