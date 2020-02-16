using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CheckPermissionDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        bool busy;
        async void ButtonPermission_OnClicked(object sender, EventArgs e)
        {
            if (busy)
                return;

            busy = true;
            ((Button)sender).IsEnabled = false;

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
           

            await DisplayAlert("Pre - Results","Status"+status.ToString(), "OK");

            if (status != PermissionStatus.Granted)
            {
                status = await Utils.CheckPermissions(Permission.Camera);

                

                await DisplayAlert("Results", status.ToString(), "OK");

            }

            busy = false;
            ((Button)sender).IsEnabled = true;
        }

    
    }
}
