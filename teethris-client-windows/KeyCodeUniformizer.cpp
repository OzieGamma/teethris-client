#include "KeyCodeUniformizer.h"
#include <iostream>

LogiLed::KeyName KeyForVkCode(int vkCode)
{
	switch (vkCode)
	{
	case 8: return LogiLed::KeyName::BACKSPACE;
	case 9: return LogiLed::KeyName::TAB;
	case 13: return LogiLed::KeyName::ENTER;
	case 19: return LogiLed::KeyName::PAUSE_BREAK;
	case 20: return LogiLed::KeyName::CAPS_LOCK;
	case 27: return LogiLed::KeyName::ESC;
	case 32: return LogiLed::KeyName::SPACE;
	case 33: return LogiLed::KeyName::PAGE_UP;
	case 34: return LogiLed::KeyName::PAGE_DOWN;
	case 35: return LogiLed::KeyName::END;
	case 36: return LogiLed::KeyName::HOME;
	case 37: return LogiLed::KeyName::ARROW_LEFT;
	case 38: return LogiLed::KeyName::ARROW_UP;
	case 39: return LogiLed::KeyName::ARROW_RIGHT;
	case 40: return LogiLed::KeyName::ARROW_DOWN;
	case 44: return LogiLed::KeyName::PRINT_SCREEN;
	case 45: return LogiLed::KeyName::INSERT;
	case 46: return LogiLed::KeyName::KEYBOARD_DELETE;
	case 48: return LogiLed::KeyName::ZERO;
	case 49: return LogiLed::KeyName::ONE;
	case 50: return LogiLed::KeyName::TWO;
	case 51: return LogiLed::KeyName::THREE;
	case 52: return LogiLed::KeyName::FOUR;
	case 53: return LogiLed::KeyName::FIVE;
	case 54: return LogiLed::KeyName::SIX;
	case 55: return LogiLed::KeyName::SEVEN;
	case 56: return LogiLed::KeyName::EIGHT;
	case 57: return LogiLed::KeyName::NINE;
	case 65: return LogiLed::KeyName::A;
	case 66: return LogiLed::KeyName::B;
	case 67: return LogiLed::KeyName::C;
	case 68: return LogiLed::KeyName::D;
	case 69: return LogiLed::KeyName::E;
	case 70: return LogiLed::KeyName::F;
	case 71: return LogiLed::KeyName::G;
	case 72: return LogiLed::KeyName::H;
	case 73: return LogiLed::KeyName::I;
	case 74: return LogiLed::KeyName::J;
	case 75: return LogiLed::KeyName::K;
	case 76: return LogiLed::KeyName::L;
	case 77: return LogiLed::KeyName::M;
	case 78: return LogiLed::KeyName::N;
	case 79: return LogiLed::KeyName::O;
	case 80: return LogiLed::KeyName::P;
	case 81: return LogiLed::KeyName::Q;
	case 82: return LogiLed::KeyName::R;
	case 83: return LogiLed::KeyName::S;
	case 84: return LogiLed::KeyName::T;
	case 85: return LogiLed::KeyName::U;
	case 86: return LogiLed::KeyName::V;
	case 87: return LogiLed::KeyName::W;
	case 88: return LogiLed::KeyName::X;
	case 89: return LogiLed::KeyName::Y;
	case 90: return LogiLed::KeyName::Z;
	case 96: return LogiLed::KeyName::NUM_ZERO;
	case 97: return LogiLed::KeyName::NUM_ONE;
	case 98: return LogiLed::KeyName::NUM_TWO;
	case 99: return LogiLed::KeyName::NUM_THREE;
	case 100: return LogiLed::KeyName::NUM_FOUR;
	case 101: return LogiLed::KeyName::NUM_FIVE;
	case 102: return LogiLed::KeyName::NUM_SIX;
	case 103: return LogiLed::KeyName::NUM_SEVEN;
	case 104: return LogiLed::KeyName::NUM_EIGHT;
	case 105: return LogiLed::KeyName::NUM_NINE;
	case 106: return LogiLed::KeyName::NUM_ASTERISK;
	case 107: return LogiLed::KeyName::NUM_PLUS;
	case 109: return LogiLed::KeyName::NUM_MINUS;
	case 110: return LogiLed::KeyName::NUM_PERIOD;
	case 111: return LogiLed::KeyName::NUM_SLASH;
	case 112: return LogiLed::KeyName::F1;
	case 113: return LogiLed::KeyName::F2;
	case 114: return LogiLed::KeyName::F3;
	case 115: return LogiLed::KeyName::F4;
	case 116: return LogiLed::KeyName::F5;
	case 117: return LogiLed::KeyName::F6;
	case 118: return LogiLed::KeyName::F7;
	case 119: return LogiLed::KeyName::F8;
	case 120: return LogiLed::KeyName::F9;
	case 121: return LogiLed::KeyName::F10;
	case 122: return LogiLed::KeyName::F11;
	case 123: return LogiLed::KeyName::F12;
	case 144: //return LogiLed::KeyName::NUM_LOCK;
	case 145: return LogiLed::KeyName::SCROLL_LOCK;
	case 160: return LogiLed::KeyName::LEFT_SHIFT;
	case 161: return LogiLed::KeyName::RIGHT_SHIFT;
	case 162: return LogiLed::KeyName::LEFT_CONTROL;
	case 163: return LogiLed::KeyName::RIGHT_CONTROL;
	case 164: return LogiLed::KeyName::LEFT_ALT;
	case 165: return LogiLed::KeyName::RIGHT_ALT;
	case 186: return LogiLed::KeyName::SEMICOLON;
	case 187: return LogiLed::KeyName::EQUALS;
	case 188: return LogiLed::KeyName::COMMA;
	case 189: return LogiLed::KeyName::MINUS;
	case 190: return LogiLed::KeyName::PERIOD;
	case 191: return LogiLed::KeyName::FORWARD_SLASH;
	case 192: return LogiLed::KeyName::TILDE;
	case 219: return LogiLed::KeyName::OPEN_BRACKET;
	case 221: return LogiLed::KeyName::CLOSE_BRACKET;
	case 220: return static_cast<LogiLed::KeyName>(93) /* Looks broken: LogiLed::KeyName::BACKSLASH */;
	case 222: return LogiLed::KeyName::APOSTROPHE;
	case 226: return static_cast<LogiLed::KeyName>(86) /* Looks broken: LogiLed::KeyName::BACKSLASH */;
	default: break;
	}

	std::cerr << "No known key for vkCode: " << vkCode << std::endl;
	exit(-1);
}

