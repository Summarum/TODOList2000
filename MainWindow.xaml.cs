using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<ModelData> modelData;
        private ModelData todayData;
        
        public MainWindow()
        {
            
            modelData = new List<ModelData>();
            addNewDay();
            InitializeComponent();
            FileReader fr = new FileReader();
            
            fr.testtodofun();
            dp_main.SelectedDate = DateTime.Now;
            
            //Trace.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
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
        public void addNewDay() {
            
            todayData = new ModelData();


        }
        
        public void addNewRow() { 
            StackPanel tempSP = new StackPanel();
            CheckBox tempCB = new CheckBox();
            TextBlock tempTB = new TextBlock();

            ModelData tempModel = new ModelData();
            

            tempCB.Margin = new Thickness(6, 45, 0, 0);
            tempCB.Click += new RoutedEventHandler(checked_changed);
            tempCB.IsChecked = false;


            tempSP.Width = 760;
            tempSP.Height = 100;
            tempSP.Orientation = Orientation.Horizontal;
            tempSP.HorizontalAlignment = HorizontalAlignment.Stretch;
            tempSP.Background = new SolidColorBrush(Colors.DarkGray);
            
            tempTB.Background = new SolidColorBrush(Colors.Gray);
            tempTB.Width = 730;
            tempSP.Children.Add(tempTB);
            tempSP.Children.Add(tempCB);

            //todayData.TodoText.Add("cos do zrobienia");
            //todayData.TodoDate = DateOnly.FromDateTime((DateTime)dp_main.SelectedDate);
            //todayData.IsChecked.Add((bool)tempCB.IsChecked);




           
            
            
            
        }
        private void listAdd() { 
        
        
        
        }

        public void checked_changed(Object sender, EventArgs args) {
            CheckBox tmpCB = (CheckBox)sender;
            
            Trace.WriteLine("test: "+tmpCB.Uid.ToString());
        }

        
    }
}
