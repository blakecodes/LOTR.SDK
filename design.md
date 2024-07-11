# Lord of the Rings SDK Design

## Overview
The Lord of the Rings SDK provides a simple and efficient way to interact with the Lord of the Rings API. The SDK includes functionality to retrieve information about movies and quotes from the Lord of the Rings universe.

## Structure
The SDK is composed of three main components:
1. `ILotrSdk` Interface
2. `LotrApiClient` Class
3. `LotrSdk` Class

### 1. `ILotrSdk` Interface
The `ILotrSdk` interface defines the contract for the SDK, specifying the methods available for interacting with the API. These methods include:
- `GetMoviesAsync(int? limit = null, int? page = null, int? offset = null)`
- `GetMovieByIdAsync(string id)`
- `GetQuotesByMovieIdAsync(string movieId, int? limit = null, int? page = null, int? offset = null)`
- `GetQuotesAsync(int? limit = null, int? page = null, int? offset = null)`
- `GetQuoteByIdAsync(string id)`

### 2. `LotrApiClient` Class
The `LotrApiClient` class is responsible for making HTTP requests to the Lord of the Rings API. It handles the construction of the API endpoints and the processing of the HTTP responses.~~~~

#### Key Methods:
- `GetMoviesAsync(int? limit = null, int? page = null, int? offset = null)`
- `GetMovieByIdAsync(string id)`
- `GetQuotesByMovieIdAsync(string movieId, int? limit = null, int? page = null, int? offset = null)`
- `GetQuotesAsync(int? limit = null, int? page = null, int? offset = null)`
- `GetQuoteByIdAsync(string id)`

### 3. `LotrSdk` Class
The `LotrSdk` class implements the `ILotrSdk` interface and uses an instance of `LotrApiClient` to perform the actual API calls. This class provides a clean and easy-to-use interface for consumers of the SDK.

#### Constructor:
- `LotrSdk(string apiKey, string version = "v2")`: Initializes the SDK with the provided API key and optional API version.

## Maintainability and Extensibility
The SDK is designed with maintainability and extensibility in mind. Here are some key points:

- **Single Responsibility**: Each class has a single responsibility, making the codebase easier to understand and maintain.
- **Versioning**: The `LotrApiClient` class supports versioning of the API, allowing for future updates without breaking existing functionality.
- **Dependency Injection**: The SDK can be easily integrated into other projects using dependency injection, promoting modularity and testability.
- **Error Handling**: The `LotrApiClient` class includes robust error handling and response processing.
- **Extensibility**: New methods and endpoints can be added to the `ILotrSdk` interface and implemented in the `LotrSdk` class with minimal changes to the existing codebase.