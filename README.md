# FlightSystem

The application is developed on the .NET Framework 4.6.1 platform, with use of the MSSQL Server and ORM Dapper database. Dapper has been chosen because of fast control and speed of performance of queries.

The project consists of several parts:
1) FlightSystem.Business  - services and business logic
2) FlightSystem.Data - domain model and repositories
3) FlightSystem.Database - database schema and test data
4) FlightSystem.Web - web-app
5) FlightSystem.Web.Test - unit tests

How to use:
1) Create new database
2) Publish db schema from FlightSystem.Database project
3) Execute script with Test data (FlightSystem.Database/Text/TestData.sql)
4) Set FlightSystem.Web as Setup project
5) Update <connectionStrings> in web.config
6) Run solution
