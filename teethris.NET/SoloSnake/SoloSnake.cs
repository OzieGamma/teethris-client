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
using teethris.NET.SDK;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace teethris.NET.SoloSnake
{
    public class SoloSnake
    {
        private readonly PlayerColor color;

        public int Size => this.CurrentSnake.Count;

        public SoloSnake(List<KeyboardNames> startKeys, PlayerColor color)
        {
            this.color = color;
            this.CurrentSnake = startKeys;
            foreach (var key in this.CurrentSnake)
            {
                SetLighting(key, color, 50);
            }
            SetLighting(this.Head, color, 100);
        }
        
        public  List<KeyboardNames> CurrentSnake { get; }

        public KeyboardNames Head => this.CurrentSnake.Last();

        public GameState Move(KeyboardNames key,  KeyboardNames food)
        {
            if (KeyboardLayout.Instance.IllegalKeys.Contains(key))
            {
                return GameState.Lost;
            }
            if (this.CurrentSnake.Contains(key))
            {
                return GameState.Lost;
            }
            if (this.CurrentSnake.Count > 10) {
                return GameState.Won;
            }

            if (key != food)
            {
                ClearLighting(this.CurrentSnake.First());
                this.CurrentSnake.RemoveAt(0);
            }

            SetLighting(this.Head, this.color, 50);
            this.CurrentSnake.Add(key);
            SetLighting(key, this.color, 100);

            return GameState.Continue;
        }
        
    }
}