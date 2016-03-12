// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Animations.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace teethris.NET.SDK
{
    public static class Animations
    {
        public static void Start()
        {
            Countdown();
            foreach (var key in KeyboardLayout.Instance.IllegalKeys)
            {
                SetLighting(key, PlayerColor.Red, 100);
            }
        }

        public static void Lost()
        {
            Console.WriteLine("You lost !");
            LogiLedFlashLighting(100, 0, 0, 1200, 140);
            Thread.Sleep(1300);
        }

        public static void Won()
        {
            Console.WriteLine("You won !");
            LogiLedFlashLighting(0, 100, 0, 1200, 140);
            Thread.Sleep(1300);
        }

        public static void Countdown()
        {
            ISet<KeyboardNames> threeSeconds;
            ISet<KeyboardNames> twoSeconds;
            ISet<KeyboardNames> oneSecond;


            threeSeconds =
                new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_LOCK,
                    KeyboardNames.NUM_ENTER,
                    KeyboardNames.NUM_SLASH,
                    KeyboardNames.NUM_ASTERISK,
                    KeyboardNames.NUM_MINUS,
                    KeyboardNames.NUM_PLUS,
                    KeyboardNames.NUM_PERIOD,
                    KeyboardNames.NUM_ZERO,
                    KeyboardNames.NUM_SIX,
                    KeyboardNames.NUM_FIVE,
                    KeyboardNames.NUM_FOUR
                });

            twoSeconds =
                new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_LOCK,
                    KeyboardNames.NUM_ONE,
                    KeyboardNames.NUM_SLASH,
                    KeyboardNames.NUM_ASTERISK,
                    KeyboardNames.NUM_MINUS,
                    KeyboardNames.NUM_PLUS,
                    KeyboardNames.NUM_PERIOD,
                    KeyboardNames.NUM_ZERO,
                    KeyboardNames.NUM_SIX,
                    KeyboardNames.NUM_FIVE,
                    KeyboardNames.NUM_FOUR
                });

            oneSecond =
                new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_ENTER,
                    KeyboardNames.NUM_MINUS,
                    KeyboardNames.NUM_PLUS,
                });

            foreach (var key in threeSeconds)
            {
                SetLighting(key, PlayerColor.Red, 100);
            }
            Thread.Sleep(1500);
            LogiLedSetLighting(0, 0, 0);
            foreach (var key in twoSeconds)
            {
                SetLighting(key, PlayerColor.Red, 100);
            }
            Thread.Sleep(1500);
            LogiLedSetLighting(0, 0, 0);

            foreach (var key in oneSecond)
            {
                SetLighting(key, PlayerColor.Red, 100);
            }
            Thread.Sleep(1500);
            LogiLedSetLighting(0, 0, 0);

        }
    }
}