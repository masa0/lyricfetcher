using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace lyric_fetcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = (textBox1.Text);

            string text2 = (textBox2.Text);

            try
            {

                List<string> lyrics = new List<string>();
                text1 = text1.Replace(" ", "");
                text2 = text2.Replace(" ", "");
                WebClient web = new WebClient();
                string html = web.DownloadString(string.Format("http://www.azlyrics.com/lyrics/{0}/{1}.html", text1, text2));
                MatchCollection ly = Regex.Matches(html, @"<!-- Usage of azlyrics.com content by any third-party lyrics provider is prohibited by our licensing agreement. Sorry about that. -->\s*(.+?)\s*</div>", RegexOptions.Singleline);


                foreach (Match m in ly)
                {
                    string song = m.Groups[1].Value;
                    lyrics.Add(song);
                }

                string lyricsx = lyrics[0];

                lyricsx = Regex.Replace(lyricsx, "<br>", "\r\n");
                lyricsx = lyricsx.Replace("&", " &");
                lyricsx = Regex.Replace(lyricsx, " &quot;", "\"");

               // listBox1.DataSource = lyricsx;
                textBox3.Text = lyricsx;
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hmm... Something seems to have gone wrong, make sure you have typed the artist's name and song correctly." + ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

    }
}
