using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Практическая_43_Тепляков.Classes;
using Практическая_43_Тепляков.Context;
using Практическая_43_Тепляков.Models;

namespace Практическая_43_Тепляков.ViewModels
{
    public class VM_Groups : Notification
    {
        public GroupsContext groupsContext = new GroupsContext();
        
        public ObservableCollection<Groups> Groups { get; set; }

        public VM_Groups() => Groups = new ObservableCollection<Groups>();

        public RealyCommand OnAddGroups
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Groups NewGroups = new Groups();
                    Groups.Add(NewGroups);
                    groupsContext.Groups.Add(NewGroups);
                    groupsContext.SaveChanges();
                });
            }
        }
    }
}
