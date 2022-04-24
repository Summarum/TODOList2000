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

        internal List<ModelData> ModelData { get => modelData; set => modelData = value; }
        internal ModelData TodayData { get => todayData; set => todayData = value; }
        public CheckBox[] Boxes { get => boxes; set => boxes = value; }
        public DateTime? LastDatePicked { get => lastDatePicked; set => lastDatePicked = value; }

        public MainWindow()
        {

            ModelData = new List<ModelData>();

            InitializeComponent();
            fr = new FileReader();

            ModelData = fr.readFile("file.txt");
            // fr.testtodofun();



            dp_main.SelectedDate = DateTime.Now;
            //dp_main.SelectedDate.Value.AddDays(-1);
            //buildTodoUiList();

            //Trace.WriteLine(DateTime.Now.ToString("d/M/yyyy"));


        }

        public void buildTodoUiList()
        {
            if (ModelData.Count > 0)
            {
                ModelData foundModel = ModelData.Find(x => x.TodoDate.ToString("dd/MM/yyyy").Equals(dp_main.SelectedDate.Value.ToString("dd/MM/yyyy")));
                if (foundModel != null)
                {
                    Boxes = new CheckBox[foundModel.IsChecked.Count];
                    for (int i = 0; i < foundModel.TodoID.Count; i++)
                    {

                        StackPanel tempSP = new StackPanel();
                        CheckBox tempCB = new CheckBox();
                        TextBlock tempTB = new TextBlock();
                        Button remBtn = new Button();

                        Boxes.Append(tempCB);

                        tempTB.Background = new SolidColorBrush(Colors.Gray);
                        tempTB.Width = 765;
                        tempTB.Text = foundModel.TodoText[i];
                        tempTB.Uid = "" + i;

                        


                        tempCB.Margin = new Thickness(6, 45, 15, 0);
                        tempCB.Click += new RoutedEventHandler(checked_changed);
                        tempCB.IsChecked = foundModel.IsChecked[i];
                        tempCB.Uid = "" + i;



                        tempSP.Width = 800;
                        tempSP.Height = 100;
                        tempSP.Orientation = Orientation.Horizontal;
                        tempSP.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tempSP.Background = new SolidColorBrush(Colors.DarkGray);
                        tempSP.Uid = "" + i;

                        tempSP.Children.Add(tempTB);
                        tempSP.Children.Add(tempCB);
                        //tempSP.Children.Add(remBtn);
                        foundModel.TodoID[i] = i;
                        stackp_main.Items.Add(tempSP);

                    }


                }



            }
        }

        public void addNewRow()
        {
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


        public void checked_changed(Object sender, EventArgs args)
        {
            CheckBox tmpCB = (CheckBox)sender;
            ModelData foundModel = ModelData.Find(x => x.TodoDate.ToString("dd/MM/yyyy").Equals(dp_main.SelectedDate.Value.ToString("dd/MM/yyyy")));
            if(foundModel != null)
            {
                foundModel.IsChecked[int.Parse(tmpCB.Uid)] = (bool)tmpCB.IsChecked;


            }

            //Trace.WriteLine("test: " + tempStack.Children[1].ToString());
        }

        


        private void dp_changedSelectedDate(object sender, RoutedEventArgs e)
        {
            if (!(LastDatePicked == dp_main.SelectedDate))
            {
                LastDatePicked = dp_main.SelectedDate;
                Trace.WriteLine(dp_main.SelectedDate.ToString());
                stackp_main.Items.Clear();
                buildTodoUiList();

            }

        }

        private void btn_rem_click(object sender, RoutedEventArgs e)
        {
            if (stackp_main.SelectedItem != null)
            {
                StackPanel tempStack = (StackPanel)stackp_main.SelectedItem;
                ModelData foundModel = ModelData.Find(x => x.TodoDate.ToString("dd/MM/yyyy").Equals(dp_main.SelectedDate.Value.ToString("dd/MM/yyyy")));
                if (foundModel != null)
                {
                    
                    foundModel.IsChecked.RemoveAt(int.Parse(tempStack.Uid));
                    foundModel.TodoID.RemoveAt(int.Parse(tempStack.Uid));
                    foundModel.TodoText.RemoveAt(int.Parse(tempStack.Uid));
                    stackp_main.Items.Remove(tempStack);


                }


            }
        }

        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            fr.saveTodoList(ModelData, "file.txt");
        }

       

       

        private void btn_add_todo_click(object sender, RoutedEventArgs e)
        {   
            TodoAddWindow todoAddWindow = new TodoAddWindow(this);
            todoAddWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            todoAddWindow.ShowDialog();
            stackp_main.Items.Clear();
            buildTodoUiList();
        }
    }
}

