using GSCObras.Mobile.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GSCObras.Mobile.Views
{
    /// <summary>
    /// Page to show the no item
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoItemPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoItemPage" /> class.
        /// </summary>
        public NoItemPage()
        {
            this.InitializeComponent();
            this.BindingContext = NoItemPageViewModel.BindingContext;
        }
    }
}