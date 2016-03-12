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
using static LedCSharp.LogitechGSDK;

namespace teethris.NET
{
    public class Snake
    {
        private readonly List<keyboardNames> keys = new List<keyboardNames>();
        private readonly PlayerColor color;
        private keyboardNames s;

        public Snake(keyboardNames key, PlayerColor color)
        {
            this.color = color;
            this.keys.Add(key);

            SetLighting(key, color, 100);
        }

        public Snake(keyboardNames s)
        {
            this.s = s;
        }

        public keyboardNames Head => this.keys.First();

        public void Add(keyboardNames key)
        {
            SetLighting(this.Head, this.color, 30);

            this.keys.Add(key);

            SetLighting(this.Head, this.color, 100);
        }
    }
}