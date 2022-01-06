// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the JALIB_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// JALIB_API functions as being imported from a DLL, whereas this DLL sees symbols
#ifdef JALIB_EXPORTS
#define JALIB_APIC __declspec(dllexport)
#else
#define JALIB_APIC __declspec(dllimport)
#endif
#include <string>

// This class is exported from the dll

extern "C" JALIB_APIC int calculateLuhnValueC(char*);
