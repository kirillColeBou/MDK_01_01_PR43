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
    public class VM_Contacts : Notification
    {
        public ContactsContext contactsContext = new ContactsContext();
        
        public ObservableCollection<Contacts> Contacts { get; set; }

        public VM_Contacts() => Contacts = new ObservableCollection<Contacts>();

        public RealyCommand OnAddContacts
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Contacts NewContacts = new Contacts();
                    Contacts.Add(NewContacts);
                    contactsContext.Contacts.Add(NewContacts);
                    contactsContext.SaveChanges();
                });
            }
        }
    }
}
