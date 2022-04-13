using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class RSAEncryption
        {
            #region Ham_MaHoa_GiaiMa
            public static byte[] MaHoa(byte[] dulieu, RSAParameters RSAKey, bool doOAEF)
            {
                try
                {
                    RSACryptoServiceProvider rsa = new
                    RSACryptoServiceProvider();
                    rsa.ImportParameters(RSAKey);
                    return rsa.Encrypt(dulieu, doOAEF);
                }
                catch (CryptographicException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            public static byte[] GiaiMa(byte[] dulieu, RSAParameters RSAKey, bool doOAEF)
            {
                try
                {
                    RSACryptoServiceProvider rsa = new
                    RSACryptoServiceProvider();
                    rsa.ImportParameters(RSAKey);
                    return rsa.Decrypt(dulieu, doOAEF);
                }
                catch (CryptographicException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            #endregion
        }

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        byte[] plainText;
        byte[] cipherText;

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            plainText = Encoding.UTF8.GetBytes(txtPlainText.Text);
            cipherText = RSAEncryption.MaHoa(plainText, rsa.ExportParameters(false), false);
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in cipherText)
                sbHash.Append(String.Format("{0:x2}", b));
            txtCipherText.Text = sbHash.ToString();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] decryptText = RSAEncryption.GiaiMa(cipherText, rsa.ExportParameters(true), false);
            txtDecryptText.Text = Encoding.UTF8.GetString(decryptText);
        }
    }
}
