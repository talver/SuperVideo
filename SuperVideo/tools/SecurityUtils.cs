using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideo.tools
{
    public sealed class SecurityUtils
    {
        private SecurityUtils() { }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="key">16位密钥字符串</param>
        /// <param name="str">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static byte[] AesEncrypt(string key, byte[] inputByteArray)
        {
            try
            {
                //分组加密算法
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                //设置密钥及密钥向量
                aes.Key = Encoding.UTF8.GetBytes(key);
                //aes.IV = Encoding.UTF8.GetBytes(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] cipherBytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cipherBytes = ms.ToArray();//得到加密后的字节数组
                        cs.Close();
                        ms.Close();
                    }
                }
                return cipherBytes;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="key">16位密钥字符串</param>
        /// <param name="str">待解密字符串</param>
        /// <returns>解密后字符串</returns>
        public static byte[] AesDecrypt(string key, byte[] cipherText)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = Encoding.UTF8.GetBytes(key);
                //aes.IV = Encoding.UTF8.GetBytes(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] decryptBytes = new byte[cipherText.Length];
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cs.Read(decryptBytes, 0, decryptBytes.Length);
                        cs.Close();
                        ms.Close();
                    }
                }
                byte[] dec = new byte[cipherText.Length - aes.Key.Length];
                Array.Copy(decryptBytes, dec, dec.Length);
                return dec;   //将字符串后尾的'\0'去掉
            }
            catch { }
            return null;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <returns>MD5加密后字符串</returns>
        public static string Md5Encrypt(string str)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
                bytes = md5.ComputeHash(bytes);
                md5.Clear();

                string ret = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
                }
                return ret.PadLeft(32, '0');
            }
            catch { }
            return str;
        }

        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <returns>文件MD5值</returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch { }
            return "";
        }

        #region Base64
        /// <summary>
        /// 字符串转Base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return ToBase64String(str, Encoding.UTF8);
        }

        /// <summary>
        /// 字符串转Base64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string ToBase64String(string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str)) return str;
            byte[] bytes = encoding.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64转字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromBase64String(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return FromBase64String(str, Encoding.UTF8);
        }

        /// <summary>
        /// Base64转字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string FromBase64String(string str, Encoding encoding)
        {
            string res = "";
            if (string.IsNullOrEmpty(str)) return str;
            try
            {
                byte[] base64Bytes = Convert.FromBase64String(str);
                res = encoding.GetString(base64Bytes);
            }
            catch { }
            return res;
        }
        #endregion
    }
}
