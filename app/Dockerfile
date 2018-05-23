# build image
FROM microsoft/aspnetcore-build:2.0 as build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore


COPY . .
RUN dotnet publish --output /out/ --configuration Release


FROM microsoft/aspnetcore:2.0
 
WORKDIR /app
COPY --from=build /out .
 
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
 
ENTRYPOINT ["dotnet", "app.dll"]