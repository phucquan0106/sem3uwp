using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwpExam1.Entities
{
    class ListSongs
    {
        public ObservableCollection<Song> listSong
        {
            get => listSong;
            set => listSong = value;
        }
    }
}
