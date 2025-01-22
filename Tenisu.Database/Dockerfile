FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /build
COPY Tenisu.Database.csproj ./
RUN dotnet restore 
COPY . .
RUN dotnet publish -o /publish 
WORKDIR /publish 
CMD ["sh", "-c", "dotnet Tenisu.Database.dll \"${DB_CONNECTION}\""]


