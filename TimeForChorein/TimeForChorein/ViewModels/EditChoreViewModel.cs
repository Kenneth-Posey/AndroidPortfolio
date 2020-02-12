using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.Models;
using TimeForChorein.Models.IModel;
using TimeForChorein.Views;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public partial class EditChoreViewModel : BaseViewModel
    {
        public Chore Chore { get; set; }
        public Command LoadItemCommand { get; set; }

        public EditChoreViewModel()
        {
            Chore = new Chore()
            {
                DateCreated = DateTime.Now,
                DateLastModifed = DateTime.Now
            };
        }

        public EditChoreViewModel(int? choreId)
        {
            LoadItemCommand = new Command(async () => await ExecuteLoadItemCommand(choreId));
        }

        public async Task ExecuteLoadItemCommand(int? choreId)
        {
            // wait to load the task so the data is inserted into the editor correctly
            Task<IChore> choreTask = _choreService.GetById(choreId);
            Chore = choreTask.Result as Chore;
        }
    }
}
