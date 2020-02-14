using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using TimeForChorein.Enums;
using TimeForChorein.Models.IModel;

namespace TimeForChorein.Models
{
    public class Chore : IChore
    {
        [PrimaryKey, AutoIncrement]
        public int? ChoreId { get; set; }

        public Chore()
        {
           
        }

        public Chore(Chore seedChore)
        {
            if (!string.IsNullOrWhiteSpace(seedChore?.Description))
                this.Description = seedChore.Description;

            if (!string.IsNullOrWhiteSpace(seedChore?.Name))
                this.Name = seedChore.Name;

            this.ChorePriority = seedChore.ChorePriority;
            this.ChoreStatus = seedChore.ChoreStatus;
            this.DateCreated = DateTime.Now;
            this.DateLastModifed = DateTime.Now;
            this.Minutes = seedChore.Minutes;
            this.Repeatable = seedChore.Repeatable;
        }

        public int? GetId()
        {
            return this.ChoreId;
        }

        // magic glue to store enums in sqllite
        [Required]
        public virtual int ChorePriorityId
        {
            get
            {
                return (int)this.ChorePriority;
            }
            set
            {
                ChorePriority = (ChorePriority)value;
            }
        }
        [EnumDataType(typeof(ChorePriority))]
        public ChorePriority ChorePriority { get; set; }

        // magic glue to store enums in sqllite
        [Required]
        public virtual int ChoreStatusId
        {
            get
            {
                return (int)this.ChoreStatus;
            }
            set
            {
                ChoreStatus = (ChoreStatus)value;
            }
        }
        [EnumDataType(typeof(ChoreStatus))]
        public ChoreStatus ChoreStatus { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateLastModifed { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public bool Repeatable { get; set; }
    }
}
