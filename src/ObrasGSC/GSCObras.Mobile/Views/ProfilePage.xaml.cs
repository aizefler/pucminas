using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GSCObras.Mobile.Views
{
    /// <summary>
    /// Page to show chat profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage" /> class.
        /// </summary>
        public ProfilePage()
        {
            this.InitializeComponent();
            this.ProfileImage.Source = App.ImageServerPath + "ProfileImage11.png";
        }
    }
}