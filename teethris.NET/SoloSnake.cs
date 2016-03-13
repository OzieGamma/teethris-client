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
using static LedCSharp.LogitechGSDK;

namespace teethris.NET
{
    public class SoloSnake
    {
        private readonly PlayerColor color;
        public int Size { get; set; }

        public Snake(List<KeyboardNames> startKeys, PlayerColor color)
        {
            this.color = color;
            this.CurrentSnake = startKeys;
            SetLighting(key, color, 100);
        }
        
        public List<KeyboardNames> CurrentSnake { get; set; }
        
        public GameState Move(KeyboardNames key,  KeyboardNames food)
        {
            if (KeyboardLayout.Instance.IllegalKeys.Contains(key))
            {
                return GameState.Lost;
            }
            if (currentSnake.Contains(key))
            {
                return GameState.Lost;
            }
            if (currentSnake.Size > 20) {
                return GameState.Won;
            }
            
            if (key != food) { //where is keys... how to compare
                SetLighting(this.CurrentSnake.First(), color, 0);
                this.CurrentSnake.RemoveAt(0);
            }
            else {
                this.Size += 1;
            }
            
            this.CurrentSnake.Add(key);
            SetLighting(key, color, 100);

            return GameState.Continue;
        }
        
    }
}