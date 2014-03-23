using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using rummykhan;

namespace dClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TcpClient client;
        Graphics g;
        Pen p = new Pen(Color.Black);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;
        BinaryFormatter bf = new BinaryFormatter();

        List<Point> myPoints;
        DrawingClient dc = new DrawingClient();
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            myPoints = new List<Point>();
            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
            if (client != null)
            {
                bf.Serialize(client.GetStream(), dc);
                myPoints = null;
            }
            else
                MessageBox.Show("Data is not being sent as you are not connected to Server");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (k==1)
            {
                ep = e.Location;
                g = this.CreateGraphics();
                g.DrawLine(p, sp, ep);

                label3.Text = sp.ToString();
                label4.Text = ep.ToString();
                myPoints.Add(sp);
                dc.Points = myPoints;
            }
            sp = ep;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Loopback, 8000);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
