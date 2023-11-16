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
string currentMeal = "";

decimal maxCalories;
int mealInput;

bool weightValid = false;
bool doAgain = false;


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

/*
* Loop to allow user to input calories per meal,
* allows user to decide if they want to input additional
* meals after each itereation.
*/
do
{

    double breakfastCalories = 0;
    double lunchCalories = 0;
    double dinnerCalories = 0;
    double snackCalories = 0;

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

    /* 
    * May combine switch and if statements,
    * feels like if statement a bit redundant
    */
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

    if (currentMeal.Equals("Breakfast"))
    {
        breakfastCalories = CalAdd(currentMeal);
        totalCalories += breakfastCalories;
    }
    else if (currentMeal.Equals("Lunch"))
    {
        lunchCalories = CalAdd(currentMeal);
        totalCalories += lunchCalories;
    }
    else if (currentMeal.Equals("Diiner"))
    {
        dinnerCalories = CalAdd(currentMeal);
        totalCalories += dinnerCalories;
    }
    else if (currentMeal.Equals("Snacks"))
    {
        snackCalories = CalAdd(currentMeal);
        totalCalories += snackCalories;
    }

    Console.WriteLine();

    Console.WriteLine($"Current total calories eaten for today: {totalCalories} calories.");
    Console.WriteLine();

    Console.WriteLine("Do you want to add more calories? (Y/N)");
    string? addMore = Console.ReadLine();

    while (addMore == null || !addMore.ToUpper().Equals("Y") || !addMore.ToUpper().Equals("N"))
    {
        Console.WriteLine("INVALID. Please enter Y or N.");
        addMore = Console.ReadLine();
    }

    if (addMore.ToUpper().Equals("Y"))
        doAgain = true;

} while (doAgain == true);


/*
* Method to add calories, takes user input
* and converts it to number after validation
* then returns that number to assign to variable.
*/

static double CalAdd(string meal)
{
    bool validInput = false;
    double caloriesAdded = 0;
    string? calorieString;

    Console.WriteLine($"Please enter calories consumed for {meal.ToLower()}");

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
