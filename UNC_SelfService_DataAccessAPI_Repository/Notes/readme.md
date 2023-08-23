
# Entity Framework Core Migrations using Package Manager Console

Welcome to the guide on using EF Core migrations through the Package Manager Console in Visual Studio. This guide is tailored for setups where the `DbContext` classes are situated in the `UNC_SelfService_DataAccessAPI_Repository` project.

## Prerequisites

1. Ensure you've installed Entity Framework Core packages in your project, especially `Microsoft.EntityFrameworkCore.Design`.
2. Your `DbContext` classes should be in the `UNC_SelfService_DataAccessAPI_Repository` project. For this guide, we use the `UtilityDbContext` as an example.

## Basic Commands

### Creating a New Migration

To create a new migration based on your model changes:

```powershell
Add-Migration -Project UNC_SelfService_DataAccessAPI_Repository -Context UtilityDbContext -Name "MigrationName" -OutputDir "Migrations/SelfServiceDb"
```

Replace `MigrationName` with a descriptive name for your migration, e.g., `InitialCreate`.

### Applying Migrations to the Database

To execute the migration changes on your database:

```powershell
Update-Database -Project UNC_SelfService_DataAccessAPI_Repository -Context UtilityDbContext
```

### Removing a Migration

If you've added a migration but wish to reverse or remove it (provided it hasn't been applied to the database):

```powershell
Remove-Migration -Project UNC_SelfService_DataAccessAPI_Repository -Context UtilityDbContext
```

### Listing All Migrations

To view a list of all migrations and their status (indicating if they've been applied or are pending):

```powershell
Get-Migrations -Project UNC_SelfService_DataAccessAPI_Repository -Context UtilityDbContext
```

### Generating SQL Scripts

To generate a SQL script for a specified migration range:

```powershell
Script-Migration -From PreviousMigrationName -To CurrentMigrationName -Project UNC_SelfService_DataAccessAPI_Repository -Context UtilityDbContext
```

Replace `PreviousMigrationName` and `CurrentMigrationName` with appropriate migration names.

## Tips

- Always review migration scripts for any potential issues. While EF Core does its best, certain scenarios might necessitate your intervention.
- Before applying them in a production environment, test migrations on a backup or a database copy.
- Use descriptive migration names to easily remember their purpose.
- Confirm your project builds successfully as EF Core tools are dependent on a successful build.
- The `-OutputDir` (or `-o`) flag determines where the migrations files should be stored. Organize them to suit your project's structure.

## Conclusion

Migrations are a powerful feature of Entity Framework Core, helping developers manage and version database schema changes efficiently. With the Package Manager Console in Visual Studio, you can integrate migration tasks directly into your workflow.

