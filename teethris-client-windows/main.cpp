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

VOID CALLBACK TimerRoutine(PVOID lpParam, BOOLEAN TimerOrWaitFired)
{
	PythonBinding_Loop();
}



int main(int argc, char* argv[])
{
	LogiLedInit();
	LogiLedSaveCurrentLighting();

	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_LOCK, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_ENTER, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::LEFT_WINDOWS, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::RIGHT_WINDOWS, 100, 0, 0);

	

	PythonBinding_Init();

	// Install the low-level keyboard & mouse hooks
	auto hhkLowLevelKybd = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, nullptr, 0);

	HANDLE hTimer = nullptr;
	HANDLE hTimerQueue = CreateTimerQueue();
	if (NULL == hTimerQueue)
	{
		printf("CreateTimerQueue failed (%d)\n", GetLastError());
		return 2;
	}

	// Set a timer to call the timer routine in 10 seconds.
	if (!CreateTimerQueueTimer(&hTimer, hTimerQueue,
		static_cast<WAITORTIMERCALLBACK>(TimerRoutine), NULL, 10, 10, 0))
	{
		printf("CreateTimerQueueTimer failed (%d)\n", GetLastError());
		return 3;
	}



	// Keep this app running until we're told to stop
	MSG msg;
	while (GetMessage(&msg, nullptr, 0, 0) > 0)
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}


	if (!DeleteTimerQueue(hTimerQueue))
		printf("DeleteTimerQueue failed (%d)\n", GetLastError());

	UnhookWindowsHookEx(hhkLowLevelKybd);

	PythonBinding_Close();

	LogiLedRestoreLighting();
	LogiLedShutdown();

	return 0;
}

