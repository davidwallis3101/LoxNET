using System;
using System.Collections.Generic;

namespace LoxNET.Configuration
{
    public class LxSettings : ILxSettings
    {

        private ILxEventFlowOptions lxEventFlowOptions = new LxEventFlowOptions();
        public ILxEventFlowOptions EventFlowOptions 
        { 
            get { return lxEventFlowOptions; } 
        }


        private List<ILxEndpointOptions> lxMiniServers = new List<ILxEndpointOptions>();
        public IEnumerable<ILxEndpointOptions> MiniServerOptions 
        { 
            get { return lxMiniServers; } 
        } 
    
        public int MiniServerOptionsCount
        {
            get 
            {
                return lxMiniServers.Count;
            }
        }

        public void RegisterLxEndpoint(ILxEndpointOptions endpoint)
        {
            lxMiniServers.Add(endpoint);
        }


        /*
        public string Hostname { get; }
        public int Port { get; }
        public string UserName { get; }
        public string Password { get; }

        public static ILxConfig With(
            string hostname, int port,
            string username, string password)
        {
            return new LxConfig(
                hostname, port, 
                username, password);
        }

        private LxConfig(
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
        */
        
    }
}