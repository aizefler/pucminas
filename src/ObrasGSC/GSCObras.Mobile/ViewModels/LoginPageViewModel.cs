using GSCObras.Mobile.Validators;
using GSCObras.Mobile.Validators.Rules;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GSCObras.Mobile.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClicked(object obj)
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
                        //Device.BeginInvokeOnMainThread(async () =>
                        //{
                        //    await DisplayAlert("Acquire token interactive failed. See exception message for details: ", ex2.Message, "Dismiss");
                        //});
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
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                //    await DisplayAlert("Authentication failed. See exception message for details: ", ex.Message, "Dismiss");
                //});
            }
        }
    }

        #endregion
}