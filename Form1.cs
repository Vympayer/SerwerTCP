using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;



namespace ServerTCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener server = null;
        private TcpClient klient = null;


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Adres_TextChanged(object sender, EventArgs e)
        {

        }

        private void port_p_ValueChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            IPAddress adresIP = null;
            try
            {
                adresIP = IPAddress.Parse(Adres.Text); 
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP", "Błąd");
                Adres.Text = String.Empty;
                return;
            }

            int port = System.Convert.ToInt32(port_p.Value);

            try
            {
                server = new TcpListener(adresIP, port);
                server.Start();

                klient = server.AcceptTcpClient();
                listBox1.Items.Add("Nawiązano połączenie!");
                start.Enabled = false;
                stop.Enabled = true;
                klient.Close();
                server.Stop();

            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Błąd inicjacji serwera!");
                MessageBox.Show(ex.ToString(), "Błąd");
            } 

        }

        private void stop_Click(object sender, EventArgs e)
        {
            server.Stop();
            klient.Close();

            listBox1.Items.Add("Zakonczono prace serwera!");

            start.Enabled = true;
            stop.Enabled = false;
        }
    }
}
