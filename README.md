# ToDo List Application

This project is a simple yet powerful ToDo list application developed with a focus on **Test-Driven Development (TDD)** principles. By following TDD, each feature is first specified through tests, ensuring robust and reliable functionality that meets the defined requirements.

## Features

- Add, update, and delete tasks
- Mark tasks as complete or uncompleted (with safeguards against double-marking)
- Set due dates and track overdue tasks
- Filter and sort tasks based on status and priority

## Development Approach

This application was built using the **TDD approach**, meaning each feature was developed in three distinct steps:

1. **Write Tests**: Before implementing any functionality, tests were written to specify the expected behavior. This includes validation tests to ensure a task cannot be marked as complete or uncompleted more than once, as well as tests for adding, updating, and removing tasks.
   
2. **Implement Code**: The code was written to pass each of the tests, focusing on writing the minimal amount of code needed to satisfy the test conditions.

3. **Refactor**: Code was refactored to improve readability, maintainability, and efficiency without changing functionality. Additional tests were added as necessary to cover edge cases.

## Getting Started

To get started with the ToDo List application:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/edrisym/TodoApp.git
   ```

2. **Install dependencies**:
   This project requires .NET. Install dependencies by running:
   ```bash
   dotnet restore
   ```

3. **Run the tests**:
   To validate the functionality, execute all tests:
   ```bash
   dotnet test
   ```

4. **Run the application**:
   Launch the app with:
   ```bash
   dotnet run
   ```

## Project Structure

- **Domain Layer**: Defines the core entities (e.g., `TaskItem`) and includes all business logic and validation rules.
- **Tests**: All unit tests are created using xUnit and FluentAssertions to ensure the application functions as expected at every step.

## Key Technical Highlights

- **Test-Driven Development (TDD)**: Each feature is thoroughly tested before implementation, resulting in fewer bugs and a well-documented codebase.
- **xUnit & FluentAssertions**: Tests are written using xUnit with FluentAssertions for clear, readable assertions.
- **GitHub CI/CD**: Automated tests run on every push, ensuring stability and reliability.

## Contributing

If you’d like to contribute, feel free to fork the repository and submit a pull request. All contributions are welcome, especially those that add new features or improve test coverage.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
