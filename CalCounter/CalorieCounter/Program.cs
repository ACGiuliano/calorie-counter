/* 
* Console Application that allows user input of weight and daily caloric intake
* then compares to recommended daily amount based on user weight before
* informing user if they have eaten too many calories or not
*
* Created by Anthony Giuliano, Nov. 2023
*/

decimal userWeight;
string? weightString;

decimal maxCalories;

bool weightValid = false;

double breakfastCalories;
double lunchCalories;
double dinnerCalories;
double totalCalories = 0;

Console.WriteLine("Please insert your weight in pounds: ");

do
{  
    weightString = Console.ReadLine();

    while (weightString == null || weightString.Length == 0)
    {
        Console.WriteLine("INVALID. Please enter a value for current weight.");
        weightString = Console.ReadLine();
    }

    if (Decimal.TryParse(weightString, out userWeight))
    {
        Console.WriteLine($"Input Accepted. Weight set at {userWeight}lbs");
        Console.WriteLine(); // formatting line break
        weightValid = true;
    }
    else
    {
        Console.WriteLine($"INVALID. {weightString} is not a number, please enter current weight: ");
    }

} while (!weightValid);

maxCalories = userWeight * 12;

Console.WriteLine(@$"Based on your current weight of {userWeight}lbs, your maximum caloric intake is {maxCalories} calories.
This will maintain your current weight.");

Console.WriteLine(); // add line break for ease of reading

Console.WriteLine("Please enter the number of calories eaten for breakfast.");

bool breakfastValid = false;

// loop for breakfast input
do
{
    string? breakfastInput = Console.ReadLine();

    while (breakfastInput == null || breakfastInput.Length == 0)
    {
        Console.WriteLine("INVALID. Please enter a value for total breakfast calories.");
        breakfastInput = Console.ReadLine();
    }

    if (Double.TryParse(breakfastInput, out breakfastCalories))
    {
        // validating if calorie value is positive number
        if (breakfastCalories < 0)
        {
            Console.WriteLine("INVALID. Calories must be a positive number. Please enter breakfast calories eaten.");
            break;
        }
        else if (breakfastCalories >= 0)
        {
            Console.WriteLine($"Breakfast calories {breakfastCalories}.");
            Console.WriteLine();
            totalCalories += breakfastCalories;
            breakfastValid = true;
        }
    }
    else 
    {
        Console.WriteLine($"{breakfastInput} is not a valid response. Please enter a valid number.");
    }

} while (breakfastValid == false);
