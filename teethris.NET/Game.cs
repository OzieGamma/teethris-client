// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Game.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.Drawing;
using LedCSharp;
using teethris.NET.SDK;
using static LedCSharp.LogitechGSDK;

namespace teethris.NET
{
    public class Game : IGame
    {
        private const string ChannelName = "chat message";
        private static readonly Uri Uri = new Uri("http://borisjeltsin.azurewebsites.net");

        public static void Main()
        {
            Engine.Run<Game>();
        }

        private readonly Snake player;
        private readonly Snake enemy;
        private readonly MessageNetwork network;

        public Game()
        {
            if (!LogiLedInit())
            {
                throw new LogitechException("Logitech engineers ...");
            }
            LogiLedSaveCurrentLighting();
            LogiLedSetLighting(0, 0, 0);
            this.StartAnimation();
            this.player = new Snake(KeyboardNames.S, PlayerColor.Green);
            this.enemy = new Snake(KeyboardNames.NUM_SIX, PlayerColor.Blue);
            this.network = new MessageNetwork(this.KeyReceived, Uri, ChannelName);
        }

        public void KeyPress(KeyboardNames key)
        {
            if (!this.player.AddIfNeighbour(key))
            {
                
            }
            Console.WriteLine($"Key pressed {key}");
            this.network.SendKey(key);
            this.player.AddIfNeighbour(key);
        }
        
        public void KeyReceived(KeyboardNames key){
            Console.WriteLine($"Key recieved: {key}");
            this.enemy.Add(key);
        }
        
        public void Tick()
        {
            //Console.WriteLine("Console tick");
        }

        public void Dispose()
        {
            LogiLedRestoreLighting();
            LogiLedShutdown();
        }

        public void StartAnimation()
        {
            foreach (var key in KeyboardLayout.Instance.IllegalKeys)
            {
                SetLighting(key, PlayerColor.Red, 100);

            }
        }
    }
}