// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="BoardColorerPlayer.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LedCSharp;
using teethris.NET.SDK;

namespace teethris.NET.BoardColorer
{
    internal class BoardColorerPlayer
    {
        private readonly PlayerColor color;
        private readonly List<KeyboardNames> keys;

        public BoardColorerPlayer(bool left, PlayerColor color)
        {
            this.color = color;
            var keysForOne = new List<KeyboardNames>
            {
                KeyboardNames.F1,
                KeyboardNames.F2,
                KeyboardNames.F3,
                KeyboardNames.F4,
                KeyboardNames.F5,
                KeyboardNames.F6,
                KeyboardNames.TILDE,
                KeyboardNames.ONE,
                KeyboardNames.TWO,
                KeyboardNames.THREE,
                KeyboardNames.FOUR,
                KeyboardNames.FIVE,
                KeyboardNames.SIX,
                KeyboardNames.SEVEN,
                KeyboardNames.TAB,
                KeyboardNames.Q,
                KeyboardNames.W,
                KeyboardNames.E,
                KeyboardNames.R,
                KeyboardNames.T,
                KeyboardNames.Y,
                KeyboardNames.CAPS_LOCK,
                KeyboardNames.A,
                KeyboardNames.S,
                KeyboardNames.D,
                KeyboardNames.F,
                KeyboardNames.G,
                KeyboardNames.H,
                KeyboardNames.LEFT_SHIFT,
                KeyboardNames.LEFT_BACKSLASH,
                KeyboardNames.Z,
                KeyboardNames.X,
                KeyboardNames.C,
                KeyboardNames.V,
                KeyboardNames.B,
                KeyboardNames.N,
                KeyboardNames.LEFT_CONTROL,
                KeyboardNames.SPACE
            };

            if (left)
            {
                this.keys = keysForOne.Except(KeyboardLayout.Instance.IllegalKeys).ToList();
            }
            else
            {
                this.keys =
                    KeyboardLayout.Instance.layout.Keys.Except(KeyboardLayout.Instance.IllegalKeys)
                        .Except(keysForOne)
                        .ToList();
            }

            foreach (var key in this.keys)
            {
                LogitechGSDK.SetLighting(key, color, 100);
            }
        }

        public GameState AddIfNeighbour(KeyboardNames key)
        {
            if (KeyboardLayout.Instance.IllegalKeys.Contains(key))
            {
                return GameState.Lost;
            }
            if (this.keys.Contains(key))
            {
                return GameState.Lost;
            }

            if (this.keys.All(_ => !KeyboardLayout.Instance[_].Contains(key)))
            {
                return GameState.Lost;
            }

            this.keys.Add(key);
            LogitechGSDK.SetLighting(key, this.color, 100);

            return GameState.Continue;
        }

        public GameState Remove(KeyboardNames key)
        {
            if (this.keys.Count == 0)
            {
                return GameState.Lost;
            }

            this.keys.Remove(key);

            if (this.keys.Count == 0)
            {
                return GameState.Lost;
            }

            return GameState.Continue;
        }
    }
}