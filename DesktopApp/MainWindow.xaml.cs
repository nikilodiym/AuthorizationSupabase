using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string SupabaseUrl = "https://dqvxskzoovermvhcmksm.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImRxdnhza3pvb3Zlcm12aGNta3NtIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDMyNDQ2ODgsImV4cCI6MjA1ODgyMDY4OH0.1H-EwOin95ohUC6CnVFeWI5RQNwA2xgdjTl_Dfa_tIE";  // Replace this with your actual key

        public MainWindow()
        {
            InitializeComponent();
        }
    
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Fill all fields!");
                return;
            }

            await SaveUserToSupabase(username, password);
        }
    
        private async Task SaveUserToSupabase(string username, string password)
        {
            var data = new { username, password };
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear(); 
            _httpClient.DefaultRequestHeaders.Add("apikey", SupabaseKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseKey}");

            HttpResponseMessage response = await _httpClient.PostAsync($"{SupabaseUrl}/rest/v1/users", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("User registered successfully!");
            }
            else
            {
                MessageBox.Show("Error registering user!");
            }
        }
    }
}
