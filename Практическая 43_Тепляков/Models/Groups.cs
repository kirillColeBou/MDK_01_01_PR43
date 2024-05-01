﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using Практическая_43_Тепляков.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace Практическая_43_Тепляков.Models
{
    public class Groups : Notification
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,255}$");
                if (!match.Success) MessageBox.Show("Название группы не должно быть пустым, и не более 255 символов!", "Не корректный ввод названия группы.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                Match match = Regex.Match(value, "^.{1,1000}$");
                if (!match.Success) MessageBox.Show("Описание группы не должно быть пустым, и не более 1000 символов!", "Не корректный ввод описания группы.");
                else
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
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
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_groups.groupsContext.SaveChanges();
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
                    if (MessageBox.Show("Вы уверены, что хотите удалить группу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_groups.Groups.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_groups.groupsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_groups.groupsContext.SaveChanges();
                    }
                });
            }
        }
    }
}
