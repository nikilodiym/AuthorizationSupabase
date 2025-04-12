using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Pages;

public partial class SignInPage : UserControl
{
    private readonly SupabaseService.SupabaseService.SupabaseService _supabaseService;
    
    public SignInPage(SupabaseService.SupabaseService.SupabaseService provider)
    {
        InitializeComponent();
        _supabaseService = new SupabaseService.SupabaseService.SupabaseService();
    }
    private async void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var session = await _supabaseService.Register(UsernameBox.Text, PasswordBox.Password);

            if (session != null)
            {
                _supabaseService.SetAuthUser();
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}");
        }
    }
}