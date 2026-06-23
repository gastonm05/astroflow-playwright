using Microsoft.Playwright;
using NUnit.Framework;

namespace AstroFlow.Tests.Fixtures;

public abstract class PlaywrightFixture
{
    protected IPlaywright Playwright { get; private set; } = default!;
    protected IBrowser Browser { get; private set; } = default!;
    protected IBrowserContext BrowserContext { get; private set; } = default!;
    protected IPage Page { get; private set; } = default!;

    [SetUp]
    public async Task SetUpAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1440,
                Height = 900
            }
        });

        Page = await BrowserContext.NewPageAsync();
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        if (BrowserContext is not null)
        {
            await BrowserContext.CloseAsync();
        }

        if (Browser is not null)
        {
            await Browser.CloseAsync();
        }

        Playwright?.Dispose();
    }
}
