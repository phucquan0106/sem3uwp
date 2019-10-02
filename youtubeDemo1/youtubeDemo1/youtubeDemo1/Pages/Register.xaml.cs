using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using youtubeDemo1.Entities;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace youtubeDemo1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/members";

        public Register()
        {
            this.InitializeComponent();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
        
        var member = new Member
            {
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                password = txtPassword.Password.ToString(),
                address = txtAddress.Text,
                avatar = txtAvatar.Text,
                birthday = txtBirthday.Text,
                email = txtEmail.Text,
                gender = Int32.Parse(txtGender.Text),
                introduction = txtIntroduction.Text,
                phone = txtPhone.Text
            };

            Debug.WriteLine(JsonConvert.SerializeObject(member));
            var httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(member),
                Encoding.UTF8,"application/json");
            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, httpContent);
            String responseContent = httpClient.PostAsync(ApiUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("response from server: " + responseContent);

            Member resMember = JsonConvert.DeserializeObject<Member>(responseContent);
            JObject resJObject = JObject.Parse(responseContent);
            Debug.WriteLine(resJObject["email"]);
        }
    }
}
