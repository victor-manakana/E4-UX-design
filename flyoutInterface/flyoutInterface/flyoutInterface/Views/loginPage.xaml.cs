using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyoutInterface.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginPage : ContentPage
    {
        public loginPage()
        {
            InitializeComponent();
        }

        public string WebApiKey = "AIzaSyANleMFNCGR-ovYuKEZMYjHmZ-YQNzqIr4";
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email.Text, Password.Text);
                var content = await auth.GetFreshAuthAsync();//
                var SerailizedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", SerailizedContent);
                Console.WriteLine("God damn");
                //To navigate to the next form
                //await Navigation.PushAsync(new nextPage()); 
                await App.Current.MainPage.DisplayAlert("Work", "Successfully!", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Invalid credentials", "Re-try", "Ok");
                Console.WriteLine(ex);
            }

        }

        private async void RegButton_Clicked(object sender, EventArgs e)
        {

            await Application.Current.MainPage.Navigation.PushAsync(new registrationPage());
        }
    }
}