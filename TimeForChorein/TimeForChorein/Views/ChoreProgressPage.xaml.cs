using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.Enums;
using TimeForChorein.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeForChorein.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoreProgressPage : ContentPage, INotifyPropertyChanged
    {
        ChoreProgressPageViewModel viewModel;

        public ChoreProgressPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChoreProgressPageViewModel();
        }

    }
}