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
using System.Windows.Threading;

namespace MyActivitiesApp
{
    /// <summary>
    /// Interaction logic for NewActivityWindow.xaml
    /// </summary>
    public partial class NewActivityWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private bool counting = false;
        private int timePassed;
        private IList<ActivityType> activityTypes;
        private Activity newActivity;

        public Activity NewActivity
        {
            get { return newActivity; }
        }


        public NewActivityWindow(IList<ActivityType> activityTypes)
        {
            InitializeComponent();
            this.activityTypes = activityTypes;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            activityTypeComboBox.ItemsSource = activityTypes;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timePassed++;
            int hours, mins, secs;
            ConvertToHoursMinsSecs(timePassed, out hours, out mins, out secs);
            timePassedLabel.Content = String.Format("{0:d2}:{1:d2}:{2:d2}", hours, mins, secs);
        }

        private void startStopActivityButton_Click(object sender, RoutedEventArgs e)
        {
            if (counting)
            {
                startStopActivityButton.Content = "Start";
                startStopActivityButton.IsEnabled = false;
                timer.Stop();
                int hours, mins, secs;
                ConvertToHoursMinsSecs(timePassed, out hours, out mins, out secs);
                durationTextBox.Text = String.Format("{0:d2}:{1:d2}:{2:d2}", hours, mins, secs);
            }
            else
            {
                startStopActivityButton.Content = "Stop";
                timer.Start();
                timePassed = 0;
            }
            counting = !counting;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
            if (IsSportActivity()) {
                newActivity = new SportActivity();
                ((SportActivity)newActivity).AveragHeartRate = Convert.ToInt32(heartRateTextBox.Text);
            } else
            {
                newActivity = new Activity();
            }
            newActivity.ActivityType = (ActivityType) activityTypeComboBox.SelectedItem;
            newActivity.Duration = TimeSpan.Parse(durationTextBox.Text);

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ConvertToHoursMinsSecs(int totalSeconds, out int hours, out int min, out int secs)
        {
            hours = totalSeconds / 3600;
            totalSeconds = totalSeconds % 3600;
            min = totalSeconds / 60;
            secs = totalSeconds % 60;
        }

        private void ShowSportActivityFields()
        {
            heartRateLabel.Visibility = Visibility.Visible;
            heartRateTextBox.Visibility = Visibility.Visible;
        }

        private void HideSportActivityFields()
        {
            heartRateLabel.Visibility = Visibility.Hidden;
            heartRateTextBox.Visibility = Visibility.Hidden;
        }

        private void activityTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivityType selectedActivity = (ActivityType)activityTypeComboBox.SelectedItem;
            if (selectedActivity != null && selectedActivity.IsSport)
            {
                ShowSportActivityFields();
            } else
            {
                HideSportActivityFields();
            }
        }

        private bool IsSportActivity()
        {
            ActivityType selectedActivity = (ActivityType)activityTypeComboBox.SelectedItem;
            if (selectedActivity == null)
            {
                return false;
            } else
            {
                return selectedActivity.IsSport;
            }
        }
    }
}
