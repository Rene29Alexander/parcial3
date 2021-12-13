FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY bin/Release/net5.0/publish/ WebAPI/
WORKDIR /WebAPI
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAPI.dll