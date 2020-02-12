using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.Models;
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
            Chore = await _choreService.GetById(choreId) as Chore;            
        }
    }
}
