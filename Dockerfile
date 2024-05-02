FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "Presentation/FisioSolution.Presentation.csproj" -c Release -o /FisioSolution

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /FisioSolution
COPY --from=build /FisioSolution ./
ENTRYPOINT ["dotnet", "FisioSolution.Presentation.dll"]