using Supabase.Gotrue;

namespace SupabaseService.SupabaseService
{
    public class SupabaseService
    {
        private static string _supabaseUrl = "https://dqvxskzoovermvhcmksm.supabase.co";
        private static string _supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImRxdnhza3pvb3Zlcm12aGNta3NtIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDMyNDQ2ODgsImV4cCI6MjA1ODgyMDY4OH0.1H-EwOin95ohUC6CnVFeWI5RQNwA2xgdjTl_Dfa_tIE";
        public Supabase.Client supabaseClient;

        public bool IsLoggedIn { get; private set; }
        public User? SupabaseUser { get; private set; }

        public SupabaseService()
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            supabaseClient = new Supabase.Client(_supabaseUrl, _supabaseKey, options);
        }

        public async Task<Session?> Login(string email, string password)
        {
            try
            {
                var session = await supabaseClient.Auth.SignIn(email, password);
                return session;
            }
            catch (Exception ex)
            {
                throw new Exception($"Login(string email, string password) raise Exception: {ex.Message}");
            }
        }

        public async Task<Session?> Register(string email, string password)
        {
            try
            {
                var session = await supabaseClient.Auth.SignUp(email, password);
                return session;
            }
            catch (Exception ex)
            {
                throw new Exception($"Register(string email, string password) raise Exception: {ex.Message}");
            }
        }

        public async Task Logout()
        {
            try
            {
                await supabaseClient.Auth.SignOut();
                IsLoggedIn = false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Logout() raise Exception: {ex.Message}");
            }
        }

        public void SetAuthUser()
        {
            if (supabaseClient.Auth.CurrentUser != null)
            {
                SupabaseUser = supabaseClient.Auth.CurrentUser;
                IsLoggedIn = true;
            }
        }
    }
}