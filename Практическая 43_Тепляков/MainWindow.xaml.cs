﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_43_Тепляков
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public View.Contacts.Main MainContacts = new View.Contacts.Main();
        public View.Groups.Main MainGroups = new View.Groups.Main();

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            frame.Navigate(MainContacts);
        }

        private void OpenContacts(object sender, MouseButtonEventArgs e) => frame.Navigate(MainContacts);

        private void OpenGroups(object sender, MouseButtonEventArgs e) => frame.Navigate(MainGroups);
    }
}
