using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ArduinoManagementSystem
{
    public static class Configuration
    {
        private static readonly Dictionary<string, object> Data;

        static Configuration()
        {
            Data = Load();
        }

        static void Save(Dictionary<string,object> data)
        {
            var fs = new FileStream("Configuration.xml", FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(data.Serialize());
            sw.Flush();
            sw.Close();
            fs.Close(); 
        }

        static Dictionary<string, object> Load()
        {
            var fs = new FileStream("Configuration.xml", FileMode.OpenOrCreate);
            var sr = new StreamReader(fs);
            var xml = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            if (String.IsNullOrEmpty(xml))
            {
                
                return new Dictionary<string, object>();
            }

            return xml.Deserialize<Dictionary<string, object>>();

        }
        public static bool Contains(params ConfigurationData[] keys)
        {
            return !(keys.Where(key => !Data.ContainsKey(key.ToString())).Count() > 0);
        }

        public static T Get<T>(ConfigurationData key)
        {
            return (T)Data[key.ToString()];
        }

        public static string DecryptAndGet(ConfigurationData key)
        {
            return ((string)Data[key.ToString()]).Decrypt();
        }

        public static void Set(ConfigurationData key, object value)
        {
            if (Data.ContainsKey(key.ToString()))
            {
                Data[key.ToString()] = value;
            }
            else
            {
                Data.Add(key.ToString(), value);    
            }
            Save(Data);
        }

        public static void EncryptAndSet(ConfigurationData key, string value)
        {
            if (Data.ContainsKey(key.ToString()))
            {
                Data[key.ToString()] = value.Encrypt();
            }
            else
            {
                Data.Add(key.ToString(), value.Encrypt());
            }
            Save(Data);
        }

        private static string Encrypt(this string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        private static string Decrypt(this string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }


    public enum ConfigurationData
    {
        PortNumber,
        VolumeLevel,
        BaudRate,
        VKEncryptedPassword,
        VKEncryptedEmail,
    }

    public static class SerializationExtensions
    {
        public static string Serialize<T>(this T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using (var writer = new StringWriter())
            using (var stm = new XmlTextWriter(writer))
            {
                serializer.WriteObject(stm, obj);
                return writer.ToString();
            }
        }
        public static T Deserialize<T>(this string serialized)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var reader = new StringReader(serialized))
            using (var stm = new XmlTextReader(reader))
            {
                return (T)serializer.ReadObject(stm);
            }
        }
    }
}
