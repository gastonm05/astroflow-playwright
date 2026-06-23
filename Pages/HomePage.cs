using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace AstroFlow.Tests.Pages;

public class HomePage : BasePage
{
    public HomePage(IPage page) : base(page)
    {
    }

    public async Task<RfqPage> ClickRequestQuoteAsync()
    {
        var requestQuoteLink = Page.GetByRole(AriaRole.Link, new()
        {
            NameRegex = new Regex("request.*quote", RegexOptions.IgnoreCase)
        }).First;

        await requestQuoteLink.ClickAsync();
        await Page.WaitForURLAsync("**/rfq");

        return new RfqPage(Page);
    }
}
