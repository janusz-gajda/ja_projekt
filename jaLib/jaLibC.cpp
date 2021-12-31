// jaLib.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "jaLibC.h"
#include <string>


// This is an example of an exported variable
JALIB_APIC int njaLib=0;

// This is an example of an exported function.
extern "C" JALIB_APIC int fnjaLib(void)
{
    return 0;
}

extern "C" JALIB_APIC int calculateLuhnValue(char* ptr) {
    int sum = 0;
    bool isSecond = false;
    for (int i = 15; i >= 0; i--) {
        int digit = ptr[i] - '0';
        if (isSecond) {
            digit *= 2;
        }
        isSecond = !isSecond;
        /*
        sum += digit / 10;
        sum += digit % 10;
        */
        //Alternative
        if (digit > 9) {
            digit -= 9;
        }
        sum += digit;
    }
    sum %= 10;
    if (sum == 0)
        return 0;
    return 10 - sum;
    
}


// This is the constructor of a class that has been exported.
CjaLib::CjaLib()
{
    return;
}
