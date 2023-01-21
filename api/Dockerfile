FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY Release/ app/
WORKDIR /app

COPY ./DAL/seeding/*.json /app/DAL/seeding/
COPY ./DAL/dropdownlists.xml /app/DAL/dropdownlists.xml

RUN export NODE_OPTIONS=--openssl-legacy-provider


ENTRYPOINT [ "dotnet", "api.dll" ]