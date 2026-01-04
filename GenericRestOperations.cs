using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericArmClient
{
    internal partial class GenericRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> Initializes a new instance of ResourcesRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public GenericRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateDeleteByIdRequestUri(string resourceId, string apiVersion)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateDeleteByIdRequest(string resourceId, string apiVersion)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Deletes a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public async Task<Response> DeleteByIdAsync(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateDeleteByIdRequest(resourceId, apiVersion);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public Response DeleteById(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateDeleteByIdRequest(resourceId, apiVersion);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateByIdRequest(string resourceId, string apiVersion, RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="data"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, <paramref name="apiVersion"/> or <paramref name="data"/> is null. </exception>
        public async Task<Response> CreateOrUpdateByIdAsync(string resourceId, string apiVersion, RequestContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="content"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, <paramref name="apiVersion"/> or <paramref name="data"/> is null. </exception>
        public Response CreateOrUpdateById(string resourceId, string apiVersion, RequestContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateByIdRequest(string resourceId, string apiVersion, RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="content"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        public async Task<Response> UpdateByIdAsync(string resourceId, string apiVersion, RequestContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateUpdateByIdRequest(resourceId, apiVersion, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="content"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, <paramref name="apiVersion"/> or <paramref name="content"/> is null. </exception>
        public Response UpdateById(string resourceId, string apiVersion, RequestContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateUpdateByIdRequest(resourceId, apiVersion, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetByIdRequest(string resourceId, string apiVersion)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public async Task<Response<BinaryData>> GetByIdAsync(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateGetByIdRequest(resourceId, apiVersion);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(BinaryData.FromStream(message.Response.ContentStream), message.Response);
                case 404:
                    return Response.FromValue((BinaryData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public Response<BinaryData> GetById(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateGetByIdRequest(resourceId, apiVersion);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(BinaryData.FromStream(message.Response.ContentStream), message.Response);
                case 404:
                    return Response.FromValue((BinaryData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListByResourceGroupNextPageRequestUri(string nextLink, string subscriptionId, string resourceGroupName, string filter, string expand, int? top)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListByResourceGroupNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string filter, string expand, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }
    }
}
