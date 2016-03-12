// <copyright company="Oswald MASKENS, Boris GORDTS, Tom EELBODE, Zoë PETARD" file="Engine.cs">
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

namespace teethris.NET.SDK
{
    public class Engine
    {
        private const int WhKeyboardLl = 13;
        private const int WmKeydown = 0x0100;
        private static IntPtr hookId = IntPtr.Zero;

        public static void Run<T>() where T : class, IGame, new()
        {
            var gameManager = new GameRunner<T>();

            hookId = SetHook(HookCallback(gameManager.KeyPressed));

            //var timer = new Timer {Interval = 10};
            //timer.Tick += (sender, args) => gameManager.Tick();
            //timer.Start();

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

        private static LowLevelKeyboardProc HookCallback(Func<KeyboardNames, bool> keyPressed)
        {
            return (nCode, wParam, lParam) =>
            {
                var callNext = true;

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

        private static KeyboardNames VkToKeyboardName(int vkCode)
        {
            switch (vkCode)
            {
                case 8:
                    return KeyboardNames.BACKSPACE;
                case 9:
                    return KeyboardNames.TAB;
                case 13:
                    return KeyboardNames.ENTER;
                case 19:
                    return KeyboardNames.PAUSE_BREAK;
                case 20:
                    return KeyboardNames.CAPS_LOCK;
                case 27:
                    return KeyboardNames.ESC;
                case 32:
                    return KeyboardNames.SPACE;
                case 33:
                    return KeyboardNames.PAGE_UP;
                case 34:
                    return KeyboardNames.PAGE_DOWN;
                case 35:
                    return KeyboardNames.END;
                case 36:
                    return KeyboardNames.HOME;
                case 37:
                    return KeyboardNames.ARROW_LEFT;
                case 38:
                    return KeyboardNames.ARROW_UP;
                case 39:
                    return KeyboardNames.ARROW_RIGHT;
                case 40:
                    return KeyboardNames.ARROW_DOWN;
                case 44:
                    return KeyboardNames.PRINT_SCREEN;
                case 45:
                    return KeyboardNames.INSERT;
                case 46:
                    return KeyboardNames.KEYBOARD_DELETE;
                case 48:
                    return KeyboardNames.ZERO;
                case 49:
                    return KeyboardNames.ONE;
                case 50:
                    return KeyboardNames.TWO;
                case 51:
                    return KeyboardNames.THREE;
                case 52:
                    return KeyboardNames.FOUR;
                case 53:
                    return KeyboardNames.FIVE;
                case 54:
                    return KeyboardNames.SIX;
                case 55:
                    return KeyboardNames.SEVEN;
                case 56:
                    return KeyboardNames.EIGHT;
                case 57:
                    return KeyboardNames.NINE;
                case 65:
                    return KeyboardNames.A;
                case 66:
                    return KeyboardNames.B;
                case 67:
                    return KeyboardNames.C;
                case 68:
                    return KeyboardNames.D;
                case 69:
                    return KeyboardNames.E;
                case 70:
                    return KeyboardNames.F;
                case 71:
                    return KeyboardNames.G;
                case 72:
                    return KeyboardNames.H;
                case 73:
                    return KeyboardNames.I;
                case 74:
                    return KeyboardNames.J;
                case 75:
                    return KeyboardNames.K;
                case 76:
                    return KeyboardNames.L;
                case 77:
                    return KeyboardNames.M;
                case 78:
                    return KeyboardNames.N;
                case 79:
                    return KeyboardNames.O;
                case 80:
                    return KeyboardNames.P;
                case 81:
                    return KeyboardNames.Q;
                case 82:
                    return KeyboardNames.R;
                case 83:
                    return KeyboardNames.S;
                case 84:
                    return KeyboardNames.T;
                case 85:
                    return KeyboardNames.U;
                case 86:
                    return KeyboardNames.V;
                case 87:
                    return KeyboardNames.W;
                case 88:
                    return KeyboardNames.X;
                case 89:
                    return KeyboardNames.Y;
                case 90:
                    return KeyboardNames.Z;
                case 93:
                    return KeyboardNames.APPLICATION_SELECT;
                case 96:
                    return KeyboardNames.NUM_ZERO;
                case 97:
                    return KeyboardNames.NUM_ONE;
                case 98:
                    return KeyboardNames.NUM_TWO;
                case 99:
                    return KeyboardNames.NUM_THREE;
                case 100:
                    return KeyboardNames.NUM_FOUR;
                case 101:
                    return KeyboardNames.NUM_FIVE;
                case 102:
                    return KeyboardNames.NUM_SIX;
                case 103:
                    return KeyboardNames.NUM_SEVEN;
                case 104:
                    return KeyboardNames.NUM_EIGHT;
                case 105:
                    return KeyboardNames.NUM_NINE;
                case 106:
                    return KeyboardNames.NUM_ASTERISK;
                case 107:
                    return KeyboardNames.NUM_PLUS;
                case 109:
                    return KeyboardNames.NUM_MINUS;
                case 110:
                    return KeyboardNames.NUM_PERIOD;
                case 111:
                    return KeyboardNames.NUM_SLASH;
                case 112:
                    return KeyboardNames.F1;
                case 113:
                    return KeyboardNames.F2;
                case 114:
                    return KeyboardNames.F3;
                case 115:
                    return KeyboardNames.F4;
                case 116:
                    return KeyboardNames.F5;
                case 117:
                    return KeyboardNames.F6;
                case 118:
                    return KeyboardNames.F7;
                case 119:
                    return KeyboardNames.F8;
                case 120:
                    return KeyboardNames.F9;
                case 121:
                    return KeyboardNames.F10;
                case 122:
                    return KeyboardNames.F11;
                case 123:
                    return KeyboardNames.F12;
                case 144: //return KeyboardNames.NUM_LOCK;
                case 145:
                    return KeyboardNames.SCROLL_LOCK;
                case 160:
                    return KeyboardNames.LEFT_SHIFT;
                case 161:
                    return KeyboardNames.RIGHT_SHIFT;
                case 162:
                    return KeyboardNames.LEFT_CONTROL;
                case 163:
                    return KeyboardNames.RIGHT_CONTROL;
                case 164:
                    return KeyboardNames.LEFT_ALT;
                case 165:
                    return KeyboardNames.RIGHT_ALT;
                case 186:
                    return KeyboardNames.SEMICOLON;
                case 187:
                    return KeyboardNames.EQUALS;
                case 188:
                    return KeyboardNames.COMMA;
                case 189:
                    return KeyboardNames.MINUS;
                case 190:
                    return KeyboardNames.PERIOD;
                case 191:
                    return KeyboardNames.FORWARD_SLASH;
                case 192:
                    return KeyboardNames.TILDE;
                case 219:
                    return KeyboardNames.OPEN_BRACKET;
                case 221:
                    return KeyboardNames.CLOSE_BRACKET;
                case 220:
                    return KeyboardNames.RIGHT_BACKSLASH;//LEFT_BACKSLASH; /* Looks broken: KeyboardNames.BACKSLASH */
                case 222:
                    return KeyboardNames.APOSTROPHE;
                case 226:
                    return KeyboardNames.LEFT_BACKSLASH; //RIGHT_BACKSLASH; /* Looks broken: KeyboardNames.BACKSLASH */
            }

            throw new InvalidEnumArgumentException("Should not be here vkCode: " + vkCode);
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