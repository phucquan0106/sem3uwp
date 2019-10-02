using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
using uwpExam1.Entities;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace uwpExam1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        private const string URL_GET_SONG = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";

        public ObservableCollection<Song> ListSongs = new ObservableCollection<Song>();

        public ListSong()
        {
            this.InitializeComponent();

            var httpClient = new HttpClient();
            Task<HttpResponseMessage> httpRequestMessageToGetSongList = httpClient.GetAsync(URL_GET_SONG);
            var jsonResultToGetSongList = httpRequestMessageToGetSongList.Result.Content.ReadAsStringAsync().Result;
            ObservableCollection<Song> listSong = JsonConvert.DeserializeObject<ObservableCollection<Song>>(jsonResultToGetSongList);
            foreach (Song item in listSong)
            {
                ListSongs.Add(item);
            }
        }


    }
}
