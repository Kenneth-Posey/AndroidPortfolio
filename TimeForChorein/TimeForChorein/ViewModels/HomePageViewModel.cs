using System;
using System.Collections.Generic;
using System.Text;

namespace TimeForChorein.ViewModels
{
    public class HomePageViewModel: BaseViewModel
    {
        public string AddChoreText { get; set; } = "Add New Chore";
        public string ChoreListText { get; set; } = "View Chore List";
        public string StartChoreText { get; set; } = "Time for Chorin'";

        public HomePageViewModel()
        {
            Title = "Home";
        }
    }
}
