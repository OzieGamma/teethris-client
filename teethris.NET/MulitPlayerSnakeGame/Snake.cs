// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Snake.cs">
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

namespace teethris.NET.MulitPlayerSnakeGame
{
    public class Snake
    {
        private readonly PlayerColor color;
        public int Size { get; set; }

        public Snake(KeyboardNames key, PlayerColor color)
        {
            this.color = color;

            this.Head = key;
            LogitechGSDK.SetLighting(key, color, 100);
        }

        public KeyboardNames Head { get; set; }

        public void ChangeHead(KeyboardNames key)
        {
            LogitechGSDK.SetLighting(this.Head, this.color, 50);
            this.Head = key;
            LogitechGSDK.SetLighting(this.Head, this.color, 100);
            this.Size += 1;
        }

        public GameState AddIfNeighbour(KeyboardNames key, ISet<KeyboardNames> taken)
        {
            if (KeyboardLayout.Instance.IllegalKeys.Contains(key))
            {
                return GameState.Lost;
            }
            if (taken.Contains(key))
            {
                return GameState.Lost;
            }

            if (!KeyboardLayout.Instance[this.Head].Contains(key))
            {
                return GameState.Lost;
            }

            this.ChangeHead(key);
            return GameState.Continue;
        }

        public GameState CanMove(ISet<KeyboardNames> taken)
        {
            if (KeyboardLayout.Instance[this.Head].Except(KeyboardLayout.Instance.IllegalKeys).All(taken.Contains))
            {
                return GameState.Lost;
            }
            return GameState.Continue;
        }
    }
}