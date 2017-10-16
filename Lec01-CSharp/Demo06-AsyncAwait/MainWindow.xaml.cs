using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Demo06_AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Good button clicked
        /// </summary>
        private void SyncTaskButtonClicked(object sender, RoutedEventArgs e)
        {
            SetLoadingOn();
            // Bad - get students takes 10 second to finish. Poor internet connection? Huge amount of work?
            // Main thread is stuck waiting... who will refresh the UI now?
            var students = GetStudentsLongRunningMethod();

            TextBlock.Text = string.Join(", ", students);

            SetLoadingOff();
        }

        /// <summary>
        /// Bad button clicked
        /// </summary>
        private async void AsyncTaskButtonClicked(object sender, RoutedEventArgs e)
        {
            SetLoadingOn();

            // Fire a new thread that will collect the students.
            // Nice.
            var studentCollectingTask = Task.Run(() => GetStudentsLongRunningMethod());

            // Don't just wait. Do the asynchronous wait.
            // Main method returns to its duties while this runs.
            var students = await studentCollectingTask;


            // Main thread continues here after the student collecting task finished.
            TextBlock.Text = string.Join(", ", students);

            SetLoadingOff();
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = string.Empty;
        }



        /// <summary>
        /// Method that returns students.
        /// Lasts for 10 seconds!
        /// </summary>
        /// <returns></returns>
        private string[] GetStudentsLongRunningMethod()
        {
            // Simulate long running operation
            Thread.Sleep(5000);
            return new string[] { "Pero", "Ivan", "Luka", "Tamara" };
        }

        private void SetLoadingOn()
        {
            TextBlock.Text = "";
            LoadingAnimation.Visibility = Visibility.Visible;
            RightWayButton.IsEnabled = false;
            WrongWayButton.IsEnabled = false;
            ClearButton.IsEnabled = false;

        }

        private void SetLoadingOff()
        {
            LoadingAnimation.Visibility = Visibility.Hidden;
            RightWayButton.IsEnabled = true;
            WrongWayButton.IsEnabled = true;
            ClearButton.IsEnabled = true;
        }

     
    }
}
