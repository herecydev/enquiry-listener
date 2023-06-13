using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.SQS;

var sqsClient = new AmazonSQSClient();

var handler = async (APIGatewayHttpApiV2ProxyRequest request, ILambdaContext _) =>
{
    var enquiry = JsonSerializer.Deserialize<EnquiryInfo>(request.Body) ?? throw new Exception("Could not deserialize body");
    await sqsClient.SendMessageAsync(Environment.GetEnvironmentVariable("QueueUrl"), request.Body);
};

await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer()).Build().RunAsync();