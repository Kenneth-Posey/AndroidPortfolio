using System;

using TimeForChorein.Models;
using TimeForChorein.Views;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public class ChoreDetailViewModel : BaseViewModel
    {
        private Chore _chore;
        public Chore Chore
        {
            get { return _chore; }
            set { SetProperty(ref _chore, value); }
        }

        public ChoreDetailViewModel(Chore chore)
        {
            Chore = chore;
            Title = chore.Name;
        }
    }
}
