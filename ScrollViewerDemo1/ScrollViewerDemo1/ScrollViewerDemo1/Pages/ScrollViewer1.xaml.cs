using Newtonsoft.Json;
using ScrollViewerDemo1.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ScrollViewerDemo1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScrollViewer1 : Page
    {
        public ScrollViewer1()
        {
            this.InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            var member1 = new member {
                userName = this.txtUsername.Text,
                passWord = this.txtPassword.Password,
                email = this.txtEmail.Text,
                phone = this.txtPhone.Text,
                avatar = this.txtAvatar.Text
            };

            //Validate phía client
            Debug.WriteLine(JsonConvert.SerializeObject(member1));

        }
    }
}
