﻿using System;
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

        /**/

        private void drawCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            myPoints = new List<Point>();
            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
        }

        private void drawCanvas_MouseUp(object sender, MouseEventArgs e)
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

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                ep = e.Location;
                g = drawCanvas.CreateGraphics();
                g.DrawLine(p, sp, ep);

                myPoints.Add(sp);
                dc.Points = myPoints;
            }
            sp = ep;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Loopback, 8000);

            Thread t = new Thread(new ParameterizedThreadStart(RcV));
            t.Start(client);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void RcV(object obj)
        {
            try
            {
                TcpClient c = (TcpClient)obj;
                BinaryFormatter bf = new BinaryFormatter();
                NetworkStream ns = c.GetStream();
                while (true)
                {
                    object b = bf.Deserialize(ns);
                    dc = (DrawingClient)b;
                    if (dc.Points.Count > 0)
                    {
                        for (int i = 0; i < dc.Points.Count - 2; i++)
                        {
                            if (g != null)
                            {
                                g.DrawLine(p, dc.Points[i], dc.Points[i + 1]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
