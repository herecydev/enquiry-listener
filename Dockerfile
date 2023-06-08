FROM public.ecr.aws/lambda/dotnet:7

WORKDIR /var/task

COPY "out" .

CMD [ "EnquiryListener::EnquiryListener.Function::FunctionHandler" ]