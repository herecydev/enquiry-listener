FROM mcr.microsoft.com/dotnet/sdk:7 AS build
COPY . .
RUN dotnet publish -c Release -o /publish

FROM public.ecr.aws/lambda/dotnet:7
WORKDIR /var/task
COPY --from=build /publish .
CMD [ "enquiry-listener::enquiry_listener.Function::FunctionHandler" ]