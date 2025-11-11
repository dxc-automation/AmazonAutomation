# AmazonAutomation.Tests

C# Selenium + NUnit test project automating:
- Open Amazon
- Search for "The Final Empire: Mistborn Book 1"
- Select first product with exact name
- Choose Hardcover
- Add to cart
- Verify added to cart

How to use
1. Open the solution folder in Visual Studio or run `dotnet restore`.
2. Run tests with Test Explorer or `dotnet test`.
3. Configure settings in `appsettings.json`.

Notes:
- Project uses Selenium WebDriver with ChromeDriver.
- ExtentReports is included for reporting.
- Screenshots are saved to the `Screenshots` folder on test failure.
