// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="TeethrisSdk.cs">
// Copyright 2014-2016 Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LedCSharp;

namespace teethris.NET
{
    public class TeethrisSdk
    {
        private const int WhKeyboardLl = 13;
        private const int WmKeydown = 0x0100;
        private static IntPtr hookId = IntPtr.Zero;

        public static void Run(Game game)
        {
            var gameManager = new GameManager(game);

            hookId = SetHook(HookCallback(gameManager.KeyPressed));

            var timer = new Timer {Interval = 10};
            timer.Tick += (sender, args) => gameManager.Tick();
            timer.Start();

            Application.Run();
            Console.WriteLine("asf");
            UnhookWindowsHookEx(hookId);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            {
                using (var curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WhKeyboardLl, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static LowLevelKeyboardProc HookCallback(Func<keyboardNames, bool> keyPressed)
        {
            return (nCode, wParam, lParam) =>
            {
                bool callNext = true;

                if ((nCode >= 0) && (wParam == (IntPtr) WmKeydown))
                {
                    var vkCode = Marshal.ReadInt32(lParam);
                    callNext = keyPressed(VkToKeyboardName(vkCode));
                }

                if (callNext)
                {
                    return CallNextHookEx(hookId, nCode, wParam, lParam);
                }
                return IntPtr.Zero;
            };
        }

        private static keyboardNames VkToKeyboardName(int vkCode)
        {
            switch (vkCode)
            {
                case 8:
                    return keyboardNames.BACKSPACE;
                case 9:
                    return keyboardNames.TAB;
                case 13:
                    return keyboardNames.ENTER;
                case 19:
                    return keyboardNames.PAUSE_BREAK;
                case 20:
                    return keyboardNames.CAPS_LOCK;
                case 27:
                    return keyboardNames.ESC;
                case 32:
                    return keyboardNames.SPACE;
                case 33:
                    return keyboardNames.PAGE_UP;
                case 34:
                    return keyboardNames.PAGE_DOWN;
                case 35:
                    return keyboardNames.END;
                case 36:
                    return keyboardNames.HOME;
                case 37:
                    return keyboardNames.ARROW_LEFT;
                case 38:
                    return keyboardNames.ARROW_UP;
                case 39:
                    return keyboardNames.ARROW_RIGHT;
                case 40:
                    return keyboardNames.ARROW_DOWN;
                case 44:
                    return keyboardNames.PRINT_SCREEN;
                case 45:
                    return keyboardNames.INSERT;
                case 46:
                    return keyboardNames.KEYBOARD_DELETE;
                case 48:
                    return keyboardNames.ZERO;
                case 49:
                    return keyboardNames.ONE;
                case 50:
                    return keyboardNames.TWO;
                case 51:
                    return keyboardNames.THREE;
                case 52:
                    return keyboardNames.FOUR;
                case 53:
                    return keyboardNames.FIVE;
                case 54:
                    return keyboardNames.SIX;
                case 55:
                    return keyboardNames.SEVEN;
                case 56:
                    return keyboardNames.EIGHT;
                case 57:
                    return keyboardNames.NINE;
                case 65:
                    return keyboardNames.A;
                case 66:
                    return keyboardNames.B;
                case 67:
                    return keyboardNames.C;
                case 68:
                    return keyboardNames.D;
                case 69:
                    return keyboardNames.E;
                case 70:
                    return keyboardNames.F;
                case 71:
                    return keyboardNames.G;
                case 72:
                    return keyboardNames.H;
                case 73:
                    return keyboardNames.I;
                case 74:
                    return keyboardNames.J;
                case 75:
                    return keyboardNames.K;
                case 76:
                    return keyboardNames.L;
                case 77:
                    return keyboardNames.M;
                case 78:
                    return keyboardNames.N;
                case 79:
                    return keyboardNames.O;
                case 80:
                    return keyboardNames.P;
                case 81:
                    return keyboardNames.Q;
                case 82:
                    return keyboardNames.R;
                case 83:
                    return keyboardNames.S;
                case 84:
                    return keyboardNames.T;
                case 85:
                    return keyboardNames.U;
                case 86:
                    return keyboardNames.V;
                case 87:
                    return keyboardNames.W;
                case 88:
                    return keyboardNames.X;
                case 89:
                    return keyboardNames.Y;
                case 90:
                    return keyboardNames.Z;
                case 93:
                    return keyboardNames.APPLICATION_SELECT;
                case 96:
                    return keyboardNames.NUM_ZERO;
                case 97:
                    return keyboardNames.NUM_ONE;
                case 98:
                    return keyboardNames.NUM_TWO;
                case 99:
                    return keyboardNames.NUM_THREE;
                case 100:
                    return keyboardNames.NUM_FOUR;
                case 101:
                    return keyboardNames.NUM_FIVE;
                case 102:
                    return keyboardNames.NUM_SIX;
                case 103:
                    return keyboardNames.NUM_SEVEN;
                case 104:
                    return keyboardNames.NUM_EIGHT;
                case 105:
                    return keyboardNames.NUM_NINE;
                case 106:
                    return keyboardNames.NUM_ASTERISK;
                case 107:
                    return keyboardNames.NUM_PLUS;
                case 109:
                    return keyboardNames.NUM_MINUS;
                case 110:
                    return keyboardNames.NUM_PERIOD;
                case 111:
                    return keyboardNames.NUM_SLASH;
                case 112:
                    return keyboardNames.F1;
                case 113:
                    return keyboardNames.F2;
                case 114:
                    return keyboardNames.F3;
                case 115:
                    return keyboardNames.F4;
                case 116:
                    return keyboardNames.F5;
                case 117:
                    return keyboardNames.F6;
                case 118:
                    return keyboardNames.F7;
                case 119:
                    return keyboardNames.F8;
                case 120:
                    return keyboardNames.F9;
                case 121:
                    return keyboardNames.F10;
                case 122:
                    return keyboardNames.F11;
                case 123:
                    return keyboardNames.F12;
                case 144: //return keyboardNames.NUM_LOCK;
                case 145:
                    return keyboardNames.SCROLL_LOCK;
                case 160:
                    return keyboardNames.LEFT_SHIFT;
                case 161:
                    return keyboardNames.RIGHT_SHIFT;
                case 162:
                    return keyboardNames.LEFT_CONTROL;
                case 163:
                    return keyboardNames.RIGHT_CONTROL;
                case 164:
                    return keyboardNames.LEFT_ALT;
                case 165:
                    return keyboardNames.RIGHT_ALT;
                case 186:
                    return keyboardNames.SEMICOLON;
                case 187:
                    return keyboardNames.EQUALS;
                case 188:
                    return keyboardNames.COMMA;
                case 189:
                    return keyboardNames.MINUS;
                case 190:
                    return keyboardNames.PERIOD;
                case 191:
                    return keyboardNames.FORWARD_SLASH;
                case 192:
                    return keyboardNames.TILDE;
                case 219:
                    return keyboardNames.OPEN_BRACKET;
                case 221:
                    return keyboardNames.CLOSE_BRACKET;
                case 220:
                    return keyboardNames.LEFT_BACKSLASH; /* Looks broken: keyboardNames.BACKSLASH */
                    ;
                case 222:
                    return keyboardNames.APOSTROPHE;
                case 226:
                    return keyboardNames.RIGHT_BACKSLASH; /* Looks broken: keyboardNames.BACKSLASH */
            }

            throw new InvalidEnumArgumentException("Should not be here");
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}