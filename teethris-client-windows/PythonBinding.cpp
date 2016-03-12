#include <Python.h>
#include <LogitechLEDLib.h>
#include <ostream>
#include <iostream>

static PyObject* TeethrisError;
PyObject* pModule;

/* Return the number of arguments of the application command line */
static PyObject* teethris_setLighting(PyObject* self, PyObject* args)
{
	int key;
	int red, green, blue;

	if (!PyArg_ParseTuple(args, "iiii", &key, &red, &green, &blue))
	{
		return nullptr;
	}

	if (red < 0 || red > 100 || green < 0 || green > 100 || blue < 0 || blue > 100)
	{
		PyErr_SetString(TeethrisError, "Led colors should be a percentage between 0 and 100");
		return nullptr;
	}

	std::cerr << "TRACE" << std::endl;

	LogiLedSetLightingForKeyWithKeyName(static_cast<LogiLed::KeyName>(key), red, green, blue);
	
	std::cerr << "TRACE end" << std::endl;

	return PyLong_FromLong(0);
}

static PyMethodDef TeethrisMethods[] = {
	{"setLighting", teethris_setLighting, METH_VARARGS,
		"Sets the color of a keyboard key."},
	{nullptr, nullptr, 0, nullptr}
};

static PyModuleDef TeethrisModule = {
	PyModuleDef_HEAD_INIT, "teethris", nullptr, -1, TeethrisMethods,
	nullptr, nullptr, nullptr, nullptr
};

void registerConstantKeyNames(PyObject* module)
{
	PyModule_AddObject(module, "ESC", Py_BuildValue("i", LogiLed::KeyName::ESC));
	PyModule_AddObject(module, "F1", Py_BuildValue("i", LogiLed::KeyName::F1));
	PyModule_AddObject(module, "F2", Py_BuildValue("i", LogiLed::KeyName::F2));
	PyModule_AddObject(module, "F3", Py_BuildValue("i", LogiLed::KeyName::F3));
	PyModule_AddObject(module, "F4", Py_BuildValue("i", LogiLed::KeyName::F4));
	PyModule_AddObject(module, "F5", Py_BuildValue("i", LogiLed::KeyName::F5));
	PyModule_AddObject(module, "F6", Py_BuildValue("i", LogiLed::KeyName::F6));
	PyModule_AddObject(module, "F7", Py_BuildValue("i", LogiLed::KeyName::F7));
	PyModule_AddObject(module, "F8", Py_BuildValue("i", LogiLed::KeyName::F8));
	PyModule_AddObject(module, "F9", Py_BuildValue("i", LogiLed::KeyName::F9));
	PyModule_AddObject(module, "F10", Py_BuildValue("i", LogiLed::KeyName::F10));
	PyModule_AddObject(module, "F11", Py_BuildValue("i", LogiLed::KeyName::F11));
	PyModule_AddObject(module, "F12", Py_BuildValue("i", LogiLed::KeyName::F12));
	PyModule_AddObject(module, "PRINT_SCREEN", Py_BuildValue("i", LogiLed::KeyName::PRINT_SCREEN));
	PyModule_AddObject(module, "SCROLL_LOCK", Py_BuildValue("i", LogiLed::KeyName::SCROLL_LOCK));
	PyModule_AddObject(module, "PAUSE_BREAK", Py_BuildValue("i", LogiLed::KeyName::PAUSE_BREAK));
	PyModule_AddObject(module, "TILDE", Py_BuildValue("i", LogiLed::KeyName::TILDE));
	PyModule_AddObject(module, "ONE", Py_BuildValue("i", LogiLed::KeyName::ONE));
	PyModule_AddObject(module, "TWO", Py_BuildValue("i", LogiLed::KeyName::TWO));
	PyModule_AddObject(module, "THREE", Py_BuildValue("i", LogiLed::KeyName::THREE));
	PyModule_AddObject(module, "FOUR", Py_BuildValue("i", LogiLed::KeyName::FOUR));
	PyModule_AddObject(module, "FIVE", Py_BuildValue("i", LogiLed::KeyName::FIVE));
	PyModule_AddObject(module, "SIX", Py_BuildValue("i", LogiLed::KeyName::SIX));
	PyModule_AddObject(module, "SEVEN", Py_BuildValue("i", LogiLed::KeyName::SEVEN));
	PyModule_AddObject(module, "EIGHT", Py_BuildValue("i", LogiLed::KeyName::EIGHT));
	PyModule_AddObject(module, "NINE", Py_BuildValue("i", LogiLed::KeyName::NINE));
	PyModule_AddObject(module, "ZERO", Py_BuildValue("i", LogiLed::KeyName::ZERO));
	PyModule_AddObject(module, "MINUS", Py_BuildValue("i", LogiLed::KeyName::MINUS));
	PyModule_AddObject(module, "EQUALS", Py_BuildValue("i", LogiLed::KeyName::EQUALS));
	PyModule_AddObject(module, "BACKSPACE", Py_BuildValue("i", LogiLed::KeyName::BACKSPACE));
	PyModule_AddObject(module, "INSERT", Py_BuildValue("i", LogiLed::KeyName::INSERT));
	PyModule_AddObject(module, "HOME", Py_BuildValue("i", LogiLed::KeyName::HOME));
	PyModule_AddObject(module, "PAGE_UP", Py_BuildValue("i", LogiLed::KeyName::PAGE_UP));
	PyModule_AddObject(module, "NUM_LOCK", Py_BuildValue("i", LogiLed::KeyName::NUM_LOCK));
	PyModule_AddObject(module, "NUM_SLASH", Py_BuildValue("i", LogiLed::KeyName::NUM_SLASH));
	PyModule_AddObject(module, "NUM_ASTERISK", Py_BuildValue("i", LogiLed::KeyName::NUM_ASTERISK));
	PyModule_AddObject(module, "NUM_MINUS", Py_BuildValue("i", LogiLed::KeyName::NUM_MINUS));
	PyModule_AddObject(module, "TAB", Py_BuildValue("i", LogiLed::KeyName::TAB));
	PyModule_AddObject(module, "Q", Py_BuildValue("i", LogiLed::KeyName::Q));
	PyModule_AddObject(module, "W", Py_BuildValue("i", LogiLed::KeyName::W));
	PyModule_AddObject(module, "E", Py_BuildValue("i", LogiLed::KeyName::E));
	PyModule_AddObject(module, "R", Py_BuildValue("i", LogiLed::KeyName::R));
	PyModule_AddObject(module, "T", Py_BuildValue("i", LogiLed::KeyName::T));
	PyModule_AddObject(module, "Y", Py_BuildValue("i", LogiLed::KeyName::Y));
	PyModule_AddObject(module, "U", Py_BuildValue("i", LogiLed::KeyName::U));
	PyModule_AddObject(module, "I", Py_BuildValue("i", LogiLed::KeyName::I));
	PyModule_AddObject(module, "O", Py_BuildValue("i", LogiLed::KeyName::O));
	PyModule_AddObject(module, "P", Py_BuildValue("i", LogiLed::KeyName::P));
	PyModule_AddObject(module, "OPEN_BRACKET", Py_BuildValue("i", LogiLed::KeyName::OPEN_BRACKET));
	PyModule_AddObject(module, "CLOSE_BRACKET", Py_BuildValue("i", LogiLed::KeyName::CLOSE_BRACKET));
	PyModule_AddObject(module, "LEFT_BACKSLASH", Py_BuildValue("i", 86));
	PyModule_AddObject(module, "RIGHT_BACKSLASH", Py_BuildValue("i", 93));
	PyModule_AddObject(module, "KEYBOARD_DELETE", Py_BuildValue("i", LogiLed::KeyName::KEYBOARD_DELETE));
	PyModule_AddObject(module, "END", Py_BuildValue("i", LogiLed::KeyName::END));
	PyModule_AddObject(module, "PAGE_DOWN", Py_BuildValue("i", LogiLed::KeyName::PAGE_DOWN));
	PyModule_AddObject(module, "NUM_SEVEN", Py_BuildValue("i", LogiLed::KeyName::NUM_SEVEN));
	PyModule_AddObject(module, "NUM_EIGHT", Py_BuildValue("i", LogiLed::KeyName::NUM_EIGHT));
	PyModule_AddObject(module, "NUM_NINE", Py_BuildValue("i", LogiLed::KeyName::NUM_NINE));
	PyModule_AddObject(module, "NUM_PLUS", Py_BuildValue("i", LogiLed::KeyName::NUM_PLUS));
	PyModule_AddObject(module, "CAPS_LOCK", Py_BuildValue("i", LogiLed::KeyName::CAPS_LOCK));
	PyModule_AddObject(module, "A", Py_BuildValue("i", LogiLed::KeyName::A));
	PyModule_AddObject(module, "S", Py_BuildValue("i", LogiLed::KeyName::S));
	PyModule_AddObject(module, "D", Py_BuildValue("i", LogiLed::KeyName::D));
	PyModule_AddObject(module, "F", Py_BuildValue("i", LogiLed::KeyName::F));
	PyModule_AddObject(module, "G", Py_BuildValue("i", LogiLed::KeyName::G));
	PyModule_AddObject(module, "H", Py_BuildValue("i", LogiLed::KeyName::H));
	PyModule_AddObject(module, "J", Py_BuildValue("i", LogiLed::KeyName::J));
	PyModule_AddObject(module, "K", Py_BuildValue("i", LogiLed::KeyName::K));
	PyModule_AddObject(module, "L", Py_BuildValue("i", LogiLed::KeyName::L));
	PyModule_AddObject(module, "SEMICOLON", Py_BuildValue("i", LogiLed::KeyName::SEMICOLON));
	PyModule_AddObject(module, "APOSTROPHE", Py_BuildValue("i", LogiLed::KeyName::APOSTROPHE));
	PyModule_AddObject(module, "ENTER", Py_BuildValue("i", LogiLed::KeyName::ENTER));
	PyModule_AddObject(module, "NUM_FOUR", Py_BuildValue("i", LogiLed::KeyName::NUM_FOUR));
	PyModule_AddObject(module, "NUM_FIVE", Py_BuildValue("i", LogiLed::KeyName::NUM_FIVE));
	PyModule_AddObject(module, "NUM_SIX", Py_BuildValue("i", LogiLed::KeyName::NUM_SIX));
	PyModule_AddObject(module, "LEFT_SHIFT", Py_BuildValue("i", LogiLed::KeyName::LEFT_SHIFT));
	PyModule_AddObject(module, "Z", Py_BuildValue("i", LogiLed::KeyName::Z));
	PyModule_AddObject(module, "X", Py_BuildValue("i", LogiLed::KeyName::X));
	PyModule_AddObject(module, "C", Py_BuildValue("i", LogiLed::KeyName::C));
	PyModule_AddObject(module, "V", Py_BuildValue("i", LogiLed::KeyName::V));
	PyModule_AddObject(module, "B", Py_BuildValue("i", LogiLed::KeyName::B));
	PyModule_AddObject(module, "N", Py_BuildValue("i", LogiLed::KeyName::N));
	PyModule_AddObject(module, "M", Py_BuildValue("i", LogiLed::KeyName::M));
	PyModule_AddObject(module, "COMMA", Py_BuildValue("i", LogiLed::KeyName::COMMA));
	PyModule_AddObject(module, "PERIOD", Py_BuildValue("i", LogiLed::KeyName::PERIOD));
	PyModule_AddObject(module, "FORWARD_SLASH", Py_BuildValue("i", LogiLed::KeyName::FORWARD_SLASH));
	PyModule_AddObject(module, "RIGHT_SHIFT", Py_BuildValue("i", LogiLed::KeyName::RIGHT_SHIFT));
	PyModule_AddObject(module, "ARROW_UP", Py_BuildValue("i", LogiLed::KeyName::ARROW_UP));
	PyModule_AddObject(module, "NUM_ONE", Py_BuildValue("i", LogiLed::KeyName::NUM_ONE));
	PyModule_AddObject(module, "NUM_TWO", Py_BuildValue("i", LogiLed::KeyName::NUM_TWO));
	PyModule_AddObject(module, "NUM_THREE", Py_BuildValue("i", LogiLed::KeyName::NUM_THREE));
	PyModule_AddObject(module, "NUM_ENTER", Py_BuildValue("i", LogiLed::KeyName::NUM_ENTER));
	PyModule_AddObject(module, "LEFT_CONTROL", Py_BuildValue("i", LogiLed::KeyName::LEFT_CONTROL));
	PyModule_AddObject(module, "LEFT_WINDOWS", Py_BuildValue("i", LogiLed::KeyName::LEFT_WINDOWS));
	PyModule_AddObject(module, "LEFT_ALT", Py_BuildValue("i", LogiLed::KeyName::LEFT_ALT));
	PyModule_AddObject(module, "SPACE", Py_BuildValue("i", LogiLed::KeyName::SPACE));
	PyModule_AddObject(module, "RIGHT_ALT", Py_BuildValue("i", LogiLed::KeyName::RIGHT_ALT));
	PyModule_AddObject(module, "RIGHT_WINDOWS", Py_BuildValue("i", LogiLed::KeyName::RIGHT_WINDOWS));
	PyModule_AddObject(module, "APPLICATION_SELECT", Py_BuildValue("i", LogiLed::KeyName::APPLICATION_SELECT));
	PyModule_AddObject(module, "RIGHT_CONTROL", Py_BuildValue("i", LogiLed::KeyName::RIGHT_CONTROL));
	PyModule_AddObject(module, "ARROW_LEFT", Py_BuildValue("i", LogiLed::KeyName::ARROW_LEFT));
	PyModule_AddObject(module, "ARROW_DOWN", Py_BuildValue("i", LogiLed::KeyName::ARROW_DOWN));
	PyModule_AddObject(module, "ARROW_RIGHT", Py_BuildValue("i", LogiLed::KeyName::ARROW_RIGHT));
	PyModule_AddObject(module, "NUM_ZERO", Py_BuildValue("i", LogiLed::KeyName::NUM_ZERO));
	PyModule_AddObject(module, "NUM_PERIOD", Py_BuildValue("i", LogiLed::KeyName::NUM_PERIOD));
};

static PyObject* PyInit_teethris(void)
{
	PyObject* module = PyModule_Create(&TeethrisModule);
	if (module == nullptr)
	{
		return nullptr;
	}

	// Register our own exception
	TeethrisError = PyErr_NewException("teethris.error", nullptr, nullptr);
	Py_INCREF(TeethrisError);
	PyModule_AddObject(module, "error", TeethrisError);

	// Register the key constants
	registerConstantKeyNames(module);

	return module;
}

static void Invoque(char* func_name)
{
	PyObject *pFunc, *pArgs;

	pFunc = PyObject_GetAttrString(pModule, func_name);
	/* pFunc is a new reference */

	if (pFunc && PyCallable_Check(pFunc))
	{
		PyObject_CallObject(pFunc, nullptr);
	}
	else
	{
		if (PyErr_Occurred())
		{
			PyErr_Print();
		}
		fprintf(stderr, "Cannot find function \n");
	}
	Py_XDECREF(pFunc);
}

static void InvoqueOneIntArg(char* func_name, int arg)
{
	PyObject *pFunc, *pArgs, *pValue;

	pFunc = PyObject_GetAttrString(pModule, func_name);
	/* pFunc is a new reference */

	if (pFunc && PyCallable_Check(pFunc))
	{
		pArgs = PyTuple_New(1);
		pValue = PyLong_FromLong(arg);
		if (!pValue)
		{
			Py_DECREF(pArgs);
			Py_DECREF(pModule);
			fprintf(stderr, "Cannot convert argument\n");
			exit(-1);
		}
		/* pValue reference stolen here: */
		PyTuple_SetItem(pArgs, 0, pValue);

		PyObject_CallObject(pFunc, pArgs);
		Py_DECREF(pArgs);
	}
	else
	{
		if (PyErr_Occurred())
		{
			PyErr_Print();
		}
		fprintf(stderr, "Cannot find function \n");
	}
	Py_XDECREF(pFunc);
}

void PythonBinding_Init()
{
	PyObject* pName;

	PyImport_AppendInittab("teethris", &PyInit_teethris);
	Py_Initialize();
	pName = PyUnicode_DecodeFSDefault("game");
	/* Error checking of pName left out */

	if (pName == nullptr)
	{
		exit(-1);
	}

	pModule = PyImport_Import(pName);
	Py_DECREF(pName);

	if (pModule != nullptr)
	{
		Invoque("init");
	}
	else
	{
		PyErr_Print();
		fprintf(stderr, "Failed to load \n");
		exit(-1);
	}
}

void PythonBinding_Close()
{
	Py_DECREF(pModule);
	Py_Finalize();
}

void PythonBinding_Loop()
{
	Invoque("loop");
}

void PythonBinding_KeyPress(LogiLed::KeyName key)
{
	for (int i = 0; i < 2000; i += 1) {
		LogiLedSetLightingForKeyWithScanCode(i, 0, 0, 0);
	}

	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_LOCK, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::NUM_ENTER, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::LEFT_WINDOWS, 100, 0, 0);
	LogiLedSetLightingForKeyWithKeyName(LogiLed::KeyName::RIGHT_WINDOWS, 100, 0, 0);

	std::cerr << "DEBUG" << std::endl;

	InvoqueOneIntArg("on_key_press", key);
}

