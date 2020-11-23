# What Is This?
This is a small example of a potential bug(?) in the new EF Core Table-per-Type feature. Problems are described in Program.cs as comments

# Getting Started

## Requirements
* .NET Core SDK 3.1+
* PostgreSQL

```sh
# Clone the repository
git clone https://github.com/keenjus/EFCore5TPTBug

# Go in to the root of the project
cd EFCore5TPTBug

# Restore tools and nugets
dotnet restore
dotnet tool restore

# Go directly into the console project folder in order for dotnet-ef commands to work
cd EFCore5TPTBug

# Try to update the database
dotnet ef database update
```
