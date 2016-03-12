// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="GameStateHelpers.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System.ComponentModel;

namespace teethris.NET.SDK
{
    public static class GameStateHelpers
    {
        public static GameState Opposite(GameState result)
        {
            switch (result)
            {
                case GameState.Continue:
                    return GameState.Continue;
                case GameState.Lost:
                    return GameState.Won;
                case GameState.Won:
                    return GameState.Lost;
            }

            throw new InvalidEnumArgumentException("Shouldn't exist");
        }

        public  static GameState MatrixResolution(GameState enemyResult, GameState playerResult)
        {
            if (playerResult == GameState.Won)
            {
                return GameState.Won;
            }
            if (playerResult == GameState.Lost)
            {
                return GameState.Lost;
            }
            return Opposite(enemyResult);
        }
    }
}