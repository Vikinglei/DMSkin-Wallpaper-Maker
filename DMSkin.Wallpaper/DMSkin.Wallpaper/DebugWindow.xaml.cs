﻿using DMSkin.Server;
using System.Windows;

namespace DMSkin.Wallpaper
{
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
     
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)PlayerMINI.IsChecked)
            {
                PlayServer.PlayerType = PlayerType.MN;
            }
            else
            {
                PlayServer.PlayerType = PlayerType.XL;
            }

            //初始化解码器
            PlayServer.Initialize();
            //播放
            PlayServer.Play(TbUrl.Text);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PlayServer.CloseAll();
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayServer.SetVolume((int)SliderVolume.Value);
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {
                TbUrl.Text = openFileDialog.FileName;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(bool)PlayerRun.IsChecked)
            {
                PlayServer.CloseAll();
            }
        }
    }
}
