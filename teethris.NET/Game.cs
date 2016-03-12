// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Game.cs">
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

namespace teethris.NET
{
    public class Game : IGame
    {
        public static void Main()
        {
            var game = new Game();
            TeethrisSdk.Run(game);
        }

        public void Die()
        {
        }

        public void Init()
        {
        }

        public void KeyPress(keyboardNames key)
        {
            Console.WriteLine($"Key pressed {key}");
        }

        public void Tick()
        {
            Console.WriteLine("Console tick");
        }
    }
}