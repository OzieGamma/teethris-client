// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Game.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System.Collections.Generic;
using LedCSharp;
using teethris.NET.SDK;

namespace teethris.NET
{
    public class SoloSnakeGame : IGame
    {
        public static void Main()
        {
            Engine.Run<SoloSnakeGame>();
        }

        private SoloSnake player;        
        private KeyboardNames food;

        public void Init()
        {
            List<KeyboardNames> startKeys = new List<KeyboardNames>(
                KeyboardNames.A,
                KeyboardNames.S,
                KeyboardNames.D,
                KeyboardNames.F
            );
             this.player = new SoloSnake(startKeys, PlayerColor.Green);              
        }

        public GameState KeyPress(KeyboardNames key)
        {
            return result = this.player.Move(key, this.food);
        }
    }
}