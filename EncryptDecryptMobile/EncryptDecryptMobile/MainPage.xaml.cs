using PaJaMa.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EncryptDecryptMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Encrypt_Clicked(object sender, EventArgs e)
        {
            try
            {
                entryOutput.Text = EncrypterDecrypter.Encrypt(entryInput.Text, entryPwd.Text);
                startTimer();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error:", ex.Message, "OK");
            }
        }

        private void Decrypt_Clicked(object sender, EventArgs e)
        {
            try
            {
                entryOutput.Text = EncrypterDecrypter.Decrypt(entryInput.Text, entryPwd.Text);
                startTimer();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error:", ex.Message, "OK");
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            clear();
        }

        private void startTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                this.clear();
                return false;
            });
        }

        private void clear()
        {
            entryOutput.Text = entryPwd.Text = entryInput.Text = string.Empty;
        }
    }
}
