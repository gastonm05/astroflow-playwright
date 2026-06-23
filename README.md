# AstroFlow Playwright .NET UI Tests

UI test automation suite for the AstroFlow website using C#, NUnit, and Playwright.

## Prerequisites

- .NET SDK 8.0+
- PowerShell (for Playwright browser installation script)

## Installation

1. Navigate to the project folder:
   - `cd astroflow-playwright`
2. Restore dependencies:
   - `dotnet restore`
3. Build the test project:
   - `dotnet build`
4. Install Playwright Chromium:
   - `pwsh bin/Debug/net8.0/playwright.ps1 install chromium`

## Run Tests Locally

- `dotnet test`

## Run in Headed Mode

Update `Fixtures/PlaywrightFixture.cs` to set `Headless = false`, then run:

- `dotnet test`

## Open Test Report

Run tests with TRX output and open the generated results file:

- `dotnet test --logger "trx;LogFileName=test-results.trx" --results-directory test-results`

The result file is generated under `test-results`.

## Project Structure

- `.github/workflows/playwright.yml`: CI pipeline for restore, build, browser install, and test execution.
- `Fixtures/PlaywrightFixture.cs`: Shared NUnit setup/teardown for Playwright lifecycle.
- `Pages/BasePage.cs`: Common page behavior and load synchronization.
- `Pages/HomePage.cs`: Home page actions (RFQ navigation).
- `Pages/RfqPage.cs`: RFQ form interactions and submission assertions.
- `Models/RfqFormData.cs`: Typed form data model.
- `Tests/RequestQuoteTests.cs`: End-to-end RFQ submission test.
- `AstroFlow.Tests.csproj`: .NET test project definition and package dependencies.

## Design Decisions

- POM keeps UI interactions encapsulated and maintainable as the app evolves.
- Fixture-based setup centralizes browser/page lifecycle and avoids duplicated boilerplate in tests.
- Playwright-native locators (`GetByRole`, `GetByLabel`, `GetByText`) improve readability and resilience versus brittle selectors.
- Fluent RFQ page methods (`Task<RfqPage>`) keep test flow concise without coupling tests to low-level page details.
