using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using Практическая_43_Тепляков.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace Практическая_43_Тепляков.Models
{
    public class Contacts : Notification
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success) MessageBox.Show("Имя не должно быть пустым, и не более 50 символов!", "Не корректный ввод имени.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success) MessageBox.Show("Фамилия не должна быть пустой, и не более 50 символов!", "Не корректный ввод фамилии.");
                else
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set
            {
                Match match = Regex.Match(value, "^.{1,20}$");
                if (!match.Success) MessageBox.Show("Номер телефона не должен быть пустым, и не более 20 символов!", "Не корректный ввод номера телефона.");
                else
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                Match match = Regex.Match(value, "^.{1,255}$");
                if (!match.Success) MessageBox.Show("Электронная почта не должна быть пустой, и не более 255 символов!", "Не корректный ввод электронной почты.");
                else
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                Match match = Regex.Match(value, "^.{1,255}$");
                if (!match.Success) MessageBox.Show("Адрес не должен быть пустым, и не более 255 символов!", "Не корректный ввод адреса.");
                else
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private int groupsId;

        public int GroupsId
        {
            get { return groupsId; }
            set
            {
                groupsId = value;
                OnPropertyChanged("GroupsId");
            }
        }

        [Schema.NotMapped]
        private bool isEnable;

        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }

        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_contacts.contactsContext.SaveChanges();
                });
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить контакт?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_contacts.Contacts.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_contacts.contactsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_contacts.contactsContext.SaveChanges();
                    }
                });
            }
        }

        [Schema.NotMapped]
        public ObservableCollection<Groups> Groups
        {
            get
            {
                return new ObservableCollection<Groups>(new Context.GroupsContext().Groups);
            }
        }
    }
}
