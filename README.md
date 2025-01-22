# Tenisu Project

## Overview

This project is a tennis application that includes multiple components such as an API, a console application, and a database. The project is structured into several directories, each serving a specific purpose.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Docker](https://www.docker.com/get-started) installed

## Running Locally

### API

1. Navigate to the `Tenisu.API` directory:
    ```sh
    cd Tenisu.API
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Run the API:
    ```sh
    dotnet run
    ```


### Database

1. Ensure that the [PlayersDB.json](http://_vscodecontentref_/2) file is located in the [Data](http://_vscodecontentref_/3) directory.

## Running Tests

1. Navigate to the [Tenisu.Tests](http://_vscodecontentref_/4) directory:
    ```sh
    cd Tenisu.Tests
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Run the tests:
    ```sh
    dotnet test
    ```

## Deployment

### Docker

1. Ensure Docker is installed and running on your machine.

2. Navigate to the root directory of the project where the [docker-compose.yml](http://_vscodecontentref_/5) file is located.

3. Build and start the Docker containers:
    ```sh
    docker-compose up --build
    ```

4. The API should now be accessible at `https://localhost:5001` 

5. The API documentation is accessible at `https://localhost:5001/swagger/index.html`

### Azure Blob Storage

1. Update the connection string for Azure Blob Storage in the `appsettings.json` file located in the [Tenisu.API](http://_vscodecontentref_/6) directory:
    ```json
    {
      "ConnectionStrings": {
        "BlobStorage": "<Your Azure Blob Storage Connection String>"
      }
    }
    ```

2. Deploy the application to your preferred cloud service (e.g., Azure, AWS, GCP).

## Additional Information





