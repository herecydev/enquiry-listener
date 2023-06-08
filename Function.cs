using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EnquiryListener;

public class Function
{
    public string FunctionHandler(APIGatewayHttpApiV2ProxyRequest input)
    {
        var enquiry = JsonSerializer.Deserialize<EnquiryInfo>(input.Body) ?? throw new Exception("Could not deserialize body");
        return enquiry.Email.ToUpper();
    }
}