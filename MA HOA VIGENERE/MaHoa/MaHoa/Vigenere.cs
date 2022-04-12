using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoa
{
    public class Vigenere
    {
        #region property
        public string key { get; set; }
        public string plainText { get; set; }
        public string cipherText { get; set; }
        #endregion
        public Vigenere(string s)
        {
            key = s.ToUpper();
        }

        string chuoi ="AÄÂBCDĐEÊGHIKLMNOÔOPQRSTUUVXY ?!ÁÀÅÚ";

        public int[] chuoi_mangchiso(string s)
        {
            int[] mang = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
                mang[i] = chuoi.IndexOf(s[i]);
            return mang;
        }
        public string chiso_chuoi(int[] a)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
                s += chuoi[a[i]];
            return s;
        }
        public String MaHoaVigenere()
        {
            plainText = plainText.ToUpper(); 
            int[] pre_index = chuoi_mangchiso(plainText);
            int[] k = chuoi_mangchiso(key);
            int[] pos_index = new int[plainText.Length];
for (int i=0,j=0;  i < plainText.Length; i++)
              pos_index[i]=(pre_index[i] + k[j]) % chuoi.Length;
            // đổi sang mảng
            cipherText = chiso_chuoi(pos_index);
            return cipherText;
        }
        
        public String GiaiMaVigenere()
        {
            int[] pre_index = chuoi_mangchiso(cipherText);
            int[] k = chuoi_mangchiso(key);
            int[] pos_index = new int[cipherText.Length];
            //mã hóa
            for (int i = 0,j=0; i < cipherText.Length; i++)
                pos_index[i] = (pre_index[i] + chuoi.Length - k[j]) % chuoi.Length;
            // đổi sang mảng
            plainText = chiso_chuoi(pos_index);
            return plainText;
        }
    }
}
