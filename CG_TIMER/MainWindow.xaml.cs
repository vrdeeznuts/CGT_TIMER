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
using System.Windows.Threading;
using static CGT_TIMER.RelayCommand;
using static CGT_TIMER.SettingsWindow;

namespace CGT_TIMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // mouse interaction objects


        // Timer objects
        private readonly DispatcherTimer dt = new();
        private readonly Stopwatch sw = new();
        private readonly TimeSpan initialOffset = TimeSpan.FromSeconds(-10);
        public TimeSpan InitialOffset => initialOffset;

        // keybinding commands
        public ICommand ToggleStartPauseCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand SetTTBCommand { get; private set; }
        public ICommand ClearTTBCommand { get; private set; }
        public ICommand CloseWindowCommand { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ToggleStartPauseCommand = new RelayCommand(ToggleStartPause);
            ResetCommand = new RelayCommand(ResetTimer);
            SetTTBCommand = new RelayCommand(SetTTB);
            ClearTTBCommand = new RelayCommand(ClearTTB);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            dt.Interval = TimeSpan.FromMilliseconds(100);
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            dt.Tick += Timer_Tick;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // allows dragging window on screen by holding down anywhere on window
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ContextMenu != null)
            {
                if (Topmost)
                {
                    MenuAOT.IsChecked = true;
                }
                else
                {
                    MenuAOT.IsChecked = false;
                }
                ContextMenu.IsOpen = true;
            }

        }

        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new();
            settingsWindow.ShowDialog();
        }

        private void MenuItem_ToggleAlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            // Toggle 'always on top'
            Topmost = !Topmost;
        }

        private void ToggleStartPause()
        {
            // keybinding <Space>
            if (sw.IsRunning)
            {
                sw.Stop();
                dt.Stop();
            }
            else
            {
                sw.Start();
                dt.Start();
            }
        }

        private void ResetTimer()
        {
            // keybinding <Delete>
            sw.Reset();
            dt.Stop();
            UpdateCurrentTimeLabel();
            CurrentTimeText.Content = "-0:10.0";
        }

        private void SetTTB()
        {
            // keybinding <Ctrl>+<Space>
            UpdateTimeToBeatText();
        }

        private void ClearTTB()
        {
            // keybinding <Ctrl>+<Delete>
            TimeToBeatText.Content = "0:00.0";
        }

        private void CloseWindow()
        {
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTimeLabel();
        }

        private void UpdateCurrentTimeLabel()
        {
            TimeSpan elapsed = sw.Elapsed + InitialOffset;
            if (elapsed.TotalMilliseconds < 0 )
            {
                CurrentTimeText.Content = $"-{elapsed:m\\:ss\\.f}";
            }
            else
            {
                CurrentTimeText.Content = $"{elapsed:m\\:ss\\.f}";
            }
        }

        private void UpdateTimeToBeatText()
        {
            TimeToBeatText.Content = CurrentTimeText.Content;
        }
    }
}
