#include <iostream>
#include "includes/objectVault.hpp"
#include "includes/moduleManager.hpp"
using namespace std;

main()
{
    OBJECT_VAULT::GLOBAL::PERSISTENT = true;
    while (OBJECT_VAULT::GLOBAL::PERSISTENT) moduleInit();
    return 0;
}