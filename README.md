![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=sk0n0va_restcountries.client&metric=alert_status)

# .NET 6 Web API Project

The .NET 6 Web API project is a validation application tailored to interact with the public API from [Restcountries](https://restcountries.com/v3.1/all). This application fetches data in JSON format, enabling users to access information about different countries seamlessly. With an added advantage of filtering, sorting, and pagination functionalities, users can efficiently consume data according to their requirements, ensuring they retrieve only the necessary data in specific quantities.

This project was crafted with a vision to streamline the development process, measuring the development increments. With integration to unit tests using xUnit, it assures the quality and functionality of the code. By leveraging the capabilities of Net6 Web API, the application stands robust and scalable, providing a reliable platform for users to gather country-specific data.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Running the Tests](#running-the-tests)
- [SonarCloud Integration](#sonarcloud-integration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Getting Started

### Prerequisites

- .NET 6 SDK: You can download it from [here](https://dotnet.microsoft.com/download/dotnet/6.0).
- A suitable IDE (e.g., Visual Studio 2022, Visual Studio Code with C# extension, etc.).

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/sk0n0va/restcountries.client.git
   ```
2. Navigate to the project directory:
   ```bash
   cd restcountries.client
   ```
3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
4. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```
   
## Running the Tests

To execute the unit tests, navigate to the project directory and run:
```bash
dotnet test
```

## Usage Examples

The `CountriesController` endpoint provides a variety of functionalities for fetching country data. Below are some example usage scenarios:

1. **Fetch All Countries (Default 15 Results)**
	GET /api/countries

2. **Fetch 5 Countries**
	GET /api/countries?limit=5

3. **Search Countries with Common Name "India"**
	GET /api/countries?filterType=1&query=India

4. **Sort Countries by Common Name in Ascending Order**
	GET /api/countries?sort=acsend

5. **Sort Countries by Common Name in Descending Order**
	GET /api/countries?sort=descend

6. **Search countries India, Indonesia**
	GET /api/countries?filterType=1&query=in

7. **Fetch Countries with Population Less Than 1 Million**
	GET /api/countries?filterType=2&query=1
	
8. **Fetch Countries with Population Less Than 1 Millionand sort in Descending Order**
	GET /api/countries?filterType=2&query=1&sort=descend
	
9. **Fetch only 5 Countries with Population Less Than 1 Millionand sort in Descending Order**
	GET /api/countries?filterType=2&query=1&sort=descend&limit=5

10. **Find Countries by part of the Common Name with a Limit of 2 Results**
	GET /api/countries?filterType=1&query=in&limit=2


## Contact

For any queries or issues, please open an issue on the GitHub repository or contact the project owner.
