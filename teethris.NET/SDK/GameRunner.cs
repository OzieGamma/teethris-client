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
using System.Threading.Tasks;

namespace teethris.NET.SDK
{
    public class GameRunner<T> where T : class, IGame, new()
    {
        private static readonly Uri Uri = new Uri("http://borisjeltsin.azurewebsites.net");
        //new Uri("http://localhost:3000/");//

        private T game;
        private MessageNetwork network;

        private bool active;
        private bool initing;

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
                if (this.MultiPlayer)
                {
                    this.network.SendKey(key);
                }

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
            if(this.initing){
                if (key == KeyboardNames.ESC)
                {
                    this.initing = false;
                    this.EndGame();
                }
                return false;
            }
            if (this.initing == false && key == KeyboardNames.ESC)
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
                if (this.MultiPlayer)
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
            this.initing = true;

            if (!LogiLedInit())
            {
                throw new LogitechException("Logitech engineers ...");
            }


            LogiLedSaveCurrentLighting();
            LogiLedSetLighting(0, 0, 0);
            Console.WriteLine("Waiting for keyboard...");
            Thread.Sleep(5000);

            this.game = new T();

            new Task(WaitForStart).Start();
        }
        
        private void WaitForStart(){
            Console.WriteLine("Waiting for start");
            
            if (this.MultiPlayer)
            {
                this.network = new MessageNetwork(this.KeyRecieved, Uri);

                // Wait to be assigned an id
				while (this.network.Id == -1)
				{
					if(this.initing == true){
						Console.WriteLine("Waiting for ID");
					} else {
						return;
					}
					Thread.Sleep(2);
				}
				
				// Wait for the countdown
				while (!this.network.Ready)
				{
					if(this.initing == true){
						Console.WriteLine("Waiting for ready signal");
					} else {
						this.network.UnReady();
						Console.WriteLine("Stopping waiting for ready...");
						return;
					}
					Thread.Sleep(200);
				}
            }
            
            Animations.Start();

            this.game.Init(this.MultiPlayer ? this.network.Id : 0);
            this.initing = false;

            this.active = true;
        }

        private void EndGame()
        {
            Console.WriteLine("End of the game !");

            if (this.MultiPlayer)
            {
                this.game = null;
                this.network.Dispose();
                this.network = null;
            }
            else
            {
                this.game = null;
            }
            this.active = false;

            LogiLedRestoreLighting();
            LogiLedShutdown();
        }

        private bool MultiPlayer => this.game.GameType == GameType.MultiPlayer;
    }
}