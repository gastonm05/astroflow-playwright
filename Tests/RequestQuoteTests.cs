using System.Text.RegularExpressions;
using AstroFlow.Tests.Fixtures;
using AstroFlow.Tests.Models;
using AstroFlow.Tests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace AstroFlow.Tests.Tests;

[TestFixture]
public class RequestQuoteTests : PlaywrightFixture
{
    private const string BaseUrl = "https://astroflow.wingflows.com/";

    [Test]
    public async Task Should_Submit_Request_Quote_Form_Successfully()
    {
        var homePage = new HomePage(Page);
        var formData = new RfqFormData();

        await homePage.NavigateAsync(BaseUrl);

        var rfqPage = await homePage.ClickRequestQuoteAsync();

        await Microsoft.Playwright.Assertions.Expect(Page).ToHaveURLAsync(new Regex(".*/rfq", RegexOptions.IgnoreCase));

        await rfqPage.FillRequiredFieldsAsync(formData);
        await rfqPage.SubmitAsync();
        rfqPage.AssertSuccessMessage();
    }
}
