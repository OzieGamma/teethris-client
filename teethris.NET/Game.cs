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
using teethris.NET.SDK;

namespace teethris.NET
{
    public class Game : IGame
    {
        public static void Main()
        {
<<<<<<< HEAD
            var game = new Game();
            TeethrisSdk.Run(game);
            Snake friend = new Snake(keyboardNames.S);
        }

        public void Die()
        {
        }

        public void Init()
        {
=======
            TeethrisSdk.Run<Game>();
>>>>>>> origin/master
        }

        public void KeyPress(keyboardNames key)
        {
            Console.WriteLine($"Key pressed {key}");
        }

        public void Tick()
        {
            Console.WriteLine("Console tick");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    
    public class Snake{
        
        private List<int> keys = new List<int>();
        private int friend = 0;
        
        public Snake(int key,int friend){
            this.friend = friend;
            this.keys.Add(key);
            LogiLedSetLightingForKeyWithKeyName(key,0,100-friend*100,friend*100);
        }
        
        public int getHead(){
            return keys[keys.Count - 1];
        }
        
        public addKey(int key){
            LogiLedSetLightingForKeyWithKeyName(getHead(),0,30-friend*30,friend*30);
            keys.Add(key);
            LogiLedSetLightingForKeyWithKeyName(getHead(),0,100-friend*100,friend*100);
        }
    }
}