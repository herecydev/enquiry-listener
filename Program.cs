using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.SQS;

var sqsClient = new AmazonSQSClient();
await sqsClient.SendMessageAsync(Environment.GetEnvironmentVariable("QueueUrl"), "dan test");

var handler = (APIGatewayHttpApiV2ProxyRequest request, ILambdaContext _) =>
{
    var enquiry = JsonSerializer.Deserialize<EnquiryInfo>(request.Body) ?? throw new Exception("Could not deserialize body");
    return enquiry.Email.ToUpper();
};

await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer()).Build().RunAsync();