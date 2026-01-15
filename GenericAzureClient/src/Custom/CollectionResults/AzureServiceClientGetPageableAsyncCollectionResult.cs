// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AzureService
{
    internal partial class AzureServiceClientGetPageableAsyncCollectionResult : AsyncPageable<BinaryData>
    {
        private readonly AzureServiceClient _client;
        private readonly string _requestPath;
        private readonly string _apiVersion;
        private readonly PageableOptions _options;
        private readonly RequestContext _context;

        /// <summary> Initializes a new instance of AzureServiceClientGetPageableAsyncCollectionResult, which is used to iterate over the pages of a collection. </summary>
        /// <param name="client"> The AzureServiceClient client used to send requests. </param>
        /// <param name="requestPath"></param>
        /// <param name="apiVersion"></param>
        /// <param name="options"></param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public AzureServiceClientGetPageableAsyncCollectionResult(AzureServiceClient client, string requestPath, string apiVersion, PageableOptions options, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _requestPath = requestPath;
            _apiVersion = apiVersion;
            _options = options;
            _context = context;
        }

        /// <summary> Gets the pages of AzureServiceClientGetPageableAsyncCollectionResult as an enumerable collection. </summary>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <returns> The pages of AzureServiceClientGetPageableAsyncCollectionResult as an enumerable collection. </returns>
        public override async IAsyncEnumerable<Page<BinaryData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(pageSizeHint, nextPage).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }
                // find the items property by the ItemsPropertyName in options
                using var document = JsonDocument.Parse(response.ContentStream);
                var itemsElement = document.RootElement.GetProperty(_options.ItemsPropertyName);
                List<BinaryData> items = new List<BinaryData>();
                foreach (var item in itemsElement.EnumerateArray())
                {
                    items.Add(new BinaryData(item.GetRawText()));
                }
                yield return Page<BinaryData>.FromValues(items, nextPage?.AbsoluteUri, response);
                // find the nextLink property
                string nextPageString = null;
                if (document.RootElement.TryGetProperty(_options.NextLinkPropertyName, out var nextLinkProperty))
                {
                    nextPageString = nextLinkProperty.GetString();
                }
                if (string.IsNullOrEmpty(nextPageString))
                {
                    yield break;
                }
                nextPage = new Uri(nextPageString);
            }
        }

        /// <summary> Get next page. </summary>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <param name="nextLink"> The next link to use for the next page of results. </param>
        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetPageableRequest(nextLink, _requestPath, _apiVersion, _context) : _client.CreateGetPageableRequest(_requestPath, _apiVersion, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("AzureServiceClient.GetPageable");
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
