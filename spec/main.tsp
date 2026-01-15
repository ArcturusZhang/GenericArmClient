import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using Http;
using Azure.ClientGenerator.Core;

@useAuth(AADToken)
@service(#{ title: "Generic Azure Client" })
@server(
  "{endpoint}",
  "Generic Azure APIs",
  {
    endpoint: url,
  }
)
namespace AzureService;

@doc("The Azure Active Directory OAuth2 Flow")
model AADToken
  is OAuth2Auth<[
    {
      type: OAuth2FlowType.implicit;
      authorizationUrl: "https://login.microsoftonline.com/common/oauth2/authorize";
      tokenUrl: "https://login.microsoftonline.com/common/oauth2/token";
      scopes: ["https://management.azure.com/.default"];
    }
  ]>;

@get
@convenientAPI(false)
op get(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
): unknown;

@put
@convenientAPI(false)
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
@convenientAPI(false)
op delete(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
): unknown;

@post
@convenientAPI(false)
op post(
  @path(#{ allowReserved: true }) requestPath: string,
  @query("api-version") apiVersion: string,
  @body body: unknown,
): unknown;
