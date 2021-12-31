// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the JADLLASM_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// JADLLASM_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef JADLLASM_EXPORTS
#define JADLLASM_API __declspec(dllexport)
#else
#define JADLLASM_API __declspec(dllimport)
#endif

// This class is exported from the dll
class JADLLASM_API CJaDllASM {
public:
	CJaDllASM(void);
	// TODO: add your methods here.
};

extern JADLLASM_API int nJaDllASM;

JADLLASM_API int fnJaDllASM(void);
