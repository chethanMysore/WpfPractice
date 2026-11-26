using System.Windows;

namespace WpfPractice
{
    public partial class MainWindow : Window
    {
        private int _count = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            _count++;
            CounterText.Text = $"Button clicked: {_count} times";
        }
    }
}
