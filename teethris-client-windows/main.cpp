#include <Python.h>
#include <LogitechLEDLib.h>
#include <Windows.h>
#include "KeyCodeUniformizer.h"
#include "PythonBinding.h"


LRESULT CALLBACK LowLevelKeyboardProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if (nCode == HC_ACTION)
	{
		PKBDLLHOOKSTRUCT p = reinterpret_cast<PKBDLLHOOKSTRUCT>(lParam);
		LogiLed::KeyName key = KeyForVkCode(p->vkCode);

		switch (wParam)
		{
		case WM_KEYDOWN:
		case WM_SYSKEYDOWN:
			printf("Hello vk:%d scan: %d\n", p->vkCode, p->scanCode);
			PythonBinding_KeyPress(key);
			break;
		}
	}
	return 1;
}

int main(int argc, char* argv[])
{
	LogiLedInit();
	LogiLedSaveCurrentLighting();

	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_LOCK, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_ENTER, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::LEFT_WINDOWS, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::RIGHT_WINDOWS, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::APPLICATION_SELECT, 100, 0, 0);

	

	PythonBinding_Init();

	// Install the low-level keyboard & mouse hooks
	auto hhkLowLevelKybd = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, nullptr, 0);

	// Keep this app running until we're told to stop
	MSG msg;
	while (true)
	{ 
		if (PeekMessage(&msg, 0, 0, 0, PM_REMOVE)) {
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}

		PythonBinding_Loop();
		Sleep(1);
	}

	UnhookWindowsHookEx(hhkLowLevelKybd);

	PythonBinding_Close();

	LogiLedRestoreLighting();
	LogiLedShutdown();

	return 0;
}

