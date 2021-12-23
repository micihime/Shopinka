The project consists of:
- REST API service providing all available products and enabling of the partial update of one product
- swagger documentation
- unit tests for the endpoints

How to set up:
0. create ShopinkaDB on local SQL Server (empty)
1. open .sln in Visual Studio
2. ensure that the project Shopinka.API is set as startup project
3. go to Package Manager Console
4. switch to Shopinka.Data in the Package Manager console (default is Shopinka.API)
5. run command update-database (DB tables are created, initial data is seeded)
6. run the project