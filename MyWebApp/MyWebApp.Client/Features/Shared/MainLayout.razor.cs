#region Namespaces

using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyWebApp.Shared.Features.Themes;

#endregion

namespace MyWebApp.Client.Features.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        #region Protected Fields

        protected MudTheme DarkTheme = new DarkTheme();
        protected MudTheme DefaultTheme = new LightTheme();
        protected bool IsDrawerOpen = true;
        protected MudTheme Theme = new LightTheme();
        protected MudThemeProvider? ThemeProvider;

        #endregion

        #region Protected Properties
        protected bool IsDarkMode { get; set; }

        #endregion

        #region Injected Services

        [Inject]
        private NavigationManager _navigationManager { get; set; } = default!;

        #endregion

        #region Override Methods

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Note, this doesn't work as expected if server pre-rendering is enabled. As the layout is 
            // rendered with whatever default theme (or specific theme) by the server, then when the
            // client side is ready, this runs and detects the users local system preference and applies
            // the desired theme. However, if the system preference is different to the original pre-rendered
            // html then the theme is applied after a delay, resulting in a theme change after a short delay. There
            // doesn't seem to be any way to get around this until its possible to get the system preference so that
            // the pre-render theme is the same as the clients actual system preference!
            if (firstRender && ThemeProvider is not null)
            {
                // Get the user preference for dark theme...
                var isDarkMode = await ThemeProvider.GetSystemPreference();

                // Is the user preference for dark theme?
                Theme = isDarkMode ? DarkTheme : DefaultTheme;

                // Update...
                StateHasChanged();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Navigates to the user help page
        /// </summary>
        //protected void NavigateToUserHelp() => _navigationManager.NavigateTo(ClientRoutes.Help);

        /// <summary>
        /// Toggles between dark and light themes
        /// </summary>
        protected void ToggleBetweenDarkOrLightMode() => Theme = Theme == DefaultTheme ? DarkTheme : DefaultTheme;

        /// <summary>
        /// Toggles the drawer open and closed
        /// </summary>
        protected void ToggleDrawerOpenOrClosed() => IsDrawerOpen = !IsDrawerOpen;

        #endregion
    }
}
