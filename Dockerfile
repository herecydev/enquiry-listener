FROM public.ecr.aws/lambda/dotnet:7

WORKDIR /var/task

COPY "bin" .

CMD [ "EnquiryListener::EnquiryListener.Function::FunctionHandler" ]