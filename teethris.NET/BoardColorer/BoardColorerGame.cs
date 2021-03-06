﻿// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="BoardColorerGame.cs">
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
using teethris.NET.SDK;

namespace teethris.NET.BoardColorer
{
    public class BoardColorerGame : IGame
    {
        public GameType GameType => GameType.MultiPlayer;

        private BoardColorerPlayer player;
        private BoardColorerPlayer enemy;

        public void Init(long clientNumber)
        {
            this.player = new BoardColorerPlayer((clientNumber%2) == 0, PlayerColor.Green);
            this.enemy = new BoardColorerPlayer((clientNumber%2) == 1, PlayerColor.Blue);
        }

        public GameState KeyPress(KeyboardNames key)
        {
            var result = this.player.AddIfNeighbour(key);
            if (result != GameState.Continue)
            {
                return result;
            }

            result = this.enemy.Remove(key);
            if (result != GameState.Continue)
            {
                return GameStateHelpers.Opposite(result);
            }

            return GameState.Continue;
        }

        public GameState KeyReceived(KeyboardNames key)
        {
            var result = this.enemy.AddIfNeighbour(key);
            if (result != GameState.Continue)
            {
                return GameStateHelpers.Opposite(result);
            }

            result = this.player.Remove(key);
            if (result != GameState.Continue)
            {
                return result;
            }

            return GameState.Continue;
        }
    }
}