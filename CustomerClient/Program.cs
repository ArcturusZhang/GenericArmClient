// See https://aka.ms/new-console-template for more information
// try to create a resource group
using Azure.ResourceManager;
using Azure.Identity;
using AzureService;
using System.Text.Json;

var azureClient = new AzureServiceClient(new AzureCliCredential(), ArmEnvironment.AzurePublicCloud);

var getResponse = await azureClient.GetAsync("/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/antisch-cmtest", "2020-06-01");

if (getResponse.Content != null)
{
    Console.WriteLine(getResponse.Content.ToString());
}

var listResponse = azureClient.GetPageableAsync("/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups", "2020-06-01");

await foreach (var item in listResponse)
{
    Console.WriteLine(item.ToString());
}
