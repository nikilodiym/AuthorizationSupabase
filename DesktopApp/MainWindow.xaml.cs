using System.Windows;

namespace DesktopApp;

public partial class MainWindow : Window
{
    private SupabaseService.SupabaseService.SupabaseService _provider;
    public MainWindow()
    {
        InitializeComponent();
        _provider = new SupabaseService.SupabaseService.SupabaseService();
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        // Placeholder logic for when the window is loaded
        MessageBox.Show("MainWindow loaded successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        MainWindowFrame.Navigate(new Pages.SignInPage(_provider));
    }
}