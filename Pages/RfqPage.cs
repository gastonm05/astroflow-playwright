using AstroFlow.Tests.Models;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AstroFlow.Tests.Pages;

public class RfqPage : BasePage
{
    private string _dialogMessage = string.Empty;

    public RfqPage(IPage page) : base(page)
    {
    }

    public async Task<RfqPage> FillContactInformationAsync(RfqFormData data)
    {
        await Page.GetByLabel("First Name").FillAsync(data.FirstName);
        await Page.GetByLabel("Last Name").FillAsync(data.LastName);
        await Page.GetByLabel("Email Address").FillAsync(data.Email);
        await Page.GetByLabel("Phone Number").FillAsync(data.Phone);
        return this;
    }

    public async Task<RfqPage> FillCompanyInformationAsync(RfqFormData data)
    {
        await Page.GetByLabel("Company Name").FillAsync(data.CompanyName);
        await Page.GetByLabel("Industry").SelectOptionAsync(MapIndustryValue(data.Industry));
        return this;
    }

    public async Task<RfqPage> FillServiceRequirementsAsync(RfqFormData data)
    {
        foreach (var service in data.Services)
        {
            await Page.GetByRole(AriaRole.Checkbox, new() { Name = service }).ClickAsync();
        }

        await Page.GetByLabel("Timeline").SelectOptionAsync(MapTimelineValue(data.Timeline));
        await Page.GetByLabel("Project Details").FillAsync(data.ProjectDetails);
        return this;
    }

    public async Task<RfqPage> FillRequiredFieldsAsync(RfqFormData data)
    {
        await FillContactInformationAsync(data);
        await FillCompanyInformationAsync(data);
        await FillServiceRequirementsAsync(data);
        return this;
    }

    public async Task<RfqPage> SubmitAsync()
    {
        _dialogMessage = string.Empty;

        Page.Dialog += (_, dialog) =>
        {
            _dialogMessage = dialog.Message;
            _ = dialog.AcceptAsync();
        };

        var submitButton = Page.GetByRole(AriaRole.Button, new() { Name = "Submit Request" });
        await submitButton.ClickAsync();
        return this;
    }

    public void AssertSuccessMessage()
    {
        Assert.That(_dialogMessage, Does.Contain("Thank you for your request"));
    }

    private static string MapIndustryValue(string industry)
    {
        return industry switch
        {
            "Technology & Electronics" => "technology",
            "E-Commerce & Retail" => "ecommerce",
            _ => industry
        };
    }

    private static string MapTimelineValue(string timeline)
    {
        return timeline switch
        {
            "1-3 months" => "1-3-months",
            "Immediate (Within 1 month)" => "immediate",
            _ => timeline
        };
    }
}
