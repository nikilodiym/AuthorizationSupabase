using System.Windows;

namespace DesktopApp
{
    public partial class MainWindow : Window
    {
        SupabaseService.SupabaseService.SupabaseService supabaseService;
        public MainWindow()
        {
            InitializeComponent();
            supabaseService = new SupabaseService.SupabaseService.SupabaseService();
        }
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var session = await supabaseService.Register(UsernameBox.Text, PasswordBox.Password);
            
            if (session != null)
            {
                // Registration successful
                supabaseService.SetAuthUser();
                MessageBox.Show("Registration successful!");
            }
            else
            {
                // Registration failed
                MessageBox.Show("Registration failed!");
            }
        }
    }
}
