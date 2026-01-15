// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace AzureService
{
    public partial class AzureServiceClient
    {
        internal HttpMessage CreateGetPageableRequest(string requestPath, string apiVersion, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(requestPath, false);
            uri.AppendQuery("api-version", apiVersion, true);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextGetPageableRequest(Uri nextPage, string requestPath, string apiVersion, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(nextPage);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutPageableRequest(string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(requestPath, false);
            uri.AppendQuery("api-version", apiVersion, true);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Put;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateNextPutPageableRequest(Uri nextPage, string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(nextPage);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Put;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePatchPageableRequest(string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(requestPath, false);
            uri.AppendQuery("api-version", apiVersion, true);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Patch;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateNextPatchPageableRequest(Uri nextPage, string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(nextPage);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Patch;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeletePageableRequest(string requestPath, string apiVersion, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(requestPath, false);
            uri.AppendQuery("api-version", apiVersion, true);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Delete;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextDeletePageableRequest(Uri nextPage, string requestPath, string apiVersion, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(nextPage);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Delete;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePostPageableRequest(string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(requestPath, false);
            uri.AppendQuery("api-version", apiVersion, true);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateNextPostPageableRequest(Uri nextPage, string requestPath, string apiVersion, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(nextPage);
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
