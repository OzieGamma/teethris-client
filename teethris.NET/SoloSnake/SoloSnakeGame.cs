// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="SoloSnakeGame.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LedCSharp;
using teethris.NET.SDK;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace teethris.NET.SoloSnake
{
    public class SoloSnakeGame : IGame
    {
        private SoloSnake player;
        private KeyboardNames food;
        private Random random;

        public void Init(long clientNumber)
        {
            var startKeys = new List<KeyboardNames>
            {
                KeyboardNames.A,
                KeyboardNames.S,
                KeyboardNames.D,
                KeyboardNames.F
            };
            this.random = new Random();
            this.player = new SoloSnake(startKeys, PlayerColor.Blue);
            this.GenerateFood();
        }

        public GameType GameType => GameType.Solo;

        private void GenerateFood()
        {
            List<KeyboardNames> possibleKeys = KeyboardLayout.Instance.layout.Keys.Except(this.player.CurrentSnake)
                .Except(KeyboardLayout.Instance.IllegalKeys).ToList();

            this.food = possibleKeys[this.random.Next(0, possibleKeys.Count)];

            SetLighting(this.food, PlayerColor.Green, 100);
        }

        public GameState KeyPress(KeyboardNames key)
        {
            var result = this.player.Move(key, this.food);

            if ((result == GameState.Continue) && (key == this.food))
            {
                this.GenerateFood();
            }

            return result;
        }

        public GameState KeyReceived(KeyboardNames key)
        {
            // Ignored
            return GameState.Continue;
        }
    }
}