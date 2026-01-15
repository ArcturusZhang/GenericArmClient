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
        /// <summary>
        /// [Protocol Method] Get
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> GetPageable(string requestPath, string apiVersion, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            return new AzureServiceClientGetPageableCollectionResult(this, requestPath, apiVersion, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] Get
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> GetPageableAsync(string requestPath, string apiVersion, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            return new AzureServiceClientGetPageableAsyncCollectionResult(this, requestPath, apiVersion, options ?? new PageableOptions(), context);
        }
        /// <summary>
        /// [Protocol Method] PutPageable
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> PutPageable(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPutPageableCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] PutPageable
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> PutPageableAsync(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPutPageableAsyncCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] Patch
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> PatchPageable(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPatchCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] Patch
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> PatchPageableAsync(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPatchAsyncCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] Delete
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> DeletePageable(string requestPath, string apiVersion, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            return new AzureServiceClientDeleteCollectionResult(this, requestPath, apiVersion, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] Delete
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> DeletePageableAsync(string requestPath, string apiVersion, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            return new AzureServiceClientDeleteAsyncCollectionResult(this, requestPath, apiVersion, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] PostPageable
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> PostPageable(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPostPageableCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }

        /// <summary>
        /// [Protocol Method] PostPageable
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestPath"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requestPath"/> or <paramref name="apiVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> PostPageableAsync(string requestPath, string apiVersion, RequestContent content, PageableOptions options = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(requestPath, nameof(requestPath));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            return new AzureServiceClientPostPageableAsyncCollectionResult(this, requestPath, apiVersion, content, options ?? new PageableOptions(), context);
        }
    }
}
