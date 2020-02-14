using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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

        public int? GetId()
        {
            return this.ChoreId;
        }

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
    }
}
