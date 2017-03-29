using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;
using System.IO;

namespace Xamarin.AndroidDemo
{
    [Activity(Label = "Xamarin.AndroidDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText Text = FindViewById<EditText>(Resource.Id.Txt_Tel);
            Button TrainBtn = FindViewById<Button>(Resource.Id.Btn_Train);
            Button CallBtn = FindViewById<Button>(Resource.Id.Btn_Call);


            CallBtn.Enabled = false;

            string Number = string.Empty;
            TrainBtn.Click += (object sender, System.EventArgs e) =>
            {
                Number = PhoneTranslator.ToNumber(Text.Text);
                if (!string.IsNullOrWhiteSpace(Number))
                {
                    CallBtn.Text = CallBtn.Text + Number;
                    CallBtn.Enabled = true;
                }
            };


            CallBtn.Click += (object sender, System.EventArgs e) =>
            {
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage("Call" + Number + "?");
                callDialog.SetNeutralButton("Call", delegate
                {
                    var callIntent = new Intent(Intent.ActionCall);
                    StartActivity(callIntent);
                });

                //取消按钮
                callDialog.SetNegativeButton("Cancel", delegate { });

                //显示对话框
                callDialog.Show();
            };
        }
    }
}

