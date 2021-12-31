// JaDllASM.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "JaDllASM.h"


// This is an example of an exported variable
JADLLASM_API int nJaDllASM=0;

// This is an example of an exported function.
JADLLASM_API int fnJaDllASM(void)
{
    return 0;
}

// This is the constructor of a class that has been exported.
CJaDllASM::CJaDllASM()
{
    return;
}
