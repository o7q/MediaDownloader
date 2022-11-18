#include <iostream>

using namespace std;

#define dummyLoop loop

// functions
void dummyLoop(); // dummy loop

// configure global variables
const string ver = "v1.1.0"; // version

main()
{
    cout << " rcbot_transit_dummy\n DiscordRC " + ver + " by o7q\n\n";
    loop();
    return 1;
}

void dummyLoop()
{
    cin.get();
    loop();
}