using System;
using System.Linq;

namespace CommonUtils.Utils
{
    public static class EncryptUidUtils
    {

        /// <summary>
        /// 指定されたUIDを暗号化して返します。
        /// </summary>
        /// <param name="uid">MUID</param>
        /// <returns></returns>
        public static string Encrypt(string uid)
        {
            var encryptStr = "";
            if (!string.IsNullOrEmpty(uid))
            {
                if (CheckMuid(uid))
                {
                    uid = uid.Replace(".", "");
                    if(uid.Length%2!=0)
                    {
                        uid = uid + "0";
                    }
                    var asciiEncoding = new System.Text.ASCIIEncoding();

                    for (int i = 0; i < uid.Length / 2; i++)
                    {
                        var subUid = uid.Substring(i * 2, 2);
                        encryptStr = encryptStr + subUid + ((asciiEncoding.GetBytes(uid.Substring(i * 2, 1))[0] + asciiEncoding.GetBytes(uid.Substring(i * 2 + 1, 1))[0]) % 15).ToString("x");
                    }
                    char[] arr = encryptStr.ToCharArray();
                    Array.Reverse(arr);
                    encryptStr = new string(arr);
                }
                else
                {
                    encryptStr = "00000";
                }
            }
            else
            {
                encryptStr = "00000";
            }
            return encryptStr;
        }



        /// <summary>
        /// Uidチェック(0~9|a~z|A~Z)かつ18桁
        /// </summary>
        /// <param name="uid">UID</param>
        /// <returns></returns>
        private static bool CheckMuid(string uid)
        {
            var asciiEncoding = new System.Text.ASCIIEncoding();

            var rst = uid.Select((t, i) => (int)asciiEncoding.GetBytes(uid.Substring(i, 1))[0]).Aggregate(true, (current, z) => current && ((47 < z && z < 58) || (64 < z && z < 91) || (96 < z && z < 123) || z==46));
            return  rst;
        }
    }
}
