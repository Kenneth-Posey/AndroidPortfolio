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
    public partial class ChoreProgressPage : ContentPage
    {
        ChoreProgressPageViewModel viewModel;
        public ChoreProgressPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChoreProgressPageViewModel();
        }
    }
}