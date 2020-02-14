using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeForChorein.Models;
using TimeForChorein.Models.IModel;
using TimeForChorein.Views;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public partial class EditChoreViewModel : BaseViewModel
    {
        private Chore _chore;
        public Chore Chore
        {
            get { return _chore; }
            set { SetProperty(ref _chore, value); }
        }

        public ICommand LoadItemCommand { private set; get; }

        public EditChoreViewModel()
        {
            Chore = new Chore()
            {
                DateCreated = DateTime.Now,
                DateLastModifed = DateTime.Now
            };

        }

        public EditChoreViewModel(Chore chore)
        {
            Chore = chore;
        }

    }
}
