using System;
using System.Collections.Generic;
using System.Text;
using Практическая_43_Тепляков.Classes;

namespace Практическая_43_Тепляков.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Contacts vm_contacts = new VM_Contacts();

        public VM_Groups vm_groups = new VM_Groups();

        public VM_Pages() => MainWindow.init.frame.Navigate(new View.Contacts.Main(vm_contacts));

        public RealyCommand OpenContacts
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new View.Contacts.Main(vm_contacts));
                });
            }
        }

        public RealyCommand OpenGroups
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new View.Groups.Main(vm_groups));
                });
            }
        }
    }
}
