using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.AppLogic
{
    public  static class FileActions
    {
        public static void Save(string fileName, List<TestTableContent> testTableList)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {

                var bf = new BinaryFormatter();

                //Create a new instance of the RijndaelManaged class
                // and encrypt the stream.
                var rmCrypto = new RijndaelManaged();

                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

                //Create a CryptoStream, pass it the NetworkStream, and encrypt 
                //it with the Rijndael class.
                var cryptStream = new CryptoStream(stream, rmCrypto.CreateEncryptor(key, iv), CryptoStreamMode.Write);

                bf.Serialize(cryptStream, testTableList);
                cryptStream.Close();

            }
        }

        public static List<TestTableContent> Open()
        {
            var ofd = new OpenFileDialog
            {
                Filter = Resources.MainForm_openToolStripMenuItem_Click_omg_files____omg____omg_All_files__________
            };
            return ofd.ShowDialog() == DialogResult.OK ? Open(ofd.FileName) : new List<TestTableContent>();
        }

        public static List<TestTableContent> Open(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {

                var bf = new BinaryFormatter();

                var rmCrypto = new RijndaelManaged();

                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

                //Create a CryptoStream, pass it the NetworkStream, and encrypt 
                //it with the Rijndael class.
                var cryptStream = new CryptoStream(stream, rmCrypto.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                return bf.Deserialize(cryptStream) as List<TestTableContent>;
            }
        }
    }
}
