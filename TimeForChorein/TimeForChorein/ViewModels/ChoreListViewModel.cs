using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TimeForChorein.Models;
using TimeForChorein.Views;

namespace TimeForChorein.ViewModels
{
    public class ChoreListViewModel : BaseViewModel
    {
        public ObservableCollection<Chore> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ChoreListViewModel()
        {
            Title = "Chore List";
            Items = new ObservableCollection<Chore>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<EditChorePage, Chore>(this, "SaveChore", async (obj, item) =>
            {
                var newItem = item as Chore;
                newItem.DateLastModifed = DateTime.Now;
                Items.Add(newItem);
                await _choreService.Save(newItem);
            });

            MessagingCenter.Subscribe<ChoreDetailPage, Chore>(this, "DeleteChore", async (obj, item) =>
            {
                var newItem = item as Chore;
                Items.Remove(newItem);
                await _choreService.Delete(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await _choreService.GetActiveChores();
                foreach (var item in items)
                {
                    Items.Add(item as Chore);
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}