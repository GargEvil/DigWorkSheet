using DigWorkSheet.MobileUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DigWorkSheet.MobileUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}