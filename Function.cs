using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EnquiryListener;

public class Function
{
    public Casing FunctionHandler(string input, ILambdaContext context)
    {
        return new Casing(input.ToLower(), input.ToUpper());
    }
}

public record Casing(string Lower, string Upper);