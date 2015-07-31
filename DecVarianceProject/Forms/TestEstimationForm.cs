using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public partial class TestEstimationForm : Form
    {
        public List<TestTable> TestTableList { get; private set; }

        public double EVBefore { get; private set; }
        public double EVAfter { get; private set; }
        public double VarianceBefore { get; private set; }
        public double VarianceAfter { get; private set; }
        public double EvProfit { get; private set; }


        public TestEstimationForm(List<TestTable> list)
        {
            this.TestTableList = list;
            InitializeComponent();
            List<TablesContent> TestListResults = new List<TablesContent>(list);
            Test test = new Test() { DGV = dataGridViewTest, ListContent = TestListResults };
            test.ConfigureDGV();
            EstimateEV();
            EstimateVariance();
            MarathonEVBeforeTBX.Text = Convert.ToString(EVBefore);
            MarathonEVAfterTBX.Text = Convert.ToString(EVAfter);
            VarianceBeforeTBX.Text = Convert.ToString(VarianceBefore);
            VarianceAfterTBX.Text = Convert.ToString(VarianceAfter);
            EvProfitTBX.Text = Convert.ToString(EvProfit);
        }

        private void EstimateEV()
        {
            foreach (var row in TestTableList)
            {
                EVBefore += row.NetWonBefore;
                EVAfter += row.NetWonAfter;
            }
            EVBefore /= TestTableList.Count;
            EVAfter /= TestTableList.Count;
            EvProfit = (EVAfter - EVBefore) / EVBefore;
            EvProfit = Math.Round(EvProfit, 3);
        }

        private void EstimateVariance()
        {
            foreach(var row in TestTableList)
            {
                VarianceBefore += Math.Pow(row.NetWonBefore - EVBefore, 2);
                VarianceAfter += Math.Pow(row.NetWonAfter - EVAfter, 2);
            }
            VarianceBefore /= TestTableList.Count;
            VarianceAfter /= TestTableList.Count;
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "omg files (*.omg)|*.omg|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Save(sfd.FileName);
            }
        }

        public void Save(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {

                BinaryFormatter bf = new BinaryFormatter();

                //Create a new instance of the RijndaelManaged class
                // and encrypt the stream.
                RijndaelManaged RMCrypto = new RijndaelManaged();

                byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

                //Create a CryptoStream, pass it the NetworkStream, and encrypt 
                //it with the Rijndael class.
                CryptoStream CryptStream = new CryptoStream(stream, RMCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

                bf.Serialize(CryptStream, TestTableList);
                CryptStream.Close();

            }
        }

    }
}
