# Tenisu Project

## Overview

This project is a tennis API. The project is structured into several directories, each serving a specific purpose.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Docker](https://www.docker.com/get-started) installed

## Running Locally

### API

1. Navigate to the `Tenisu.API` directory:
    ```sh
    cd Tenisu.API
    ```

2. Update the `appsettings.Development.json` file with the correct connection string to your local database.

3. Restore the dependencies:
    ```sh
    dotnet restore
    ```

4. Run the API:
    ```sh
    dotnet run
    ```



## Running Tests

1. Navigate to the [Tenisu.Tests](https://github.com/fayssal-az/tenisu/tree/dev/Tenisu.Tests) directory:
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

## Deploy locally

### Docker

1. Ensure Docker is installed and running on your machine.

2. Navigate to the root directory of the project where the [docker-compose.yml](https://github.com/fayssal-az/tenisu/blob/dev/docker-compose.yml) file is located.

3. Build and start the Docker containers:
    ```sh
    docker-compose up --build
    ```

4. The API should now be accessible at `https://localhost:5001` 

5. The API documentation is accessible at `https://localhost:5001/swagger/index.html`


## Additional Information

## Enhancements

Enhancements to consider:

1. Public properties in the entities like Player should be made public with private set.

2. The `ComputeRatio()` method is virtual to allow mocking in tests, but ideally, it might have been better to create a `IPlayer` interface.

3. Use a key vault to store the database connection information or a managed identity

4. It is also preferable to use DTOs when retrieving data from the database.

5. The deployment is not included in this part. Nevertheless, we can use Azure Container Instances to deploy the dockerized app into the cloud



