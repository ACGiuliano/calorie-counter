/* 
* Console Application that allows user input of weight and daily caloric intake
* then compares to recommended daily amount based on user weight before
* informing user if they have eaten too many calories or not
*
* Created by Anthony Giuliano, Nov. 2023
*/

decimal userWeight;
string? weightString;

bool weightValid = false;

double breakfastCalories;
double lunchCalories;
double dinnerCalories;

Console.WriteLine("Please insert your weight: ");

do
{  
    weightString = Console.ReadLine();

    while (weightString == null || weightString.Length == 0)
    {
        Console.WriteLine("INVALID. Please enter a value for current weight.");
        weightString = Console.ReadLine();
    }


} while (!weightValid);