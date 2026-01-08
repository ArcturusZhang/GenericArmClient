import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using Http;
using Rest;
using Versioning;
using Azure.Core;
using Azure.ClientGenerator.Core;

@useAuth(ApiKeyAuth<ApiKeyLocation.header, "api-key"> | OAuth2Auth<[]>)
@service(#{ title: "Generic Azure Client" })
@server(
  "{endpoint}",
  "Generic Azure APIs",
  {
    endpoint: url,
  }
)
namespace AzureService;

@get
op get(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
): unknown;

@put
op put(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
  @body body: unknown,
): unknown;

@patch(#{ implicitOptionality: false })
@convenientAPI(false)
op patch(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
  @body body: unknown,
): unknown;

@delete
op delete(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
): unknown;

@post
op post(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
  @body body: unknown,
): unknown;
