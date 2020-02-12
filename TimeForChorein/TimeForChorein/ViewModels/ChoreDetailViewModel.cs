using System;

using TimeForChorein.Models;
using TimeForChorein.Views;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public class ChoreDetailViewModel : BaseViewModel
    {
        public Chore Chore { get; set; }
        public ChoreDetailViewModel(Chore chore)
        {
            Chore = chore;
            Title = chore.Name;
        }
    }
}
