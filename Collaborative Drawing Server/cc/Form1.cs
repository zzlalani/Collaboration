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

namespace cc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Pen p = new Pen(Color.Black);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;

        
        List<string> startpoints = new List<string>();
        List<string> endpoints = new List<string>();
        List<Point> myPoints = new List<Point>();
        DrawingClient dc = new DrawingClient();

        private void Form1_Load(object sender, EventArgs e)
        {
            lblServerStatus.Text = "Idle";
            lblClientStatus.Text = "Idle";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sp = e.Location;
            if (e.Button==MouseButtons.Left)
            {
                k = 1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
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
                startpoints.Add(sp.ToString());
                endpoints.Add(ep.ToString());
            }
            sp = ep;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Loopback, 8000);
                listener.Start();
                lblServerStatus.Text = "Server Started";
                listener.BeginAcceptTcpClient(new AsyncCallback(AcceptConnection), listener);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Server Exception");
            }
        }

        void AcceptConnection(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            TcpClient c = listener.EndAcceptTcpClient(ar);
            lblClientStatus.Invoke(new MethodInvoker(delegate()
                { 
                    lblClientStatus.Text = "Client Connected : " + c.Client.RemoteEndPoint.ToString();
                }
                ));
            Thread t = new Thread(new ParameterizedThreadStart(RcV));
            t.Start(c);
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
            }
        }
    }

}
