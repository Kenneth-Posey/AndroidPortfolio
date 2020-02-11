using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TimeForChorein.Models.IModel;

namespace TimeForChorein.Models
{
    public class Chore : IChore
    {
        [PrimaryKey, AutoIncrement]
        public int ChoreId { get; set; }

        public Chore()
        {
           
        }

        public int GetId()
        {
            return this.ChoreId;
        }

        public ChorePriority Priority { get; set; }
        public ChoreStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModifed { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinimumMinutes { get; set; }
        public int MaximumMinutes { get; set; }
    }
}
