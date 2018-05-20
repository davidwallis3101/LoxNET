using System;

namespace LoxNET.Common
{
    public class LxConfiguration2 : ILxConfiguration2
    {
        public string Hostname { get; }
        public int Port { get; }
        public string UserName { get; }
        public string Password { get; }

        public static ILxConfiguration2 With(
            string hostname, int port,
            string username, string password)
        {
            return new LxConfiguration2(
                hostname, port, 
                username, password);
        }

        private LxConfiguration2(
            string hostname, int port,
            string username, string password)
        {
            if (String.IsNullOrEmpty(hostname)) throw new ArgumentNullException(nameof(hostname));
            if (port == 0) throw new ArgumentNullException(nameof(port));
            if (String.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if (String.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            Hostname = hostname;
            Port = port;
            UserName = username;
            Password = password;
        }
    }
}