FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "Presentation/FisioSolution.Presentation.csproj" -c Release -o /FisioSolution

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /FisioSolution ./
ENV PATIENTS_JSON_PATH=/app/JSON/patients.json
ENV PHYSIOS_JSON_PATH=/app/JSON/physios.json
ENTRYPOINT ["dotnet", "FisioSolution.Presentation.dll"]