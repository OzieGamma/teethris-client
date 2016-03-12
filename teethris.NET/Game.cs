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
    public class Game : IGame
    {
        public static void Main()
        {
            Engine.Run<Game>();
        }

        private readonly Snake player;
        private readonly Snake enemy;

        private readonly ISet<KeyboardNames> taken = new HashSet<KeyboardNames>();

        public Game()
        {
            this.player = new Snake(KeyboardNames.S, PlayerColor.Green);
            this.enemy = new Snake(KeyboardNames.NUM_SIX, PlayerColor.Blue);
        }

        public GameState KeyPress(KeyboardNames key)
        {
            var result = this.player.AddIfNeighbour(key, this.taken);
            if (result == GameState.Continue)
            {
                this.taken.Add(key);
                var enemyResult = this.enemy.CanMove(this.taken);
                var playerResult = this.enemy.CanMove(this.taken);
                return GameStateHelpers.MatrixResolution(enemyResult, playerResult);
            }
            return result;
        }

        public GameState KeyReceived(KeyboardNames key)
        {
            var result = this.enemy.AddIfNeighbour(key, this.taken);
            if (result == GameState.Continue)
            {
                this.taken.Add(key);
                var enemyResult =  this.enemy.CanMove(this.taken);
                var playerResult = this.enemy.CanMove(this.taken);
                return GameStateHelpers.MatrixResolution(enemyResult, playerResult);
            }
            return GameStateHelpers.Opposite(result);
        }
    }
}