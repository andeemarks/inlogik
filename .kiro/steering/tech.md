# Technology Stack

## Framework & Runtime
- **.NET 8.0** - Console application (note: originally intended for .NET 6.0 but upgraded due to Ubuntu compatibility)
- **C#** with nullable reference types enabled
- **Implicit usings** enabled for cleaner code

## Testing Framework
- **MSTest** - Microsoft's testing framework
- **MSTest.TestAdapter** and **MSTest.TestFramework** v3.0.4
- **Microsoft.NET.Test.Sdk** v17.6.0
- **Coverlet.collector** v6.0.0 for code coverage

## Project Structure
- **Solution file**: `mb.sln` with two projects
- **Main project**: `mb/mb.csproj` (console executable)
- **Test project**: `test/test.csproj` (test library with project reference to main)

## Common Commands

### Build & Run
```bash
# Build solution
dotnet build

# Run main application
dotnet run --project mb

# Run with specific input
echo "Alice -> @ProjectName Hello world" | dotnet run --project mb
```

### Testing
```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "ClassName=PostCommandTests"
```

### Development
```bash
# Restore packages
dotnet restore

# Clean build artifacts
dotnet clean

# Watch mode for continuous testing
dotnet watch test --project test
```

## Development Approach
- **Test-Driven Development (TDD)** - All features built with tests first
- **Stateless design** - Most code is stateless to support easier testing
- **Command pattern** - Input parsing creates command objects that execute against context