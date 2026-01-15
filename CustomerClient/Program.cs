// See https://aka.ms/new-console-template for more information
// try to create a resource group
using Azure.ResourceManager;
using Azure.Identity;
using AzureService;
using System.Text.Json;

var azureClient = new AzureServiceClient(new AzureCliCredential(), ArmEnvironment.AzurePublicCloud);

var response = await azureClient.GetAsync("/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/antisch-cmtest", "2020-06-01");

if (response.Content != null)
{
    Console.WriteLine(response.Content.ToString());
}
