﻿using System;
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

namespace TODOList2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
            addNewRow();
        }


        public void addNewRow() { 
            StackPanel tempSP = new StackPanel();
            RadioButton tempRadio = new RadioButton();
            TextBlock tempTB = new TextBlock();


            

            tempSP.Width = 760;
            tempSP.Height = 100;
            tempSP.Orientation = Orientation.Horizontal;
            tempSP.HorizontalAlignment = HorizontalAlignment.Stretch;
            tempSP.Background = new SolidColorBrush(Colors.DarkGray);
            
            tempTB.Background= new SolidColorBrush(Colors.Gray);
            tempTB.Width = 650;
            tempSP.Children.Add(tempTB);
            tempSP.Children.Add(tempRadio);
            
            stackp_main.Items.Add(tempSP);
        }
    }
}
