using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScrollViewerDemo1.Entity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ScrollViewerDemo1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private string LOGIN_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/authentication";


        public Login()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_LoginOnClick(object sender, RoutedEventArgs e)
        {
            var memberLogin = new Member
            {
                email = Email.Text,
                password = Password.Password,
            };
            var httpClient = new HttpClient();
            //HttpContent authenticateContent = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, "application/json");
            //Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(api, authenticateContent);
            //var jsonResult = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;

            //var response = JsonConvert.DeserializeObject<Member>(jsonResult);
            //var token = response.token;

            //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

            ////Lay gia tri get ve

            //Frame.Navigate(typeof(MyInfo), httpClient);
            ////Frame.Navigate(typeof(NavigationView), httpClient);
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin),
                Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var responseContent = client.PostAsync(LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync().Result;
            JObject jsonJObject = JObject.Parse(responseContent);
            Debug.WriteLine(jsonJObject["token"]);
            
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync("token1.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            //Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("token1.txt");

            Windows.Storage.FileIO.WriteTextAsync(sampleFile, jsonJObject["token"].ToString()).GetAwaiter().GetResult();
            Debug.WriteLine(sampleFile.Path);
        }

        private void ButtonBase_ResetOnClick(object sender, RoutedEventArgs e)
        {
            this.Email.Text = String.Empty;
            this.Password.Password = String.Empty;
        }
    }
}
