using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericArmClient
{
    public class GenericArmResource : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly GenericRestOperations _genericRestOperations;

        public GenericArmResource(ArmClient client) : base(client, ResourceIdentifier.Root)
        {
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Id.ResourceType.Namespace, Diagnostics);
            _genericRestOperations = new(Pipeline, Diagnostics.ApplicationId, Endpoint);
        }

        public async Task<Response> CreateOrUpdateAsync(string requestPath, RequestContent content, string apiVersion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericArmResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _genericRestOperations.CreateOrUpdateByIdAsync(requestPath, apiVersion, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response CreateOrUpdate(string requestPath, RequestContent content, string apiVersion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericArmResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _genericRestOperations.CreateOrUpdateById(requestPath, apiVersion, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<BinaryData>> GetAsync(string requestPath, string apiVersion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericArmResource.Get");
            scope.Start();
            try
            {
                var response = await _genericRestOperations.GetByIdAsync(requestPath, apiVersion, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<BinaryData> Get(string requestPath, string apiVersion, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericArmResource.Get");
            scope.Start();
            try
            {
                var response = _genericRestOperations.GetById(requestPath, apiVersion, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
