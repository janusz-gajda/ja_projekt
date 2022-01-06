// jaLib.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "jaLibC.h"
#include <string>

extern "C" JALIB_APIC int calculateLuhnValueC(char* ptr) {
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

