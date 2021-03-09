using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "파일을 어디에 넣을까요?" })
                //폴더를 선택하세요
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var youtube = YouTube.Default;
                        //유튜브 변수에 기본값을 할당(video library)
                        var video = await youtube.GetVideoAsync(textBox1.Text);
                        //URL을 받아서 유튜브에서 비디오를 찾습니다.
                
                        if (comboBox1.Text == "mp3")
                            //콤보박스로 선택한 것이 mp3이면 mp3확장자로 받습니다.
                        {
                            File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName + ".mp3", await video.GetBytesAsync());
                            //새 파일을 만들고, 이전에 만든 파일이 있으면 덮어씁니다, 선택한 폴더안에 비디오 이름 + 확장자명을 써서 저장합니다.
                        }

                        if (comboBox1.Text == "mp4")
                        //콤보박스로 선택한 것이 mp4이면 mp4확장자로 받습니다.
                        {
                            File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName + "", await video.GetBytesAsync());
                            // 마찬가지로 새 파일을 만들고, 이전에 만든 파일이 있으면 덮어씁니다, 선택한 폴더안에 비디오 이름 + 확장자명을 써서 저장합니다.

                        }
                    }
                    catch
                    {
                        MessageBox.Show("에러나요");
                        //try catch로 위의 코드에서 에러가 났을 시 "응애"라고 메시지박스가 출력됩니다.
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //exit버튼을 누르면 창이 닫힙니다.
    }
}
