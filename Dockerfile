FROM public.ecr.aws/lambda/dotnet:7

WORKDIR /var/task

COPY "bin" .

CMD [ "enquiry-listener::enquiry_listener.Function::FunctionHandler" ]