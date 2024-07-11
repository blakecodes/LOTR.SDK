# Lord of the Rings SDK

## Overview

The Lord of the Rings SDK provides a simple and intuitive interface for accessing the Lord of the Rings API. It supports fetching movies and quotes with pagination.

## Installation

### Using NuGet Package Manager (hypothetical if we published it)

To install the SDK using NuGet Package Manager:

```bash
Install-Package LOTR.SDK
```

Or via .NET CLI:

```bash
dotnet add package LOTR.SDK
```

### Downloading the Repository

To download the repository and reference the project directly:

1. Clone the repository:

    ```bash
    git clone https://github.com/blakecodes/lotr-sdk.git
    ```

2. Navigate to the project directory:

    ```bash
    cd lotr-sdk
    ```

3. Open your existing solution in your IDE and add the `LOTR.SDK` project:

    - In Visual Studio:
        1. Right-click on your solution in the Solution Explorer.
        2. Select "Add" > "Existing Project".
        3. Navigate to the `LOTR.SDK` directory and select `LOTR.SDK.csproj`.

4. Add a project reference to `LOTR.SDK` in your main project:

    - In Visual Studio:
        1. Right-click on your main project in the Solution Explorer.
        2. Select "Add" > "Reference".
        3. Check the `LOTR.SDK` project and click "OK".

### Configuration

To use the SDK, you need an API key. Follow these steps to set up the SDK:

1. **Instantiate the `LotrSdk`**:
    ```csharp
    var apiKey = "your-api-key";
    var sdk = new LotrSdk(apiKey);
    ```

## Usage

Here are some examples of how to call the different endpoints using the SDK:

### Get Movies

To get a list of movies with optional pagination parameters:

```csharp
var moviesResponse = await sdk.GetMoviesAsync(limit: 10, page: 1);
if (moviesResponse != null && moviesResponse.Docs != null)
{
    foreach (var movie in moviesResponse.Docs)
    {
        Console.WriteLine(movie.Name);
    }
}
```

### Get Movie by ID

To get a specific movie by its ID:

```csharp
var movieResponse = await sdk.GetMovieByIdAsync("movie-id");
if (movieResponse != null)
{
    var movie = movieResponse.Docs?.FirstOrDefault();
    if (movie != null)
    {
        Console.WriteLine(movie.Name);
    }
}
```

### Get Quotes by Movie ID

To get quotes for a specific movie with optional pagination parameters:

```csharp
var quotesResponse = await sdk.GetQuotesByMovieIdAsync("movie-id", limit: 10, page: 1);
if (quotesResponse != null && quotesResponse.Docs != null)
{
    foreach (var quote in quotesResponse.Docs)
    {
        Console.WriteLine(quote.Dialog);
    }
}
```

### Get Quotes

To get a list of quotes with optional pagination parameters:

```csharp
var quotesResponse = await sdk.GetQuotesAsync(limit: 10, page: 1);
if (quotesResponse != null && quotesResponse.Docs != null)
{
    foreach (var quote in quotesResponse.Docs)
    {
        Console.WriteLine(quote.Dialog);
    }
}
```

### Get Quote by ID

To get a specific quote by its ID:

```csharp
var quoteResponse = await sdk.GetQuoteByIdAsync("quote-id");
if (quoteResponse != null)
{
    var quote = quoteResponse.Docs?.FirstOrDefault();
    if (quote != null)
    {
        Console.WriteLine(quote.Dialog);
    }
}
```

## Error Handling

The SDK throws exceptions when an error occurs. Use try-catch blocks to handle errors:

```csharp
try
{
    var moviesResponse = await sdk.GetMoviesAsync(limit: 10, page: 1);
    // Process the response
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
```

## Conclusion

This SDK simplifies accessing the Lord of the Rings API, providing methods to fetch movies and quotes with support for pagination. Configure your API key, instantiate the SDK, and start making API calls easily.