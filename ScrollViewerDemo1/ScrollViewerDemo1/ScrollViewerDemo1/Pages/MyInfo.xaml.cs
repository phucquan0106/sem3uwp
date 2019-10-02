using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using ScrollViewerDemo1.Entity;
using ScrollViewerDemo1.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ScrollViewerDemo1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyInfo : Page
    {

        private const string getApi = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/information";

        public MyInfo()
        {
            HttpClient httpClient = new HttpClient();
            this.InitializeComponent();

            MemberServiceImp memberServiceImp = new MemberServiceImp();
            content.Text = memberServiceImp.FormGetInfo(getApi);

            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("token1.txt").GetAwaiter().GetResult();

            //string text = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();

            //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + text);

            //var httpRequestMessage = httpClient.GetAsync(getApi);
            //var getResult = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            //Member user = JsonConvert.DeserializeObject<Member>(getResult);

            //content.Text = getResult;



        }



        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    var httpClient = (HttpClient)e.Parameter;
        //    if (httpClient != null)
        //    {
        //        var httpRequestMessage = httpClient.GetAsync(getApi);
        //        var getResult = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
        //        Member user = JsonConvert.DeserializeObject<Member>(getResult);
        //        myinfo.Text = getResult;
        //    }


        //}
    }
}
