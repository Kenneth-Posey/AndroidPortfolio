using System;
using System.Collections.Generic;
using System.Text;

namespace TimeForChorein.Models.IModel
{
    public interface IChore : IEntity
    {
        int? GetId();
    }
}
