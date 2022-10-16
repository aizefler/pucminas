using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GSCObras.Mobile.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
        }

        async void OnSignIn(object sender, EventArgs e)
        {
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync().ConfigureAwait(false);
            try
            {
                try
                {
                    IAccount firstAccount = accounts.FirstOrDefault();
                    authResult = await App.PCA.AcquireTokenSilent(App.Scopes, firstAccount)
                                          .ExecuteAsync()
                                          .ConfigureAwait(false);
                }
                catch (MsalUiRequiredException)
                {
                    try
                    {
                        var builder = App.PCA.AcquireTokenInteractive(App.Scopes)
                                                                   .WithParentActivityOrWindow(App.ParentWindow);

                        // on Android and iOS, prefer to use the system browser, which does not exist on UWP
                        SystemWebViewOptions systemWebViewOptions = new SystemWebViewOptions()
                        {
                            iOSHidePrivacyPrompt = true,
                        };

                        builder.WithSystemWebViewOptions(systemWebViewOptions);
                        builder.WithUseEmbeddedWebView(false);

                        authResult = await builder.ExecuteAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex2)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await DisplayAlert("Acquire token interactive failed. See exception message for details: ", ex2.Message, "Dismiss");
                        });
                    }
                }

                if (authResult != null)
                {
                    while (accounts.Any())
                    {
                        await App.PCA.RemoveAsync(accounts.FirstOrDefault()).ConfigureAwait(false);
                        accounts = await App.PCA.GetAccountsAsync().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Authentication failed. See exception message for details: ", ex.Message, "Dismiss");
                });
            }
        }

    }
}