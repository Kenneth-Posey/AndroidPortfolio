using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeForChorein.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        SettingsPageViewModel viewModel;

        public SettingsPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new SettingsPageViewModel();
        }
    }
}