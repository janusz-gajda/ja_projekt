#include <iostream>
#include <random>
#include <fstream>
#include <string>

std::random_device dev;
std::mt19937 rng(dev());
std::uniform_int_distribution<std::mt19937::result_type> number(0, 9);
std::uniform_int_distribution<std::mt19937::result_type> half(0, 1);

enum Mode { onlyInvalid, onlyValid, fifty };

void show_help() {
    std::cout << "Help" << std::endl;
    std::cout << "-i <value> - how many values to generate" << std::endl;
    std::cout << "-v - generate only valid Luhn values" << std::endl;
    std::cout << "-i - generate only invalid Luhn values" << std::endl;
    std::cout << "-50 - generate both valid and invalid Luhn value (50% spread)" << std::endl;
}

int calculate_Luhn_value(std::string str) {
    int sum = 0;
    bool isSecond = false;
    for (int i = 15; i >= 0; i--) {
        int digit = str[i] - '0';
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

std::string valid_Luhn_string() {
    std::string str;
    unsigned int luhn;
    for (int j = 0; j < 15; j++) {
        str.append(std::to_string(number(rng)));
    }
    str.append(std::to_string(0));
    luhn = calculate_Luhn_value(str);
    str = str.substr(0, 15);
    str.append(std::to_string(luhn));
    return str;
}

std::string invalid_Luhn_string() {
    std::string str;
    unsigned int luhn;
    for (int j = 0; j < 15; j++) {
        str.append(std::to_string(number(rng)));
    }
    str.append(std::to_string(0));
    luhn = (calculate_Luhn_value(str) + 1) % 10;
    str = str.substr(0, 15);
    str.append(std::to_string(luhn));
    return str;
}

void only_invalid_func(int count) {
    std::ofstream file("file.csv");
    for (int i = 0; i < count; i++) {
        file << invalid_Luhn_string() << std::endl;
    }
    file.close();
}

void only_valid_func(int count) {
    std::ofstream file("file.csv");
    for (int i = 0; i < count; i++) {
        file << valid_Luhn_string() << std::endl;
    }
    file.close();
}

void fifty_func(int count) {
    std::ofstream file("file.csv");
    for (int i = 0; i < count; i++) {
        if (half(rng)) {
            file << invalid_Luhn_string() << std::endl;
        }
        else {
            file << valid_Luhn_string() << std::endl;
        }
    }
    file.close();
}

int main(int argc, char** argv) {
    int count = 10;
    int mode = fifty;
    //Parsing arguments
    if (argc < 2) {
        show_help();
        return 0;
    }
    for (int i = 1; i < argc; i++) {
        if (strcmp(argv[i], "-i") == 0) {
            count = std::stoi(argv[++i]);
        }
        else if (strcmp(argv[i], "-50") == 0) {
            mode = fifty;
        }
        else if (strcmp(argv[i], "-iv") == 0) {
            mode = onlyInvalid;
        }
        else if (strcmp(argv[i], "-v") == 0) {
            mode = onlyValid;
        }
        else {
            std::cout << "Unknown parameter " << argv[i] << std::endl;
            show_help();
            return 0;
        }
    }

    switch (mode) {
    case fifty:
        fifty_func(count);
        break;
    case onlyInvalid:
        only_invalid_func(count);
        break;
    case onlyValid:
        only_valid_func(count);
        break;
    default:
        fifty_func(count);
        break;
    }
    return 0;
}
