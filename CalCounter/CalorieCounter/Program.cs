/* 
* Console Application that allows user input of weight and daily caloric intake
* then compares to recommended daily amount based on user weight before
* informing user if they have eaten too many calories or not
*
* Created by Anthony Giuliano, Nov. 2023
*/

decimal userWeight;
string? weightString;
string? userMeal;
string currentMeal;

decimal maxCalories;
int mealInput;

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

Console.WriteLine(@"Please enter a digit 1-4 to select which of the below meals you wish to add calories to:
                    1. Breakfast
                    2. Lunch
                    3. Dinner
                    4. Snacks");

userMeal = Console.ReadLine();

bool isValid = int.TryParse(userMeal, out mealInput);

while (isValid = false || mealInput > 4 || mealInput < 1)
{
    Console.WriteLine("INVALID INPUT. Please select one of the above options using numbers 1-4");
    isValid = int.TryParse(Console.ReadLine(), out mealInput);
}

switch (mealInput)
{
    case 1:
        currentMeal = "Breakfast";
        break;
    case 2:
        currentMeal = "Lunch";
        break;
    case 3:
        currentMeal = "Dinner";
        break;
    case 4:
        currentMeal = "Snack";
        break;
}

breakfastCalories = CalAdd("Breakfast");




/*
* outdated loop now that method implemented 
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

Console.WriteLine($"So far you have consumed {totalCalories} calories.");
*/

static double CalAdd(string meal)
{
    bool validInput = false;
    double caloriesAdded = 0;
    string? calorieString;

    do
    {
        calorieString = Console.ReadLine();

        while (calorieString == null || calorieString.Length == 0)
        {
            Console.WriteLine("INVALID. Please enter a value for calories consumed.");
            calorieString = Console.ReadLine();
        }

        if (Double.TryParse(calorieString, out caloriesAdded))
        {
            if (caloriesAdded < 0)
            {
                Console.WriteLine($"{caloriesAdded} not a valid number. Please enter a positive number for calories eaten.");
                break;
            }
            else if (caloriesAdded >= 0)
            {
                Console.WriteLine($"{meal} calories added: {caloriesAdded}");
                Console.WriteLine();
                validInput = true;
            }
        }
        else
        {
            Console.WriteLine($"{calorieString} is not a valid response. Please enter a valid number.");
        }
    } while (validInput == false);


    return caloriesAdded;
}
