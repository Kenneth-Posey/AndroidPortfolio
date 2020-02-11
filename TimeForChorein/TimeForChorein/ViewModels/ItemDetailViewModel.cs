using System;

using TimeForChorein.Models;

namespace TimeForChorein.ViewModels
{
    public class ChoreDetailViewModel : BaseViewModel
    {
        public Chore Item { get; set; }
        public ChoreDetailViewModel(Chore item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
