// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Network.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
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
    public class MessageNetwork
    {
        private readonly string channelName;
        private readonly Socket socket;

        public MessageNetwork(Action<KeyboardNames> keyRecieved, Uri uri, string channelName)
        {
            this.channelName = channelName;
            this.socket = IO.Socket(uri);

            this.socket.On(Socket.EVENT_CONNECT, () =>
            {
                /* this.socket.Emit(ChannelName, "hi"); */
            });

            this.socket.On(channelName, data =>
            {
                KeyboardNames key;
                var success = Enum.TryParse((string) data, out key);
                if (!success)
                {
                    throw new SocketIOException("Couldn't parse");
                }
                {
                    keyRecieved(key);
                }
            });
        }

        public void SendKey(KeyboardNames key)
        {
            this.socket.Emit(this.channelName, key.ToString());
        }
    }
}