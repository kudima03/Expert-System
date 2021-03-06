//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public partial class Admin : IEquatable<Admin>
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Status UserStatus { get; set; }

        public Bitmap Photo { get; set; }

        public byte[] BinaryPhoto
        {
            get
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(ms, Photo);
                    return ms.ToArray();
                }
            }
            set
            {
                using (MemoryStream ms = new MemoryStream(value))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    Photo = binaryFormatter.Deserialize(ms) as Bitmap;
                }
            }
        }

        public DateTime LastOnline { get; set; }

        private bool _isOnline;

        public bool IsOnline
        {
            get { return _isOnline; }
            set { LastOnline = DateTime.Now; _isOnline = value; }
        }


        public Admin()
        {
            Login = "empty";
            Password = "empty";
            UserStatus = Status.NotBanned;
            Photo = new Bitmap(ConfigurationManager.AppSettings.Get("defaultPhotoPath"));
            IsOnline = false;
        }

        public Admin (string login, string password) : this()
        {
            Login = login;
            Password = password;
        }

        public Admin(string login, string password, Bitmap photo) : this(login, password)
        {
            Photo = photo;
        }

        public bool Equals(Admin other)
        {
            return Login == other.Login && Password == other.Password;
        }
    }
}
