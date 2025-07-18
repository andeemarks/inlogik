# Project Structure

## Solution Organization
```
mb.sln                    # Solution file containing both projects
├── mb/                   # Main console application
└── test/                 # Unit test project
```

## Main Project (`mb/`)
```
mb/
├── mb.csproj            # Project file
├── Program.cs           # Entry point with main loop
├── InputParser.cs       # Parses user input into commands
├── Command/             # Command pattern implementations
│   ├── ICommand.cs      # Command interface
│   ├── PostCommand.cs   # Handle message posting
│   ├── ReadCommand.cs   # Handle reading project messages
│   ├── FollowCommand.cs # Handle user following
│   ├── WallCommand.cs   # Handle wall display
│   └── ICommandBuilder.cs
├── Domain/              # Core business logic
│   ├── MessageBoard.cs  # Main context/state holder
│   ├── Message.cs       # Message entity
│   ├── Follow.cs        # Follow relationship
│   └── WallLine.cs      # Wall display line
└── Display/             # Output formatting
    ├── ReadResult.cs    # Format read command output
    └── WallResult.cs    # Format wall command output
```

## Test Project (`test/`)
```
test/
├── test.csproj          # Test project file
├── GlobalUsings.cs      # Global using statements for tests
├── InputParserTests.cs  # Input parsing tests
├── Command/             # Command tests (mirrors main structure)
│   ├── PostCommandTests.cs
│   ├── ReadCommandTests.cs
│   ├── FollowCommandTests.cs
│   └── WallCommandTests.cs
├── Domain/              # Domain logic tests
│   ├── MessageBoardTests.cs
│   └── MessageTests.cs
└── Display/             # Display formatting tests
    ├── ReadResultTests.cs
    └── WallResultTests.cs
```

## Architecture Patterns

### Command Pattern
- All user actions are represented as command objects implementing `ICommand`
- Commands are created by `InputParser` based on input syntax
- Commands execute against `MessageBoard` context and return updated context

### Domain-Driven Design
- Core business logic separated in `Domain/` folder
- `MessageBoard` acts as aggregate root holding all state
- Entities: `Message`, `Follow`, `WallLine`

### Test Structure
- Test project mirrors main project folder structure
- Each class has corresponding test class with `Tests` suffix
- Tests follow AAA pattern (Arrange, Act, Assert)
- Factory methods tested separately from core functionality

## Naming Conventions
- **Classes**: PascalCase (`MessageBoard`, `PostCommand`)
- **Methods**: PascalCase (`Execute`, `FromInput`)
- **Properties**: PascalCase (`UserName`, `Messages`)
- **Fields**: PascalCase for public, camelCase for private
- **Test Methods**: Descriptive names with underscores (`Command_Construction_Requires_User_Name`)

## File Organization Rules
- One class per file
- File name matches class name
- Interfaces prefixed with `I`
- Test files end with `Tests.cs`
- Group related functionality in folders (`Command/`, `Domain/`, `Display/`)