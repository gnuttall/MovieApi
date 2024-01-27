Requires most recent version of .NET 8 EF CLI tool
to update run:

'dotnet tool update --global dotnet-ef'

Configure sqlConnectionString to point to SQL Database
Then run:

'dotnet ef database update --project MovieApi.Data --startup-project MovieApi.Api'

There is an endpoint to upload the CSV from **https://www.kaggle.com/datasets/disham993/9000-movies-dataset**
Into the database

