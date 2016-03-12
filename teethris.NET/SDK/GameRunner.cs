// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="GameRunner.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using LedCSharp;

namespace teethris.NET.SDK
{
    public class GameRunner<T> where T : class, IGame, new()
    {
        private T game;
        private bool active;

        public void Tick()
        {
            if (this.active)
            {
                this.game.Tick();
            }
        }

        /// <summary>
        ///     Event handler for a pressed key
        /// </summary>
        /// <param name="key">
        ///     The Key that was just pressed.
        /// </param>
        /// <returns>
        ///     Whether the key pressed event should be passed to the next piece of
        ///     software down the chain.
        /// </returns>
        public bool KeyPressed(keyboardNames key)
        {
            if (this.active)
            {
                if (key == keyboardNames.ESC)
                {
                    this.game.Dispose();
                    this.game = null;
                    this.active = false;
                    return true;
                }
                this.game.KeyPress(key);
                return false;
            }
            if (key == keyboardNames.ESC)
            {
                this.game = new T();
                return false;
            }
            return true;
        }
    }
}