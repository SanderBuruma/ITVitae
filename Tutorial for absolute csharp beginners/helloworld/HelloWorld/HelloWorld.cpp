// HelloWorld.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int main()
{
	cout << "Please enter an integer representing how many worlds you think there are.";
	int a, b, c;
	cin >> a;
	if (a < 1)
	{
		cout << "You don't think there are any worlds.";
	}
	else if (a < 2)
	{
		cout << "You're probably of the geocentrist conviction.";
	}
	else
	{
		cout << "Ther are indeed more worlds than the one we live on or orbit. All the worlds say hi!";
	}
	cout << endl << "Thank you for participating in this survey.";
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
