// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="KeyboardLayout.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System.Collections.Generic;
using LedCSharp;

namespace teethris.NET.SDK
{
    public class KeyboardLayout
    {
        private static KeyboardLayout instance;

        public static KeyboardLayout Instance => instance ?? (instance = new KeyboardLayout());

        public readonly IDictionary<KeyboardNames, ISet<KeyboardNames>> layout;

        public int Count => this.layout.Count;
        public ISet<KeyboardNames> this[KeyboardNames key] => new HashSet<KeyboardNames>(this.layout[key]);

        private readonly ISet<KeyboardNames> illegalKeys;

        public ISet<KeyboardNames> IllegalKeys => new HashSet<KeyboardNames>(this.illegalKeys);


        private KeyboardLayout()
        {
            this.layout = new Dictionary<KeyboardNames, ISet<KeyboardNames>>
            {
                [KeyboardNames.F1] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.ONE,
                    KeyboardNames.TWO,
                    KeyboardNames.F2
                }),
                [KeyboardNames.F2] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F1,
                    KeyboardNames.F3,
                    KeyboardNames.TWO,
                    KeyboardNames.THREE
                }),
                [KeyboardNames.F3] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F2,
                    KeyboardNames.F4,
                    KeyboardNames.THREE,
                    KeyboardNames.FOUR
                }),
                [KeyboardNames.F4] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F3,
                    KeyboardNames.F5,
                    KeyboardNames.FOUR,
                    KeyboardNames.FIVE
                }),
                [KeyboardNames.F5] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F6,
                    KeyboardNames.F4,
                    KeyboardNames.SIX,
                    KeyboardNames.SEVEN
                }),
                [KeyboardNames.F6] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F7,
                    KeyboardNames.F5,
                    KeyboardNames.SEVEN,
                    KeyboardNames.EIGHT
                }),
                [KeyboardNames.F7] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F6,
                    KeyboardNames.F8,
                    KeyboardNames.EIGHT,
                    KeyboardNames.NINE
                }),
                [KeyboardNames.F8] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F7,
                    KeyboardNames.F9,
                    KeyboardNames.NINE,
                    KeyboardNames.ZERO
                }),
                [KeyboardNames.F9] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F10,
                    KeyboardNames.F8,
                    KeyboardNames.MINUS
                }),
                [KeyboardNames.F10] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F9,
                    KeyboardNames.F11,
                    KeyboardNames.EQUALS
                }),
                [KeyboardNames.F11] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F10,
                    KeyboardNames.F12,
                    KeyboardNames.BACKSPACE
                }),
                [KeyboardNames.F12] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F11,
                    KeyboardNames.PRINT_SCREEN,
                    KeyboardNames.BACKSPACE
                }),
                [KeyboardNames.PRINT_SCREEN] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F12,
                    KeyboardNames.SCROLL_LOCK,
                    KeyboardNames.INSERT
                }),
                [KeyboardNames.SCROLL_LOCK] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.PRINT_SCREEN,
                    KeyboardNames.PAUSE_BREAK,
                    KeyboardNames.HOME
                }),
                [KeyboardNames.PAUSE_BREAK] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.SCROLL_LOCK,
                    KeyboardNames.PAGE_UP
                }),
                [KeyboardNames.TILDE] =
                    new HashSet<KeyboardNames>(new List<KeyboardNames> {KeyboardNames.ONE, KeyboardNames.TAB}),
                [KeyboardNames.ONE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F1,
                    KeyboardNames.TILDE,
                    KeyboardNames.TWO,
                    KeyboardNames.Q,
                    KeyboardNames.TAB
                }),
                [KeyboardNames.TWO] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F1,
                    KeyboardNames.F2,
                    KeyboardNames.ONE,
                    KeyboardNames.THREE,
                    KeyboardNames.Q,
                    KeyboardNames.W
                }),
                [KeyboardNames.THREE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F2,
                    KeyboardNames.F3,
                    KeyboardNames.TWO,
                    KeyboardNames.FOUR,
                    KeyboardNames.W,
                    KeyboardNames.E
                }),
                [KeyboardNames.FOUR] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F3,
                    KeyboardNames.F4,
                    KeyboardNames.THREE,
                    KeyboardNames.FIVE,
                    KeyboardNames.E,
                    KeyboardNames.R
                }),
                [KeyboardNames.FIVE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F4,
                    KeyboardNames.FOUR,
                    KeyboardNames.SIX,
                    KeyboardNames.R,
                    KeyboardNames.T
                }),
                [KeyboardNames.SIX] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F5,
                    KeyboardNames.FIVE,
                    KeyboardNames.SEVEN,
                    KeyboardNames.T,
                    KeyboardNames.Y
                }),
                [KeyboardNames.SEVEN] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F5,
                    KeyboardNames.F6,
                    KeyboardNames.SIX,
                    KeyboardNames.EIGHT,
                    KeyboardNames.Y,
                    KeyboardNames.U
                }),
                [KeyboardNames.EIGHT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F6,
                    KeyboardNames.F7,
                    KeyboardNames.SEVEN,
                    KeyboardNames.NINE,
                    KeyboardNames.U,
                    KeyboardNames.I
                }),
                [KeyboardNames.NINE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F7,
                    KeyboardNames.F8,
                    KeyboardNames.EIGHT,
                    KeyboardNames.ZERO,
                    KeyboardNames.I,
                    KeyboardNames.O
                }),
                [KeyboardNames.ZERO] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F8,
                    KeyboardNames.NINE,
                    KeyboardNames.MINUS,
                    KeyboardNames.O,
                    KeyboardNames.P
                }),
                [KeyboardNames.MINUS] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F9,
                    KeyboardNames.ZERO,
                    KeyboardNames.EQUALS,
                    KeyboardNames.P,
                    KeyboardNames.OPEN_BRACKET
                }),
                [KeyboardNames.EQUALS] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F10,
                    KeyboardNames.MINUS,
                    KeyboardNames.BACKSPACE,
                    KeyboardNames.OPEN_BRACKET,
                    KeyboardNames.CLOSE_BRACKET
                }),
                [KeyboardNames.BACKSPACE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.EQUALS,
                    KeyboardNames.F11,
                    KeyboardNames.F12,
                    KeyboardNames.CLOSE_BRACKET,
                    KeyboardNames.INSERT
                }),
                [KeyboardNames.INSERT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.PRINT_SCREEN,
                    KeyboardNames.HOME,
                    KeyboardNames.BACKSPACE,
                    KeyboardNames.KEYBOARD_DELETE
                }),
                [KeyboardNames.HOME] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.SCROLL_LOCK,
                    KeyboardNames.INSERT,
                    KeyboardNames.PAGE_UP,
                    KeyboardNames.END
                }),
                [KeyboardNames.PAGE_UP] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.PAUSE_BREAK,
                    KeyboardNames.HOME,
                    KeyboardNames.PAGE_DOWN
                }),
                [KeyboardNames.NUM_SLASH] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_ASTERISK,
                    KeyboardNames.NUM_EIGHT
                }),
                [KeyboardNames.NUM_ASTERISK] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_SLASH,
                    KeyboardNames.NUM_MINUS,
                    KeyboardNames.NUM_NINE
                }),
                [KeyboardNames.NUM_MINUS] =
                    new HashSet<KeyboardNames>(new List<KeyboardNames>
                    {
                        KeyboardNames.NUM_ASTERISK,
                        KeyboardNames.NUM_PLUS
                    }),
                [KeyboardNames.TAB] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.TILDE,
                    KeyboardNames.CAPS_LOCK,
                    KeyboardNames.Q,
                    KeyboardNames.ONE
                }),
                [KeyboardNames.Q] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.TAB,
                    KeyboardNames.W,
                    KeyboardNames.ONE,
                    KeyboardNames.TWO,
                    KeyboardNames.CAPS_LOCK,
                    KeyboardNames.A
                }),
                [KeyboardNames.W] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.Q,
                    KeyboardNames.E,
                    KeyboardNames.TWO,
                    KeyboardNames.THREE,
                    KeyboardNames.A,
                    KeyboardNames.S
                }),
                [KeyboardNames.E] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.W,
                    KeyboardNames.R,
                    KeyboardNames.THREE,
                    KeyboardNames.FOUR,
                    KeyboardNames.S,
                    KeyboardNames.D
                }),
                [KeyboardNames.R] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.E,
                    KeyboardNames.T,
                    KeyboardNames.FOUR,
                    KeyboardNames.FIVE,
                    KeyboardNames.D,
                    KeyboardNames.F
                }),
                [KeyboardNames.T] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.R,
                    KeyboardNames.Y,
                    KeyboardNames.FIVE,
                    KeyboardNames.SIX,
                    KeyboardNames.F,
                    KeyboardNames.G
                }),
                [KeyboardNames.Y] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.T,
                    KeyboardNames.U,
                    KeyboardNames.SIX,
                    KeyboardNames.SEVEN,
                    KeyboardNames.G,
                    KeyboardNames.H
                }),
                [KeyboardNames.U] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.Y,
                    KeyboardNames.I,
                    KeyboardNames.SEVEN,
                    KeyboardNames.EIGHT,
                    KeyboardNames.H,
                    KeyboardNames.J
                }),
                [KeyboardNames.I] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.U,
                    KeyboardNames.O,
                    KeyboardNames.EIGHT,
                    KeyboardNames.NINE,
                    KeyboardNames.J,
                    KeyboardNames.K
                }),
                [KeyboardNames.O] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.I,
                    KeyboardNames.P,
                    KeyboardNames.NINE,
                    KeyboardNames.ZERO,
                    KeyboardNames.K,
                    KeyboardNames.L
                }),
                [KeyboardNames.P] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.O,
                    KeyboardNames.OPEN_BRACKET,
                    KeyboardNames.ZERO,
                    KeyboardNames.MINUS,
                    KeyboardNames.L,
                    KeyboardNames.SEMICOLON
                }),
                [KeyboardNames.OPEN_BRACKET] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.P,
                    KeyboardNames.CLOSE_BRACKET,
                    KeyboardNames.MINUS,
                    KeyboardNames.EQUALS,
                    KeyboardNames.SEMICOLON,
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.RIGHT_BACKSLASH
                }),
                [KeyboardNames.CLOSE_BRACKET] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.OPEN_BRACKET,
                    KeyboardNames.EQUALS,
                    KeyboardNames.BACKSPACE,
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.RIGHT_BACKSLASH
                }),
                [KeyboardNames.KEYBOARD_DELETE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.END,
                    KeyboardNames.ARROW_LEFT,
                    KeyboardNames.INSERT,
                    KeyboardNames.ARROW_UP
                }),
                [KeyboardNames.END] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.KEYBOARD_DELETE,
                    KeyboardNames.PAGE_DOWN,
                    KeyboardNames.HOME,
                    KeyboardNames.ARROW_UP
                }),
                [KeyboardNames.PAGE_DOWN] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_SEVEN,
                    KeyboardNames.PAGE_UP,
                    KeyboardNames.END,
                    KeyboardNames.ARROW_UP,
                    KeyboardNames.ARROW_RIGHT
                }),
                [KeyboardNames.NUM_SEVEN] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.PAGE_DOWN,
                    KeyboardNames.NUM_EIGHT,
                    KeyboardNames.NUM_FOUR
                }),
                [KeyboardNames.NUM_EIGHT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_SEVEN,
                    KeyboardNames.NUM_NINE,
                    KeyboardNames.NUM_SLASH,
                    KeyboardNames.NUM_FIVE
                }),
                [KeyboardNames.NUM_NINE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_EIGHT,
                    KeyboardNames.NUM_PLUS,
                    KeyboardNames.NUM_ASTERISK,
                    KeyboardNames.NUM_SIX
                }),
                [KeyboardNames.CAPS_LOCK] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.TAB,
                    KeyboardNames.LEFT_SHIFT,
                    KeyboardNames.Q,
                    KeyboardNames.A,
                    KeyboardNames.LEFT_BACKSLASH
                }),
                [KeyboardNames.A] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.CAPS_LOCK,
                    KeyboardNames.Q,
                    KeyboardNames.LEFT_BACKSLASH,
                    KeyboardNames.S,
                    KeyboardNames.W,
                    KeyboardNames.Z
                }),
                [KeyboardNames.S] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.A,
                    KeyboardNames.D,
                    KeyboardNames.W,
                    KeyboardNames.Z,
                    KeyboardNames.X,
                    KeyboardNames.E
                }),
                [KeyboardNames.D] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.S,
                    KeyboardNames.E,
                    KeyboardNames.R,
                    KeyboardNames.F,
                    KeyboardNames.C,
                    KeyboardNames.X
                }),
                [KeyboardNames.F] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.D,
                    KeyboardNames.R,
                    KeyboardNames.T,
                    KeyboardNames.G,
                    KeyboardNames.V,
                    KeyboardNames.C
                }),
                [KeyboardNames.G] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.F,
                    KeyboardNames.T,
                    KeyboardNames.Y,
                    KeyboardNames.H,
                    KeyboardNames.B,
                    KeyboardNames.V
                }),
                [KeyboardNames.H] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.G,
                    KeyboardNames.Y,
                    KeyboardNames.U,
                    KeyboardNames.J,
                    KeyboardNames.N,
                    KeyboardNames.B
                }),
                [KeyboardNames.J] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.H,
                    KeyboardNames.U,
                    KeyboardNames.I,
                    KeyboardNames.K,
                    KeyboardNames.M,
                    KeyboardNames.N
                }),
                [KeyboardNames.K] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.J,
                    KeyboardNames.I,
                    KeyboardNames.O,
                    KeyboardNames.L,
                    KeyboardNames.M,
                    KeyboardNames.COMMA
                }),
                [KeyboardNames.L] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.K,
                    KeyboardNames.O,
                    KeyboardNames.P,
                    KeyboardNames.SEMICOLON,
                    KeyboardNames.COMMA,
                    KeyboardNames.PERIOD
                }),
                [KeyboardNames.SEMICOLON] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.L,
                    KeyboardNames.P,
                    KeyboardNames.OPEN_BRACKET,
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.PERIOD,
                    KeyboardNames.FORWARD_SLASH
                }),
                [KeyboardNames.APOSTROPHE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.SEMICOLON,
                    KeyboardNames.OPEN_BRACKET,
                    KeyboardNames.CLOSE_BRACKET,
                    KeyboardNames.RIGHT_BACKSLASH,
                    KeyboardNames.RIGHT_SHIFT,
                    KeyboardNames.FORWARD_SLASH
                }),
                [KeyboardNames.RIGHT_BACKSLASH] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.CLOSE_BRACKET,
                    KeyboardNames.RIGHT_SHIFT
                }),
                [KeyboardNames.NUM_FOUR] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_SEVEN,
                    KeyboardNames.NUM_FIVE,
                    KeyboardNames.NUM_ONE
                }),
                [KeyboardNames.NUM_FIVE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_FOUR,
                    KeyboardNames.NUM_SIX,
                    KeyboardNames.NUM_EIGHT,
                    KeyboardNames.NUM_TWO
                }),
                [KeyboardNames.NUM_SIX] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_FIVE,
                    KeyboardNames.NUM_NINE,
                    KeyboardNames.NUM_THREE,
                    KeyboardNames.NUM_PLUS
                }),
                [KeyboardNames.NUM_PLUS] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_MINUS,
                    KeyboardNames.NUM_NINE,
                    KeyboardNames.NUM_SIX
                }),
                [KeyboardNames.LEFT_SHIFT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.CAPS_LOCK,
                    KeyboardNames.LEFT_CONTROL,
                    KeyboardNames.LEFT_BACKSLASH
                }),
                [KeyboardNames.LEFT_BACKSLASH] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.LEFT_SHIFT,
                    KeyboardNames.LEFT_CONTROL,
                    KeyboardNames.A,
                    KeyboardNames.Z,
                    KeyboardNames.CAPS_LOCK

                }),
                [KeyboardNames.Z] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.LEFT_BACKSLASH,
                    KeyboardNames.A,
                    KeyboardNames.S,
                    KeyboardNames.X,
                    KeyboardNames.LEFT_ALT
                }),
                [KeyboardNames.X] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.Z,
                    KeyboardNames.S,
                    KeyboardNames.D,
                    KeyboardNames.C,
                    KeyboardNames.LEFT_ALT,
                    KeyboardNames.SPACE
                }),
                [KeyboardNames.C] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.X,
                    KeyboardNames.D,
                    KeyboardNames.F,
                    KeyboardNames.V,
                    KeyboardNames.SPACE
                }),
                [KeyboardNames.V] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.C,
                    KeyboardNames.F,
                    KeyboardNames.G,
                    KeyboardNames.SPACE,
                    KeyboardNames.B
                }),
                [KeyboardNames.B] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.V,
                    KeyboardNames.G,
                    KeyboardNames.H,
                    KeyboardNames.SPACE,
                    KeyboardNames.N
                }),
                [KeyboardNames.N] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.B,
                    KeyboardNames.H,
                    KeyboardNames.J,
                    KeyboardNames.M,
                    KeyboardNames.SPACE
                }),
                [KeyboardNames.M] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.N,
                    KeyboardNames.J,
                    KeyboardNames.K,
                    KeyboardNames.SPACE,
                    KeyboardNames.COMMA
                }),
                [KeyboardNames.COMMA] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.M,
                    KeyboardNames.K,
                    KeyboardNames.L,
                    KeyboardNames.SPACE,
                    KeyboardNames.PERIOD,
                    KeyboardNames.RIGHT_ALT
                }),
                [KeyboardNames.PERIOD] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.COMMA,
                    KeyboardNames.L,
                    KeyboardNames.SEMICOLON,
                    KeyboardNames.FORWARD_SLASH,
                    KeyboardNames.RIGHT_ALT
                }),
                [KeyboardNames.FORWARD_SLASH] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.PERIOD,
                    KeyboardNames.SEMICOLON,
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.RIGHT_SHIFT,
                    KeyboardNames.APPLICATION_SELECT
                }),
                [KeyboardNames.RIGHT_SHIFT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.APPLICATION_SELECT,
                    KeyboardNames.FORWARD_SLASH,
                    KeyboardNames.APOSTROPHE,
                    KeyboardNames.RIGHT_BACKSLASH,
                    KeyboardNames.RIGHT_CONTROL,
                    KeyboardNames.ARROW_UP
                }),
                [KeyboardNames.ARROW_UP] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.RIGHT_SHIFT,
                    KeyboardNames.KEYBOARD_DELETE,
                    KeyboardNames.END,
                    KeyboardNames.PAGE_DOWN,
                    KeyboardNames.NUM_ONE,
                    KeyboardNames.ARROW_DOWN
                }),
                [KeyboardNames.NUM_ONE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.ARROW_UP,
                    KeyboardNames.NUM_FOUR,
                    KeyboardNames.NUM_TWO,
                    KeyboardNames.NUM_ZERO
                }),
                [KeyboardNames.NUM_TWO] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_ONE,
                    KeyboardNames.NUM_THREE,
                    KeyboardNames.NUM_ZERO,
                    KeyboardNames.NUM_FIVE
                }),
                [KeyboardNames.NUM_THREE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_TWO,
                    KeyboardNames.NUM_SIX,
                    KeyboardNames.NUM_PERIOD
                }),
                [KeyboardNames.LEFT_CONTROL] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.LEFT_SHIFT,
                    KeyboardNames.LEFT_BACKSLASH
                }),
                [KeyboardNames.LEFT_ALT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.Z,
                    KeyboardNames.X,
                    KeyboardNames.SPACE
                }),
                [KeyboardNames.SPACE] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.LEFT_ALT,
                    KeyboardNames.X,
                    KeyboardNames.C,
                    KeyboardNames.V,
                    KeyboardNames.B,
                    KeyboardNames.N,
                    KeyboardNames.M,
                    KeyboardNames.COMMA,
                    KeyboardNames.RIGHT_ALT
                }),
                [KeyboardNames.RIGHT_ALT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.SPACE,
                    KeyboardNames.COMMA,
                    KeyboardNames.PERIOD
                }),
                [KeyboardNames.APPLICATION_SELECT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.RIGHT_SHIFT,
                    KeyboardNames.RIGHT_CONTROL
                }),
                [KeyboardNames.RIGHT_CONTROL] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.APPLICATION_SELECT,
                    KeyboardNames.RIGHT_SHIFT,
                    KeyboardNames.ARROW_LEFT
                }),
                [KeyboardNames.ARROW_LEFT] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.ARROW_DOWN,
                    KeyboardNames.RIGHT_CONTROL
                }),
                [KeyboardNames.ARROW_DOWN] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.ARROW_LEFT,
                    KeyboardNames.ARROW_UP,
                    KeyboardNames.ARROW_RIGHT
                }),
                [KeyboardNames.ARROW_RIGHT] =
                    new HashSet<KeyboardNames>(new List<KeyboardNames>
                    {
                        KeyboardNames.ARROW_DOWN,
                        KeyboardNames.NUM_ZERO
                    }),
                [KeyboardNames.NUM_ZERO] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_PERIOD,
                    KeyboardNames.NUM_ONE,
                    KeyboardNames.NUM_TWO,
                    KeyboardNames.ARROW_RIGHT
                }),
                [KeyboardNames.NUM_PERIOD] = new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.NUM_THREE,
                    KeyboardNames.NUM_TWO,
                    KeyboardNames.NUM_ZERO
                })

            };

            this.illegalKeys =
                new HashSet<KeyboardNames>(new List<KeyboardNames>
                {
                    KeyboardNames.RIGHT_WINDOWS,
                    KeyboardNames.LEFT_WINDOWS,
                    KeyboardNames.NUM_LOCK,
                    KeyboardNames.ENTER,
                    KeyboardNames.NUM_ENTER,
                    KeyboardNames.RIGHT_ALT,
                    KeyboardNames.LEFT_ALT
                });
        }
    }
}