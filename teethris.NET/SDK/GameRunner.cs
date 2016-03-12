// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="GameRunner.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.Threading;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace teethris.NET.SDK
{
    public class GameRunner<T> where T : class, IGame, new()
    {
        private static readonly Uri Uri = new Uri("http://borisjeltsin.azurewebsites.net");
            //new Uri("http://localhost:3000/");//

        private T game;
        private MessageNetwork network;

        private bool active;

        /// <summary>
        ///     Event handler for a pressed key
        /// </summary>
        /// <param name="key">
        ///     The Key that was just pressed.
        /// </param>
        /// <returns>
        ///     Whether the key pressed event should be passed to the next piece of
        ///     software down the chain.
        /// </returns>
        public bool KeyPressed(KeyboardNames key)
        {
            Console.WriteLine($"Key pressed {key}");


            if (this.active)
            {
                this.network.SendKey(key);
                if (key == KeyboardNames.ESC)
                {
                    this.EndGame();
                }
                else
                {
                    this.AcknowledgeState(this.game.KeyPress(key));
                }
                return false;
            }
            if (key == KeyboardNames.ESC)
            {
                this.NewGame();
                return false;
            }
            return true;
        }

        private void KeyRecieved(KeyboardNames key)
        {
            Console.WriteLine($"Key recieved {key}");

            if (this.active)
            {
                if (key == KeyboardNames.ESC)
                {
                    this.AcknowledgeState(GameState.Won);
                }
                else
                {
                    this.AcknowledgeState(this.game.KeyReceived(key));
                }
            }
        }

        private void AcknowledgeState(GameState state)
        {
            switch (state)
            {
                case GameState.Won:
                    Animations.Won();
                    this.EndGame();
                    break;
                case GameState.Lost:
                    Animations.Lost();
                    this.EndGame();
                    break;
                case GameState.Continue:
                    break;
            }
        }


        private void NewGame()
        {
            Console.WriteLine("Begin of the game !");

            if (!LogiLedInit())
            {
                throw new LogitechException("Logitech engineers ...");
            }

            LogiLedSaveCurrentLighting();
            LogiLedSetLighting(0, 0, 0);

            Animations.Start();

            this.game = new T();

            this.network = new MessageNetwork(this.KeyRecieved, Uri, this.EndGame);

            // Wait to be assigned an id
            while (this.network.Id == -1)
            {
                Console.WriteLine("Waiting for ID");
                Thread.Sleep(2);
            }

            this.game.Init(this.network.Id);
            this.active = true;
        }

        private void EndGame()
        {
            Console.WriteLine("End of the game !");
            this.game = null;
            this.active = false;

            LogiLedRestoreLighting();
            LogiLedShutdown();
        }
    }
}