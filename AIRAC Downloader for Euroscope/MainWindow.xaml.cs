using MaterialDesignThemes.Wpf;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace AIRAC_Downloader_for_Euroscope
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

        // dragging the window
        private bool RestoreIfMoved;
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                return;
            }
            else if (WindowState == WindowState.Maximized)
            {
                RestoreIfMoved = true;
                return;
            }

            DragMove();
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RestoreIfMoved = false;
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (RestoreIfMoved)
            {
                RestoreIfMoved = false;

                double percentHorizontal = e.GetPosition(this).X / ActualWidth;
                double targetHorizontal = RestoreBounds.Width * percentHorizontal;

                double percentVertical = e.GetPosition(this).Y / ActualHeight;
                double targetVertical = RestoreBounds.Height * percentVertical;

                WindowState = WindowState.Normal;

                POINT lMousePosition;
                GetCursorPos(out lMousePosition);

                Left = lMousePosition.X - targetHorizontal;
                Top = lMousePosition.Y - targetVertical;

                DragMove();
            }
        }

        // helper method to get the cursor position
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT(int x, int y)
        {
            public int X = x;
            public int Y = y;
        }


        // minimizing and closing the window
        private void Window_StateChanged(object sender, EventArgs e)
        {
            MaximizeOrUnMaximizeWindowButtonIcon.Kind = WindowState != WindowState.Maximized ? PackIconKind.Maximize : PackIconKind.WindowRestore;
        }
        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MaximizeOrUnMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}