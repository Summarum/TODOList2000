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
using System.Windows.Shapes;

namespace TODOList2000
{
    /// <summary>
    /// Interaction logic for TodoAddWindow.xaml
    /// </summary>
    public partial class TodoAddWindow : Window
    {
        MainWindow mainWindow;
        public TodoAddWindow(MainWindow inputWindow)
        {
            
            InitializeComponent();
            mainWindow = inputWindow;
        }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            
            ModelData foundModel = mainWindow.ModelData.Find(x => x.TodoDate.ToString("dd/MM/yyyy").Equals(mainWindow.dp_main.SelectedDate.Value.ToString("dd/MM/yyyy")));
            if (foundModel != null)
            {

                foundModel.IsChecked.Add(false);
                foundModel.TodoID.Add(foundModel.TodoID.Count);
                foundModel.TodoText.Add(this.addTB.Text);
                


            }
            this.Close();
        }
    }
}
