using System;

namespace LoxNET.Common
{
    public class LxConfiguration : ILxConfiguration
    {
        public string Hostname { get; }
        public int Port { get; }
        public string UserName { get; }
        public string Password { get; }

        public static ILxConfiguration With(
            string hostname, int port,
            string username, string password)
        {
            return new LxConfiguration(
                hostname, port, 
                username, password);
        }

        private LxConfiguration(
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