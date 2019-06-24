﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenSaver_Anima
{
    public partial class Setup : Form
    {

        List<string> vids;
        public Setup()
        {
            InitializeComponent();
            Tools.GetData();
            vids = Tools.Videos;
            AddVideos();
            EnableVolumeControlCB.Checked = Tools.AllowKeys;
            VolumeBar.Value = Tools.Volume;
        }

        private void Setup_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        /// <summary>
        /// Считывает из реестра список воспроизводимых видео
        /// </summary>
        /// <returns>Список путей с видео</returns>
        

        /// <summary>
        /// Добавляет список видео в ListBox
        /// </summary>
        private void AddVideos()
        {
            VideoList.Items.Clear();
            vids = Tools.Videos;
            for (int i = 0; i < vids.Count; i++)
            {
                VideoList.Items.Add(vids[i]);
            }
        }

        private void BrowseVideo_Click(object sender, EventArgs e)
        {
            string filepath = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Выберите видеофайлы";


            fd.InitialDirectory = "C:\\";
            fd.Filter = "mp4 files (*.MP4/*.M4V)|*.mp4|avi files (*.avi)|*.avi|mov files (*.mov)|*.mov|mov files (*.mov)|*.mov";
            fd.FilterIndex = 2;
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                
                filepath  = fd.FileName;
                
            }

            vids.Add(filepath);
            AddVideos();
        }

        private void Setup_Load(object sender, EventArgs e)
        {

        }
    }
} 