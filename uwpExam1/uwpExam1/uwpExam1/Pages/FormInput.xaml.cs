using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using uwpExam1.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections;
using JsonArray = Windows.Data.Json.JsonArray;
using JsonObject = RestSharp.JsonObject;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace uwpExam1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormInput : Page
    {

        private const string URL_POST_SONG = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        
        public FormInput()
        {
            this.InitializeComponent();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                name = txtName.Text,
                description = txtDescription.Text,
                singer = txtSinger.Text,
                author = txtAuthor.Text,
                thumbnail = txtThumbnail.Text,
                link = txtLink.Text,
            };
            //========POST SONG=========
            Debug.WriteLine(JsonConvert.SerializeObject(song));
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                "application/json");
            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(URL_POST_SONG, content);
            String responseContent = httpClient.PostAsync(URL_POST_SONG, content).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);
            //=========================





        }

        

        public void BtnViewSong_OnClick(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ListSong));



        }
    }
}
