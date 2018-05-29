using System;

namespace LoxNET.Transport.Http
{
    public class LxHttpConfiguration : ILxHttpConfiguration
    {

        public Uri Uri { get; }


        public static ILxHttpConfiguration With(Uri uri)
        {
            return new LxHttpConfiguration(uri);
        }

        private LxHttpConfiguration(Uri uri)
        {
            Uri = uri;
        }
    }
}