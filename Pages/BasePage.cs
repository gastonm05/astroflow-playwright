using Microsoft.Playwright;

namespace AstroFlow.Tests.Pages;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public virtual async Task NavigateAsync(string url)
    {
        await Page.GotoAsync(url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded
        });
        await WaitForLoadAsync();
    }

    public virtual async Task WaitForLoadAsync()
    {
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}
