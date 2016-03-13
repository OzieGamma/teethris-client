// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zo� PETARD" file="Network.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zo� PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using LedCSharp;
using Quobject.SocketIoClientDotNet.Client;

namespace teethris.NET.SDK
{
    public class MessageNetwork : IDisposable
    {
        private const string MsgChannel = "msg";
        private const string IdChannel = "id";
        private const string ReadyChannel = "ready";
        
        private readonly Socket socket;

        public long Id { get; set; }
        public bool Ready {get; set; }

        public MessageNetwork(Action<KeyboardNames> keyRecieved, Uri uri)
        {
            this.Id = -1;
            this.Ready = false;

            this.socket = IO.Socket(uri);

            this.socket.On(Socket.EVENT_CONNECT, () => { });

            this.socket.On(MsgChannel, data =>
            {
                KeyboardNames key;
                Console.WriteLine($"Got msg {(string) data}");
                var success = Enum.TryParse((string) data, out key);
                if (!success)
                {
                    throw new SocketIOException("Couldn't parse");
                }
                {
                    keyRecieved(key);
                }
            });

            this.socket.On(IdChannel, data =>
            {
                this.Id = (long) data;
                Console.WriteLine($"Got id {(long) data}");
            });
            
            this.socket.On(ReadyChannel, data =>
            {
                this.Ready = true;
                Console.WriteLine($"Got ready signal {(string) data}");
            });
            this.socket.Emit(ReadyChannel, "ready");
        }
        
        public void UnReady(){
            this.socket.Emit(ReadyChannel, "unready");
        }

        public void SendKey(KeyboardNames key)
        {
            this.socket.Emit(MsgChannel, key.ToString());
        }

        public void Dispose()
        {
            this.socket.Close();
        }
    }
}