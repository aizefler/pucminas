using GSCObras.Mobile.ViewModels.About;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GSCObras.Mobile.Views
{
    /// <summary>
    /// About us simple page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SobrePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GSCObras.Mobile.Views.SobrePage"/> class.
        /// </summary>
        public SobrePage()
        {
            this.InitializeComponent();
            this.BindingContext = AboutUsViewModel.BindingContext;
        }
    }
}