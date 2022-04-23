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
        private CheckBox[] boxes;
        private DateTime? lastDatePicked;
        FileReader fr;
        public MainWindow()
        {
            
            modelData = new List<ModelData>();
            

            InitializeComponent();
             fr = new FileReader();
    
            modelData = fr.readFile("file.txt");
           // fr.testtodofun();


            
            dp_main.SelectedDate = DateTime.Now;
            //dp_main.SelectedDate.Value.AddDays(-1);
            //buildTodoUiList();

            //Trace.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            //addNewRow();
            

        }

        public void buildTodoUiList()
        {
            if (modelData.Count > 0)
            {
                ModelData foundModel = modelData.Find(x => x.TodoDate.ToString("dd/MM/yyyy").Equals(dp_main.SelectedDate.Value.ToString("dd/MM/yyyy")));
                if (foundModel != null)
                {
                    boxes = new CheckBox[foundModel.IsChecked.Count];
                    for (int i = 0; i < foundModel.TodoID.Count; i++)
                    {

                        StackPanel tempSP = new StackPanel();
                        CheckBox tempCB = new CheckBox();
                        TextBlock tempTB = new TextBlock();
                        boxes.Append(tempCB);

                        tempTB.Background = new SolidColorBrush(Colors.Gray);
                        tempTB.Width = 730;
                        tempTB.Text = foundModel.TodoText[i];
                        tempTB.Uid = ""+i;

                        tempCB.Margin = new Thickness(6, 45, 0, 0);
                        tempCB.Click += new RoutedEventHandler(checked_changed);
                        tempCB.IsChecked = foundModel.IsChecked[i];
                        tempCB.Uid = ""+i;
                        

                        tempSP.Width = 760;
                        tempSP.Height = 100;
                        tempSP.Orientation = Orientation.Horizontal;
                        tempSP.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tempSP.Background = new SolidColorBrush(Colors.DarkGray);
                        tempSP.Uid = "" + i;

                        tempSP.Children.Add(tempTB);
                        tempSP.Children.Add(tempCB);

                        stackp_main.Items.Add(tempSP);

                    }


                }



            }
        }

        public void addNewRow() { 
            StackPanel tempSP = new StackPanel();
            CheckBox tempCB = new CheckBox();
            TextBlock tempTB = new TextBlock();

            ModelData tempModel = new ModelData();
            

            tempCB.Margin = new Thickness(6, 45, 0, 0);
            tempCB.Click += new RoutedEventHandler(checked_changed);
            //tempCB.IsChecked = modelData.;


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
     

        public void checked_changed(Object sender, EventArgs args) {
            CheckBox tmpCB = (CheckBox)sender;
            
            Trace.WriteLine("test: "+tmpCB.Uid.ToString());
        }

        private void btn_save_Copy_Click(object sender, RoutedEventArgs e)
        {
            fr.saveTodoList(modelData,"file.txt");
        }


        private void dp_changedSelectedDate(object sender, RoutedEventArgs e)
        {
            if (!(lastDatePicked == dp_main.SelectedDate)) {
                lastDatePicked = dp_main.SelectedDate;
                Trace.WriteLine(dp_main.SelectedDate.ToString());
                stackp_main.Items.Clear();
                buildTodoUiList();

            }
            
        }
    }
}
