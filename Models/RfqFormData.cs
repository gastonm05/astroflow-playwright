namespace AstroFlow.Tests.Models;

public record RfqFormData
{
    public string FirstName { get; init; } = "Jane";
    public string LastName { get; init; } = "Doe";
    public string Email { get; init; } = "jane.doe@testcorp.com";
    public string Phone { get; init; } = "+1-555-0100";
    public string CompanyName { get; init; } = "TestCorp LLC";
    public string Industry { get; init; } = "Technology & Electronics";
    public string[] Services { get; init; } = ["Warehousing & Storage", "Transportation & Distribution"];
    public string Timeline { get; init; } = "1-3 months";
    public string ProjectDetails { get; init; } = "Scalable warehousing solution for Q3 electronics launch.";
}
