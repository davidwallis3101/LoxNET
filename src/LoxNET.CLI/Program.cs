using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Configuration;
using EventFlow.Core;
using LoxNET.Transport;
using LoxNET.Transport.Connection;
using LoxNET.Common;
using LoxNET.Configuration;
using LoxNET.Transport.Domain.Services;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using LoxNET.Transport.Domain.Model.ClientModel.Entities;
using EventFlow.Extensions;
using EventFlow.Logs;
using LoxNET.Common.NewFolder;
using LoxNET.Configuration;
using LoxNET.Serialization;
using Newtonsoft.Json.Linq;

namespace LoxNET.CLI
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("LoxNET.CLI start");
            CryptoAquireToken();

  //          //var settings = new LxSettingsFactory().Configure();
  ////Console.WriteLine(settings);



  //          var configFactory = new LxSettingsFactory();
  //          //configFactory.Register(new AppSettingsProvider());
  //          //var config = configFactory.Configure();

  //          //Console.WriteLine(LxConfigurationProvider.Config.MiniServer.HostName);


  //          UriBuilder builder = new UriBuilder("http://192.168.0.77");
  //          using (var request = new LxHttpRequest(builder.Uri))
  //          {
  //              CancellationToken token = new CancellationToken();
  //              string result = request.GetStringAsync("jdev/sys/getPublicKey", token).Result;
  //              var res = ResultConverter.Deserialize(result);

  //              Console.WriteLine(TokenAuth.parsePublicKey(res.Content));

  //              // https://www.loxforum.com/forum/projektforen/loxberry/entwickler/118144-password%E2%80%8B-%E2%80%8Bbased-authentication%E2%80%8B-%E2%80%8B%E2%80%8Bno%E2%80%8B-%E2%80%8Blonger%E2%80%8B-%E2%80%8B%E2%80%8Bsupported%E2%80%8B-%E2%80%8Bby%E2%80%8B-%E2%80%8Bmarch%E2%80%8B-%E2%80%8B2018%E2%80%8B/page2

  //              var aes = new AesCryptoServiceProvider();
  //              aes.GenerateIV();
  //              byte[] iv = aes.IV;
  //              aes.GenerateKey();
  //              Console.WriteLine("Key base64: {0}", Convert.ToBase64String(aes.Key));

  //              Console.WriteLine("IV base64: {0}", Convert.ToBase64String(iv));

  //              // Set a key


  //              Console.WriteLine("Key base64: {0}", Convert.ToBase64String(aes.Key));



        
   
  //              // Base64 the key for storage
  //              var keyAsBase64 = Convert.ToBase64String(aes.Key);
  //              Console.WriteLine("Key base64: {0}", keyAsBase64);


  //              // 3.Generate a AES256 key-> { key } (Hex)

  //              // 4.Generate a AES256 iv-> { iv } (Hex)


  //          }

            Console.WriteLine("LoxNET.CLI end - Press any key");
            Console.ReadKey();
        }

        // https://stackoverflow.com/questions/202011/encrypt-and-decrypt-a-string-in-c/10366194#10366194
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        //Preconfigured Encryption Parameters
        public static readonly int BlockBitSize = 128;
        public static readonly int KeyBitSize = 256;

        private static void CryptoAquireToken()
        {

            UriBuilder builder = new UriBuilder("http://192.168.0.77");
            using (var request = new LxHttpRequest(builder.Uri))
            {
                CancellationToken token = new CancellationToken();
                var user = "admin";
                var password = "P@55w0rd";
                /*
                ● Acquire both the “key” & “salt” at once using “jdev/sys/getkey2/{user}”
                    ○ {user} is the username for whom to acquire the token.
                */

                var result = request.GetStringAsync($"jdev/sys/getkey2/{user}", token).Result;
                dynamic res = JObject.Parse(result).SelectToken("LL").SelectToken("value");
                Console.WriteLine("key: " + res.key);
                Console.WriteLine("salt: " + res.salt);
                //var res = ResultConverter.Deserialize(result);
                // Console.WriteLine(TokenAuth.parsePublicKey(res.Content));

                /*
                ● Hash the password including the user specific salt
                     ○ {pwHash} is the uppercase result of hashing the string “{password}:{salt}” using the SHA1 algorithm.
                     ○ {salt} is part of the result of the getkey2-Request.
                */


                var salt = res.salt.Value;
                string pwdHash;

                using (var sha1 = new SHA1Managed())
                {
                    pwdHash = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes($"{password}:{salt}"))).Replace("-", "").ToUpperInvariant();
                }

               
                Console.WriteLine("PwdHash: " + pwdHash);
                /// Up to here matches with node-lox-ws-api

                /*
                ● Create the hash that includes the user name
                    ○ {hash} is the string “{user}:{pwHash}” hashed with the key returned by the getkey2-Request using HMAC SHA1. For details on the hashing process see Hashing
                */
                byte[] hmacBytes;

                using (var stream = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(stream))
                    {
                        writer.Write(user);
                        writer.Write(":");
                        writer.Write(pwdHash);
                    }

                    //var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(salt));


                    byte[] key = StringToByteArray(res.key.Value);
                    string output = Encoding.UTF8.GetString(key);
                    Console.WriteLine("Output (key): " + output);



                    // var hmac = new HMACSHA1(key);
                    var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(output));
                    hmac.Initialize();

                    //hmacBytes = hmac.ComputeHash(stream.ToArray());
                    hmacBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes($"{user}:{pwdHash}"));

                }

                var hash = BitConverter.ToString(hmacBytes).Replace("-", "");
                Console.WriteLine($"Computed Hash: {hash}");
                /*
                ● Request a token using “jdev/sys/gettoken/{hash}/{user}/{permission}/{uuid}/{info}
                    ○ {permission} specifies the permission this token needs to grant. This impacts the tokens lifespan, e.g. a token with the web-permission (2) will last for a short period
                        of time, while a token with the app-permission (4) will last for weeks.
                    ○ The {uuid} identifies the client who is requesting the token on the Miniserver. It
                        allows to look up all tokens a client has been granted. This is why the UUID should
                        either be derived from your devices identity information or generated automatically
                        and stored within the app. It has to be in the following format as this one:
                        “098802e1-02b4-603c-ffffeee000d80cfd”.
 
                    ○ The {info} contains a (Url-Encoded) text describing the client, e.g. “Thomas%20iPhone%20X”
                */

                // https://www.loxone.com/dede/wp-content/uploads/sites/2/2016/08/0903_Communicating-with-the-Miniserver.pdf

                const int webPermission = 2;
                // const int appPermission = 4;
                var uuid = "46b9dbcc-d211-418e-ba7c7359a3cfcbfa";
                // var uuid = "098802e1-02b4-603c-ffffeee000d80cfd";

                var info = System.Net.WebUtility.UrlEncode("nodeloxwsapi");
                //string tokenRequestResult = request
                //    .GetStringAsync($"jdev/sys/gettoken/{hash}/{user}/{webPermission}/{uuid}/{info}", token).Result;

                var sendString = $"jdev/sys/gettoken/{hash}/{user}/{webPermission}/{uuid}/{info}";
                Console.WriteLine("Send String: " + sendString);

                string tokenRequestResult = request.GetStringAsync(sendString, token).Result;
                Console.WriteLine(tokenRequestResult);

                /*
                ● Store the response, it contains info on the lifespan, the permissions granted with that token and the token ID itself.
                    ○ {token} contains the token itself, this is what needs to be stored for authenticating with a token.
                    ○ {validUntil} represents the end of the tokens lifespan in seconds since 1.1.2009
 
                 */



             }



        }
        // https://stackoverflow.com/questions/36763381/how-to-convert-hex-string-to-normal-text-string-c-sharp
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        /// <summary>
        /// Helper that generates a random key on each call.
        /// </summary>
        /// <returns></returns>
        public static byte[] NewKey()
        {
            var key = new byte[KeyBitSize / 8];
            Random.GetBytes(key);
            return key;
        }


        static async Task Setup()
        {
            Console.WriteLine("LoxNET.CLI setup start");
            var bootstrap = new Bootstrap();
            await bootstrap.SetupAsync().ConfigureAwait(false);
            Console.WriteLine("LoxNET.CLI setup end");

        }

        static void Request()
        {




            //var rq = new LoxNET.Transport.Connection.LxHttpRequest(uri);
            //var tk = new CancellationToken();
            //Task t1 = rq.RequestAsync("jdev/cfg/api", tk);
            //Task t2 = rq.ResultAsync();

            /* 

            Task[] tasks = new Task[2];
            tasks[0] = rq.RequestAsync("jdev/cfg/api", tk);
            tasks[1] = rq.ResultAsync();

            Task.WaitAll(tasks);

//            Console.WriteLine(rq.Response.Status);
            Console.WriteLine("LoxNET.CLI request end");
            */
        }
    }
}
