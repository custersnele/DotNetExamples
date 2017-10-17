using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyActivitiesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<ActivityType> activityTypes; //kcal/kg/uur
        private List<Activity> myActivities = new List<Activity>();

        public MainWindow()
        {
            InitializeComponent();
            activitiesListBox.ItemsSource = myActivities;
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewActivityWindow newActivityWindow = new NewActivityWindow(activityTypes);
            if (newActivityWindow.ShowDialog() == true)
            {
                myActivities.Add(newActivityWindow.NewActivity);
                activitiesListBox.Items.Refresh();
                //activitiesListBox.Items.Add(newActivityWindow.NewActivity);
                //infoLabel.Content = myActivities.Count;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (weightTextBox.Text != "")
            {
                int weigth = Convert.ToInt32(weightTextBox.Text);
                int totalKCal = 0;
                foreach (Activity activity in myActivities)
                {
                    totalKCal += activity.CalculateKCal(weigth);
                }
                kCalLabel.Content = "Totaal verbruik: " + totalKCal + "kCal";
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialog.ShowDialog() == true)
            {
                activityTypes = ActivityTypeFileReader.Read(dialog.FileName);
                if (activityTypes.Count > 0)
                {
                    addActivityButton.IsEnabled = true;
                    calculateButton.IsEnabled = true;
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
