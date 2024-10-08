﻿using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using static Program;

public class Program
{
    public static void GetNumberOfTimesALetterAppearsInText(string input, char lookUpLetter)
    {
        /*
        The purpose of this code is
        to count the number of times 
        a particular character appears. 
        */

        int letterCount = 0;
        foreach (char letter in input)
        {
            if (letter == lookUpLetter)
            {
                letterCount++;
            }
        }

        Console.WriteLine(input);
        Console.WriteLine($"'{lookUpLetter}' appears {letterCount} times.");
    }

    public static void GetTheScopeOfAVariable()
    {
        /*
        To be able to respond to both true and false execution paths,
        the compiler needs variable value to be initialized.
        Otherwise, it will not be able to respond when flag is false.
        */

        bool flag = true;
        int value = 0;

        while (flag)
        {
            Console.WriteLine($"Inside the code block: {value}");
            flag = false;
            value = 10;
        }

        Console.WriteLine($"Outside the code block: {value}");
    }

    public static void ReadibilityIsKing()
    {
        bool flag = true;
        if (flag)
        {
            Console.WriteLine(flag);
        }

        if (flag)
            Console.WriteLine(flag);

        if (flag) Console.WriteLine(flag);

        string name = "steve";

        if (name == "bob")
        {
            Console.WriteLine("Found Bob");
        }
        else if (name == "steve")
        {
            Console.WriteLine("Found Steve");
        }
        else
        {
            Console.WriteLine("Found Chuck");
        }

        if (name == "bob")
            Console.WriteLine("Found Bob");
        else if (name == "steve")
            Console.WriteLine("Found Steve");
        else
            Console.WriteLine("Found Chuck");

        if (name == "bob") Console.WriteLine("Found Bob");
        else if (name == "steve") Console.WriteLine("Found Steve");
        else Console.WriteLine("Found Chuck");
    }

    public static void ProblematicCode()
    {
        bool found = false;
        int total = 0;
        int[] numbers = { 4, 8, 15, 16, 23, 42 };

        foreach (int number in numbers)
        {
            total += number;

            if (number == 42)
            {
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine("Set contains 42");
        }

        Console.WriteLine($"Total: {total}");
    }

    public static void FlipACoin()
    {
        Random random = new Random();
        int result = random.Next(0, 2);
        Console.WriteLine(result == 0 ? "heads" : "tails");
    }

    public class User
    {
        public string Permission { get; set; }
        public int Level { get; set; }

        public User(string permission, int level)
        {
            Permission = permission;
            Level = level;
        }
    }

    public static void GetAccess(User user)
    {
        if (user.Permission == "Admin" && user.Level > 55)
        {
            Console.WriteLine("Welcome, Super Admin user.");
        }
        else if (user.Permission == "Admin" && user.Level <= 55)
        {
            Console.WriteLine("Welcome, Admin user.");
        }
        else if (user.Permission == "Manager" && user.Level >= 20)
        {
            Console.WriteLine("Contact an Admin for access.");
        }
        else if (user.Permission == "Manager" && user.Level < 20)
        {
            Console.WriteLine("You do not have sufficient privileges.");
        }
        else if (user.Permission != "Manager" || user.Permission != "Admin")
        {
            Console.WriteLine("You do not have sufficient privileges.");
        }
    }

    public static string[] GetTitle(int level)
    {
        Random random = new Random();
        string[] employees = { "John Smith", "John Doe", "Hello World" };

        int index = random.Next(employees.Length);
        string employee = employees[index];

        string title = string.Empty;

        switch (level)
        {
            case 10:
                title = "Senior Associate";
                break;

            case 9:
            case 8:
            case 7:
                title = "Manager";
                break;

            case 6:
                title = "Senior Manager";
                break;

            default:
                title = "Associate";
                break;
        }

        return new string[] { employee, title };
    }

    public static string[] IfElseIfIntoSwitch()
    {
        // SKU = Stock Keeping Unit. 
        // SKU value format: <product #>-<2-letter color code>-<size code>
        string sku = "01-MN-L";

        string[] product = sku.Split('-');

        string type = string.Empty;
        string color = string.Empty;
        string size = string.Empty;

        switch (product[0])
        {
            case "01":
                type = "Sweat shirt";
                break;
            case "02":
                type = "T-Shirt";
                break;
            case "03":
                type = "Sweat pants";
                break;
            default:
                type = "Other";
                break;
        }

        switch (product[1])
        {
            case "BL":
                color = "Black";
                break;
            case "MN":
                color = "Maroon";
                break;
            default:
                color = "White";
                break;
        }

        switch (product[2])
        {
            case "S":
                size = "Small";
                break;
            case "M":
                size = "Medium";
                break;
            case "L":
                size = "Large";
                break;
            default:
                size = "One Size Fits All";
                break;
        }

        return new string[] { sku, type, color, size };
    }

    public static void FizzBuzz()
    {
        string output = string.Empty;

        for (int i = 1; i < 101; i++)
        {
            bool isDivisibleBy3 = i % 3 == 0;
            bool isDivisibleBy5 = i % 5 == 0;

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                output = $"{i} - FizzBuzz";
            }
            else if (isDivisibleBy5)
            {
                output = $"{i} - Buzz";
            }
            else if (isDivisibleBy3)
            {
                output = $"{i} - Fizz";
            }
            else
            {
                output = $"{i}";
            }

            Console.WriteLine(output);
        }
    }

    public static void DoWhile()
    {
        Random random = new Random();
        int number = 0;

        do
        {
            number = random.Next(0, 11);
            Console.WriteLine(number);
        } while (number != 7);
    }

    public static void While()
    {
        Random random = new Random();
        int number = 0;

        while (number != 9)
        {
            Console.WriteLine(number);
            number = random.Next(0, 11);
        }
        Console.WriteLine($"Last number: {number}");
    }

    public static void WhileContinue()
    {
        Random random = new Random();
        int current = 0;

        do
        {
            current = random.Next(1, 11);

            if (current >= 8)
            {
                continue;
            }

            Console.WriteLine(current);
        } while (current != 7);
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }

    public static void RolePlayingGame()
    {
        Player hero = new Player("Hero", 20);
        Player monster = new Player("Monster", 20);
        int attack;

        do
        {
            attack = new Random().Next(1, 11);
            monster.Health -= attack;
            Console.WriteLine($"{hero.Name} has attacked {monster.Name} by {attack}: {monster.Name}'s health is {(monster.Health <= 0 ? 0 : monster.Health)}");

            if (monster.Health <= 0 || hero.Health <= 0)
            {
                break;
            }

            attack = new Random().Next(1, 11);
            hero.Health -= attack;
            Console.WriteLine($"{monster.Name} has attacked {hero.Name} by {attack}: {hero.Name}'s health is {(hero.Health <= 0 ? 0 : hero.Health)}");

        } while (hero.Health > 0 && monster.Health > 0);
        Console.WriteLine(hero.Health > monster.Health ? $"{hero.Name} wins!" : $"{monster.Name} wins!");
    }

    public static void IntegerInput()
    {
        string? input;
        bool validEntry = false; // Exit condition.

        Console.WriteLine("Enter an integer value between 5 and 10:");

        do
        {
            input = Console.ReadLine();

            if (int.TryParse(input, out int output))
            {
                if (output >= 5 && output <= 10)
                {
                    validEntry = true;
                    Console.WriteLine($"Your input value ({output}) has been accepted.");
                }
                else
                {
                    Console.WriteLine($"You entered {output}. Please enter a number between 5 and 10:");
                }
            }
            else
            {
                Console.WriteLine("Sorry, you entered an invalid number, please try again:");
            }
        } while (!validEntry);
    }

    public static void StringInput()
    {
        string? input;
        bool validEntry = false; // Exit condition.

        string[] roles = ["Administrator", "Manager", "User"];
        string validRole = string.Empty;

        do
        {
            Console.WriteLine("Enter your role name (Administrator, Manager, or User):");
            input = Console.ReadLine();

            foreach (string role in roles)
            {
                if (!string.IsNullOrEmpty(input) && input.Equals(role, StringComparison.OrdinalIgnoreCase))
                {
                    validRole = role;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(validRole))
            {
                validEntry = true;
                Console.WriteLine($"Your input value({validRole}) has been accepted.");
            }
            else
            {
                Console.WriteLine($"The role name that you entered, \"{input}\" is not valid.");
            }

        } while (!validEntry);
    }

    public static void StringArray()
    {
        string[] myStrings = ["I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"];
        int periodLocation = -1;

        for (int i = 0; i < myStrings.Length; i++)
        {
            do
            {
                periodLocation = myStrings[i].Contains('.') ? myStrings[i].IndexOf('.') : periodLocation;

                if (periodLocation > 0)
                {
                    string tempString = myStrings[i][..periodLocation];
                    Console.WriteLine(tempString);
                    myStrings[i] = myStrings[i].Remove(0, tempString.Length + 1).Trim();
                    periodLocation = -1;
                }
                else
                {
                    Console.WriteLine(myStrings[i]);
                    break;
                }
            } while (periodLocation < 0);
        }
    }

    private List<Animal> ourAnimals = new List<Animal>();
    private HashSet<string> acceptedSpecies = new HashSet<string>() { "cat", "dog" };
    private int idCounter = 1;
    private int maxAnimals = 6;
    bool isFull;

    public class Animal
    {
        public int Id { get; }
        public string Species { get; set; }
        public string Nickname { get; set; }
        public int? Age { get; set; }
        public string? Characteristics { get; set; }
        public string? Personality { get; set; }
        public string? SuggestedDonation { get; set; }

        public Animal(int id, string species, string? age, string? characteristics, string? personality, string nickname, string? suggestedDonation = null)
        {
            Id = id;
            Species = species;
            Age = (!string.IsNullOrEmpty(age)) ? int.Parse(age) : 0;
            Characteristics = characteristics;
            Personality = personality;
            Nickname = nickname;
            SuggestedDonation = !string.IsNullOrEmpty(suggestedDonation) ? suggestedDonation : "45,00";
        }
    }

    public static void ShowCommands()
    {
        Dictionary<string, string> commands = new Dictionary<string, string>
        {
            { "all" , "List all current animals." },
            { "cats" , "List current cats." },
            { "dogs" , "List current dogs." },
            { "add" , "Add a new animal." },
            { "edit" , "Edit an animal." },
            { "delete" , "Delete an animal." },
            { "search" , "Search an animal by keyword." },
            { "commands", "Show commands." },
            { "quit" , "Exit the program." }
        };

        Console.WriteLine("\nCOMMANDS");

        foreach (KeyValuePair<string, string> command in commands)
        {
            Console.WriteLine($"{command.Key,-20}{command.Value}");
        }
    }

    public bool ListAnimals(string? searchSpecies = null, string? searchOtherData = null, int? searchId = null)
    {
        PropertyInfo[] properties = typeof(Animal).GetProperties();
        List<Animal> targets = new List<Animal>();

        if (!string.IsNullOrEmpty(searchSpecies))
        {
            targets = ourAnimals.Where(e => e.Species == searchSpecies).ToList();
        }
        else if (searchId != null)
        {
            targets = ourAnimals.Where(e => e.Id == searchId).ToList();
        }
        else if (!string.IsNullOrEmpty(searchOtherData))
        {
            bool IsValid(string? str)
            {
                return !string.IsNullOrEmpty(str) && str.Contains(searchOtherData, StringComparison.OrdinalIgnoreCase);
            }

            targets = ourAnimals.Where(e => IsValid(e.Characteristics) || IsValid(e.Personality)).ToList();
        }
        else
        {
            targets = ourAnimals;
        }

        if (searchOtherData is null && targets.Count > 1)
        {
            Console.Write($"\n============================ ALL {(!string.IsNullOrEmpty(searchSpecies) ? (searchSpecies + "s").ToUpper() : "ANIMALS")} ============================\n");
        }
        else if (searchOtherData is not null && targets.Count > 0)
        {
            Console.Write($"\n============================ SEARCH RESULTS: {targets.Count} ============================\n");
        }

        foreach (Animal animal in targets)
        {
            Console.Write("\n");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name,-20}{property.GetValue(animal)}");
            }
        }

        return targets.Count > 0;
    }

    public void AddNewAnimal()
    {
        CheckIfFull();
        if (isFull)
        {
            Console.WriteLine("\n/!\\ Our shelter is currently full.");
            return;
        }

        Console.Write("\n");

        string? species;
        do
        {
            Console.Write($"{string.Join(" or ", acceptedSpecies)[..1].ToUpper()}{string.Join(" or ", acceptedSpecies)[1..]}?\t");
            species = Console.ReadLine();
        } while (string.IsNullOrEmpty(species) || !acceptedSpecies.Contains(species.ToLower()));

        string? nickname;
        do
        {
            Console.Write("Nickname?\t");
            nickname = Console.ReadLine();

        } while (string.IsNullOrEmpty(nickname) || nickname.Length < 2);

        nickname = $"{nickname[..1].ToUpper()}{nickname[1..]}";

        string? age;
        bool isValid = false;
        do
        {
            Console.Write($"Age? (Press 'Enter' to complete later).\t");
            age = Console.ReadLine();

            if (!string.IsNullOrEmpty(age))
            {
                if (int.TryParse(age, out int output) && output < 20)
                {
                    isValid = true;
                }
            }
            else
            {
                isValid = true;
            }

        } while (!isValid);

        string? characteristics;

        Console.Write("Characteristics? (Press 'Enter' to complete later).\t");
        characteristics = Console.ReadLine();

        string? personality;

        Console.Write("Personality? (Press 'Enter' to complete later).\t");
        personality = Console.ReadLine();

        try
        {
            Animal newAnimal = new Animal(idCounter++, species.ToLower(), age, characteristics, personality, nickname);
            ourAnimals.Add(newAnimal);
            Console.WriteLine($"\n{nickname} has been successfully added to the database.\n");

            Console.Write($"\n============================ NEW ENTRY START ============================\n");
            ListAnimals(searchId: newAnimal.Id);

            Console.WriteLine($"\nWe can shelter {maxAnimals - ourAnimals.Count} more.");
            Console.Write($"\n============================ NEW ENTRY END ============================\n");
        }
        catch
        {
            throw new Exception("An error occurred, please try again.");
        }
    }

    public PropertyInfo? SelectProperty(Animal? target)
    {
        string? input;
        PropertyInfo? selection = null;

        ListAnimals(searchId: target?.Id);

        bool propertyExists = false;
        PropertyInfo[] properties = typeof(Animal).GetProperties();

        do
        {
            Console.Write("\nWhich property?\t");
            input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You cannot change this property.");
                }
                else
                {
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.Name.Equals(input, StringComparison.OrdinalIgnoreCase))
                        {
                            selection = property;
                            propertyExists = true;
                            break;
                        }
                    }
                }
            }
        }
        while (string.IsNullOrEmpty(input) || !propertyExists);

        return selection;
    }

    public void UpdateProperty(Animal? target, PropertyInfo? selection)
    {
        string? input;

        do
        {
            if (selection?.Name == "Species")
            {
                do
                {
                    Console.Write($"\nYou can only select between: {string.Join(", ", acceptedSpecies)} \t");
                    input = Console.ReadLine();
                } while (string.IsNullOrEmpty(input) || !acceptedSpecies.Contains(input.ToLower()));
            }
            else if (selection?.Name == "Age")
            {
                int age;
                bool isValid;
                do
                {
                    Console.Write("Please enter a number.\t");

                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out age);
                } while (string.IsNullOrEmpty(input) || !isValid || age > 20);
            }
            else
            {
                Console.Write("\nEnter new information:\t");
                input = Console.ReadLine();
            }

            if (!string.IsNullOrEmpty(input))
            {
                if (selection?.PropertyType == typeof(int?))
                {
                    selection?.SetValue(target, int.Parse(input));
                }
                else
                {
                    selection?.SetValue(target, $"{input[..1].ToUpper()}{input[1..]}");
                }
            }
        }
        while (string.IsNullOrEmpty(input));
    }

    public void EditAnimal()
    {
        ListAnimals();

        string? input;
        do
        {
            Console.Write("\nWhich animal would you like to edit (id)?\t");
            input = Console.ReadLine();

            bool isValid = int.TryParse(input, out int output);
            if (!isValid)
            {
                input = null;
                continue;
            }

            Animal? target = ourAnimals.Select(e => e).Where(e => e.Id == output).FirstOrDefault();

            if (target is null)
            {
                input = null;
                continue;
            }

            Console.Write($"\n============================ EDIT START ============================\n");

            PropertyInfo? selection = SelectProperty(target);
            UpdateProperty(target, selection);

            Console.Write($"\n============================ EDIT END ============================\n");
            ListAnimals(searchId: target?.Id);

        }
        while (string.IsNullOrEmpty(input));
    }

    public void DeleteAnimal()
    {
        ListAnimals();

        string? input;
        do
        {
            Console.Write("\nWhich animal would you like to delete (id)?\t");
            input = Console.ReadLine();

            bool isValid = int.TryParse(input, out int output);
            if (!isValid)
            {
                input = null;
                continue;
            }

            Animal? target = ourAnimals.Select(e => e).Where(e => e.Id == output).FirstOrDefault();

            if (target is null)
            {
                input = null;
                continue;
            }

            ourAnimals.Remove(target);
            Console.Write($"\n============================ DELETE START ============================\n");

            Console.Write($"\nEntry {input} successfully deleted.\n");
            ListAnimals(searchOtherData: "");
            Console.Write($"\n============================ DELETE END ============================\n");
        }
        while (string.IsNullOrEmpty(input));
    }

    public void SearchAnimal()
    {
        Console.Write("\nPlease enter a keyword:\t");
        string? input;
        bool IsFound;

        do
        {
            input = Console.ReadLine();
            IsFound = ListAnimals(searchOtherData: input);

            if (!IsFound)
            {
                Console.Write("\nThe keyword entered was not found. Try again:\t");
            }
        }
        while (string.IsNullOrEmpty(input) || !IsFound);
    }

    public void CheckIfFull()
    {
        isFull = ourAnimals.Count == maxAnimals;
    }

    public void ContosoPets()
    {
        string? input;

        ourAnimals = new List<Animal>
        {
            new Animal(idCounter++, "dog", "4", "Golden retriever, long golden fur, enjoys swimming", "Friendly, devoted, intelligent", "Buddy"),
            new Animal(idCounter++, "dog", "2", "Beagle, tricolor coat, excellent sense of smell", "Curious, loving, determined", "Hunter"),
            new Animal(idCounter++, "cat", "3", "Siamese, cream coat with dark brown points, blue almond - shaped eyes", "Vocal, social, intelligent", "Mocha"),
            new Animal(idCounter++, "cat", "1", "Maine Coon, large size, tufted ears, bushy tail", "Gentle, playful, friendly", "Leo"),
        };

        Console.WriteLine("Welcome to the ContosoPets app.");
        Console.WriteLine($"We currently have {ourAnimals.Count} animals in search of a new home.");

        CheckIfFull();

        if (!isFull)
        {
            Console.WriteLine($"We can shelter {maxAnimals - ourAnimals.Count} more.");
        }
        else
        {
            Console.WriteLine($"Our shelter is full.");
        }

        ShowCommands();

        do
        {
            Console.WriteLine("\nEnter desired command:");
            input = Console.ReadLine();

            switch (input)
            {
                case "all": ListAnimals(); break;
                case "dogs": ListAnimals("dog"); break;
                case "cats": ListAnimals("cat"); break;
                case "add": AddNewAnimal(); break;
                case "edit": EditAnimal(); break;
                case "delete": DeleteAnimal(); break;
                case "search": SearchAnimal(); break;
                case "commands": ShowCommands(); break;
                case "clear": Console.Clear(); break;
                case "quit": Environment.Exit(0); break;
                default: Console.WriteLine("\nSorry, this command is not available. Please try again."); break;
            }

        } while (!string.IsNullOrEmpty(input));
    }

    public static void IntToString(int input)
    {
        string output = "4";
        Console.WriteLine(output += input);
    }

    public static void StringAndInt(string[] values)
    {
        StringBuilder sb = new StringBuilder();
        decimal sum = 0;

        foreach (string value in values)
        {
            if (decimal.TryParse(value, CultureInfo.InvariantCulture, out decimal result))
            {
                sum += result;
            }
            else
            {
                sb.Append(value);
            }
        }

        Console.WriteLine($"Message: {sb}");
        Console.WriteLine($"Total: {sum}");
    }

    public static void NumberTypes()
    {
        int value1 = 11;
        decimal value2 = 6.2m;
        float value3 = 4.3f;

        int result1 = Convert.ToInt32(value1 / value2);
        Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

        decimal result2 = value2 / (decimal)value3;
        Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

        float result3 = value3 / value1;
        Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
    }

    public static void SignedTypes()
    {
        Console.WriteLine("Signed integral types:");

        Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
        Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
        Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
        Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");
    }

    public static void UnsignedTypes()
    {
        Console.WriteLine("");
        Console.WriteLine("Unsigned integral types:");

        Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
        Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
        Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
        Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
    }

    public static void FloatingTypes()
    {
        Console.WriteLine("");
        Console.WriteLine("Floating point types:");
        Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
        Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
        Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
    }

    public static void ReferenceTypes()
    {
        int val_A = 2;
        int val_B = val_A;
        val_B = 5;

        Console.WriteLine("--Value Types--");
        Console.WriteLine($"val_A: {val_A}");
        Console.WriteLine($"val_B: {val_B}");

        int[] ref_A = new int[1];
        ref_A[0] = 2;
        int[] ref_B = ref_A;
        ref_B[0] = 5;

        Console.WriteLine("--Reference Types--");
        Console.WriteLine($"ref_A[0]: {ref_A[0]}");
        Console.WriteLine($"ref_B[0]: {ref_B[0]}");
    }

    public class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Hello.");
        }
    }

    public static void RemoveEmptyElements()
    {
        string[] arr = { "B14", "A11", "B12", "A13" };
        Console.WriteLine(string.Join(" | ", arr));

        Array.Resize(ref arr, 8);
        Console.WriteLine(string.Join(" | ", arr));

        arr[4] = "a";
        arr[6] = "b";
        Console.WriteLine(string.Join(" | ", arr));

        int index = 0;
        string[] newArr = new string[index];

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] is null)
            {
                continue;
            }

            Array.Resize(ref newArr, index + 1);
            newArr[index] = arr[i];
            index++;
        }

        Console.WriteLine(string.Join(" | ", newArr));
    }

    public static void ReverseString(string input)
    {
        char[] arr = input.ToCharArray();
        Console.WriteLine(arr); // abc123.

        Array.Reverse(arr); // Arrays are reference-type; so changes are made to the original array.
        Console.WriteLine(arr); // 321cba.

        string output = string.Join(", ", arr);
        Console.WriteLine(output); //3, 2, 1, c, b, a.

        string[] items = output.Split(", ");
        foreach (string item in items) { Console.WriteLine(item); }
    }

    public static void Pangram(string input)
    {
        StringBuilder sb = new StringBuilder();

        string[] items = input.Split(" ");
        foreach (string item in items)
        {
            char[] arr = item.ToCharArray();
            Array.Reverse(arr);
            sb.Append(arr);
            sb.Append(' ');
        }

        Console.WriteLine(string.Join(" ", sb).Trim());
    }

    public static void OrderIds(string input)
    {
        string[] items = input.Split(",");
        Array.Sort(items);

        foreach (string item in items)
        {
            if (item.Length == 4)
            {
                Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine($"{item}\t- Error");
            }
        }
    }

    public static void Formatting()
    {
        decimal input = 123.31654m;
        Console.WriteLine($"{input:c}"); // 123,32 €
        Console.WriteLine($"{input:n}"); // 123,32
        Console.WriteLine($"{input:n3}"); // 123,317
        Console.WriteLine($"{input:p2}"); // 123 31,65 %

        string input2 = "hello";
        Console.WriteLine(input2.PadLeft(20, '-'));
        Console.WriteLine(input2.PadRight(20, '-'));
    }

    public static void MagicValues()
    {
        string message = "What is the value <span>between the tags</span>?";

        string openingTag = "<span>";
        string closingTag = "</span>";

        int openingPosition = message.IndexOf(openingTag) + openingTag.Length;
        int closingPosition = message.IndexOf(closingTag);

        // openingPosition += 6; // Avoid hardcoding magic values.
        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
    }

    public static void Indexes()
    {
        string message = "(What if) I am (only interested) in the last (set of parentheses)?";

        string openingTag = "(";
        string closingTag = ")";

        while (true)
        {
            int openingPosition = message.IndexOf(openingTag);
            int closingPosition = message.IndexOf(closingTag);

            if (openingPosition < 0)
            {
                break;
            }

            openingPosition += openingTag.Length;

            int length = closingPosition - openingPosition;

            Console.WriteLine(message.Substring(openingPosition, length));
            message = message.Substring(closingPosition + 1);
        }
    }

    public static void Indexes2()
    {
        string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

        char[] openingTags = ['(', '[', '{'];
        char[] closingTags = [')', ']', '}'];

        while (true)
        {
            int openingPosition = message.IndexOfAny(openingTags);
            if (openingPosition < 0)
            {
                break;
            }

            char openingTag = message[openingPosition]; // Access char within string as if it were an array.
            openingPosition += 1;

            int index = Array.IndexOf(openingTags, openingTag);
            int closingPosition = message.IndexOf(closingTags[index]);

            int length = closingPosition - openingPosition;

            Console.WriteLine(message.Substring(openingPosition, length));
            message = message.Substring(closingPosition + 1);
        }
    }

    public static void Remove()
    {
        string input = "helloworld";
        string output1 = input.Remove(5); // hello
        string output2 = input.Remove(0, output1.Length); // world
        Console.WriteLine(output1);
        Console.WriteLine(output2);
    }

    public static void Replace()
    {
        string input = "helloworld";
        string output = input.Replace("hello", "world");
        Console.WriteLine(output); //worldworld
    }

    public static void FormatStringData()
    {
        const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

        string quantity = "";
        string output = "";

        string[] openingTags = ["<div>", "<span>"];

        foreach (string tag in openingTags)
        {
            int openingPosition = input.IndexOf(tag);
            openingPosition += tag.Length;

            string closingTag = tag.Replace("<", "</");
            int closingPosition = input.IndexOf(closingTag);

            int length = closingPosition - openingPosition;

            if (Array.IndexOf(openingTags, tag) == 0)
            {
                output = input.Substring(openingPosition, length);
                output = output.Replace("&trade;", "&reg;");
            }
            else
            {
                quantity = input.Substring(openingPosition, length);
            }
        }

        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Output: {output}");
    }

    public static void Contoso2()
    {
        CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
        Console.OutputEncoding = Encoding.UTF8;

        string welcomeMessage = $"Welcome to the Contoso PetFriends app. Your main menu options are:" +
            $"\n 1. List all of our current pet information" +
            $"\n 2. Display all dogs with a specified characteristic";

        // #1 the ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        // #2 variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";
        decimal decimalDonation = 0.00m;

        // #3 array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 7];

        // #4 create sample data ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85,00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "gus";
                    suggestedDonation = "49,00";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "snow";
                    suggestedDonation = "40,00";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "3";
                    animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                    animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                    animalNickname = "Lion";
                    suggestedDonation = "";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;

            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m;
            }
            ourAnimals[i, 6] = $"Suggested donation: {decimalDonation:c2}";
        }

        // #5 display the top-level menu options
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
            Console.Clear();

            Console.WriteLine($"{welcomeMessage}");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // use switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // list all pet info
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 7; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // Display all dogs with a specified characteristic
                    string userInput = string.Empty;
                    int matches = 0;

                    while (string.IsNullOrEmpty(userInput))
                    {
                        Console.Clear();

                        Console.WriteLine($"{welcomeMessage}");
                        Console.WriteLine();
                        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
                        Console.WriteLine("2");
                        Console.WriteLine();
                        Console.WriteLine("Enter one desired dog characteristic to search for:");
                        readResult = Console.ReadLine();

                        if (!string.IsNullOrEmpty(readResult))
                        {
                            userInput = readResult.ToLower().Trim();
                        }
                    }

                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 1].Contains("dog"))
                        {
                            Regex regex = new Regex(userInput);
                            string characteristics = $"{ourAnimals[i, 4]}{ourAnimals[i, 5]}";

                            if (regex.Match(characteristics).Success)
                            {
                                Console.WriteLine();
                                for (int j = 0; j < 7; j++)
                                {
                                    Console.WriteLine(ourAnimals[i, j]);
                                }

                                matches++;
                            }
                        }
                    }

                    if (matches < 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("No matches found.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");
    }

    public static void Contoso3()
    {
        CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
        Console.OutputEncoding = Encoding.UTF8;

        string welcomeMessage = $"Welcome to the Contoso PetFriends app. Your main menu options are:" +
            $"\n 1. List all of our current pet information." +
            $"\n 2. Display all dogs with a specified characteristic.";

        // Data entry variables -------------------------------------------
        int id = 0;
        string? readResult;
        string menuSelection = "";

        // Static data ----------------------------------------------------
        List<Animal> ourAnimals = new List<Animal>() {
        new Animal(
            ++id,
            "dog",
            "2",
            "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.",
            "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
            "lola",
            "85,00"),

        new Animal(
            ++id,
            "dog",
            "9",
            "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
            "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
            "gus",
            "49,00"),

        new Animal(
            ++id,
            "cat",
            "1",
            "small white female weighing about 8 pounds. litter box trained.",
            "friendly",
            "snow",
            "40,00"),

        new Animal(
            ++id,
            "cat",
            "3",
            "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.",
            "A people loving cat that likes to sit on your lap.",
            "Lion")
        };

        // Menu options ---------------------------------------------------
        do
        {
            Console.Clear();

            Console.WriteLine($"{welcomeMessage}");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // Switch case ------------------------------------------------
            switch (menuSelection)
            {
                case "1":
                    foreach (Animal animal in ourAnimals)
                    {
                        Console.WriteLine();

                        PropertyInfo[] properties = animal.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            Console.WriteLine($"{property.Name}: {property.GetValue(animal)}");
                        }
                    }

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // 2. Search functionality ----------------------------
                    string[] loadingIcons = [".", "..", "..."];
                    List<string> lookUpWords = new List<string>();
                    List<string> lookAgainstWords = new List<string>();
                    List<string> notFoundWords = new List<string>();
                    Dictionary<Animal, List<string>> results = new Dictionary<Animal, List<string>>();

                    readResult = string.Empty;

                    // List input data ------------------------------------
                    while (string.IsNullOrEmpty(readResult))
                    {
                        Console.Clear();

                        Console.WriteLine($"{welcomeMessage}");
                        Console.WriteLine();
                        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
                        Console.WriteLine("2");
                        Console.WriteLine();
                        Console.WriteLine("Enter desired dog characteristics to search for:");
                        readResult = Console.ReadLine();

                        if (!string.IsNullOrEmpty(readResult))
                        {
                            Regex regex = new Regex(@"\w+");
                            foreach (Match match in regex.Matches(readResult))
                            {
                                lookUpWords.Add(match.Value.ToLower());
                            }
                        }
                    }

                    Console.WriteLine();

                    // Loading icons --------------------------------------
                    foreach (string icon in loadingIcons)
                    {
                        Console.Write($"\rSearching {icon}");
                        Thread.Sleep(200);
                    }

                    Console.WriteLine();

                    // Compare input against base -------------------------
                    foreach (Animal animal in ourAnimals)
                    {
                        if (animal.Species != "dog")
                        {
                            continue;
                        }

                        foreach (string word in lookUpWords)
                        {
                            string lookAgainstString = $"{animal.Characteristics} {animal.Personality}";
                            if (!string.IsNullOrEmpty(lookAgainstString))
                            {
                                Regex regex = new Regex(@"\w+");
                                foreach (Match match in regex.Matches(lookAgainstString))
                                {
                                    lookAgainstWords.Add(match.Value.ToLower());
                                }
                            }

                            if (lookAgainstWords.Contains(word))
                            {
                                if (results.ContainsKey(animal))
                                {
                                    results[animal].Add(word);
                                }
                                else
                                {
                                    results.Add(animal, new List<string> { word });
                                }
                            }
                            lookAgainstWords.Clear();
                        }
                    }

                    // Print found data -----------------------------------
                    foreach (var entry in results)
                    {
                        Console.WriteLine();

                        foreach (var word in entry.Value)
                        {
                            Console.WriteLine($"=> Match found for pet {entry.Key.Nickname}, word: '{word}'");
                        }

                        Console.WriteLine();

                        PropertyInfo[] properties = entry.Key.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            Console.WriteLine($"{property.Name}: {property.GetValue(entry.Key)}");
                        }
                    }

                    // Print not found data -------------------------------
                    foreach (string lookUpWord in lookUpWords)
                    {
                        if (results.Count < 1)
                        {
                            notFoundWords.Add(lookUpWord);
                        }
                        else
                        {
                            foreach (var entry in results)
                            {
                                if (!entry.Value.Contains(lookUpWord))
                                {
                                    notFoundWords.Add(lookUpWord);
                                }
                            }
                        }
                    }

                    if (notFoundWords.Count > 0)
                    {
                        Console.WriteLine();

                        foreach (string word in notFoundWords)
                        {
                            Console.WriteLine($"=> No match found for word: '{word}'");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");
    }

    public static void PrintMessage(string message) => Console.WriteLine(message);

    public static void ValueType()
    {
        int x = 0;
        Console.WriteLine(x);

        ModifyValue(x);
        Console.WriteLine(x);
    }

    public static void ModifyValue(int x)
    {
        x = 10;
    }

    public static void ReferenceType()
    {
        int[] arr = [1, 2, 3];
        Console.WriteLine(string.Join(", ", arr));

        ModifyReference(arr);
        Console.WriteLine(string.Join(", ", arr));
    }

    public static void ModifyReference(int[] arr)
    {
        arr[0] = 10;
        arr[1] = 20;
        arr[2] = 30;
    }

    public static void StringType()
    {
        string original = "Hello World";
        Console.WriteLine(original); // Hello World.

        ModifyString(original);
        Console.WriteLine(original); // Still Hello World.
    }
    public static void ModifyString(string str)
    {
        str = "World Hello";
    }

    public class Invitee
    {
        public string Name { get; set; }
        public int PartySize { get; set; }
        public string Allergies { get; set; }
        public bool InviteOnly { get; set; }

        public Invitee(string name, int partySize = 1, bool inviteOnly = true, string allergie = "none")
        {
            Name = name;
            PartySize = partySize;
            Allergies = allergie;
            InviteOnly = inviteOnly;
        }
    }

    public static void RSVP()
    {
        Invitee[] invitees =
        [
            new Invitee("Rebecca"),
            new Invitee("Nadia", partySize: 2, allergie: "Nuts"),
            new Invitee("Linh", partySize: 2, inviteOnly: false),
            new Invitee("Tony", allergie: "Jackfruit"),
            new Invitee("Noor", 4, inviteOnly: false),
            new Invitee("Jonte", 2, false, "Stone fruit")
        ];

        string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
        string[] rsvps = new string[10];
        int count = 0;

        foreach (Invitee invitee in invitees)
        {
            bool isOnList = RSVP(invitee.Name, invitee.PartySize, invitee.Allergies, invitee.InviteOnly, guestList, rsvps, count);
            if (isOnList)
            {
                count++;
            }
        }

        ShowRSVPs(rsvps, count);
    }

    public static bool RSVP(string name, int partySize, string allergies, bool inviteOnly, string[] guestList, string[] rsvps, int count)
    {
        if (inviteOnly)
        {
            bool found = false;
            foreach (string guest in guestList)
            {
                if (guest.Equals(name))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Sorry, {name} is not on the guest list");
                return false;
            }
        }

        rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
        return true;
    }

    public static void ShowRSVPs(string[] rsvps, int count)
    {
        Console.WriteLine("\nTotal RSVPs:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(rsvps[i]);
        }
    }

    public static void EmployeeEmails()
    {
        string[,] employees =
        {
            {"int", "Robert", "Bavin"}, {"int", "Simon", "Bright"},
            {"int", "Kim", "Sinclair"}, {"int", "Aashrita", "Kamath"},
            {"int", "Sarah", "Delucchi"}, {"int", "Sinan", "Ali"},
            {"ext", "Vinnie", "Ashton"}, {"ext", "Cody", "Dysart"},
            {"ext", "Shay", "Lawrence"}, {"ext", "Daren", "Valdes"}
        };

        string externalDomain = "hayworth.com";

        for (int i = 0; i < employees.GetLength(0); i++)
        {
            DisplayEmail(
                name: employees[i, 1],
                surName: employees[i, 2],
                domain: employees[i, 0] == "ext" ? externalDomain : "contoso.com");
        }
    }

    public static void DisplayEmail(string name, string surName, string domain)
    {
        string email = $"{name.Substring(0, 2).ToLower()}";
        email += $"{surName.ToLower()}";
        email += $"@{domain}";

        Console.WriteLine($"{email}");
    }

    public static void FormatAndDisplayMedicineTimes(int[] times)
    {
        foreach (int val in times)
        {
            string time = val.ToString();
            int len = time.Length;

            if (len >= 3)
            {
                time = time.Insert(len - 2, ":");
            }
            else if (len == 2)
            {
                time = time.Insert(0, "0:");
            }
            else
            {
                time = time.Insert(0, "0:0");
            }

            Console.Write($"{time} ");
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public static void AdjustTimes(int currentGMT, int newGMT, int[] times, int diff)
    {
        /* Adjust the times by adding the difference, keeping the value within 24 hours */
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = ((times[i] + diff)) % 2400;
        }
    }

    public static void RefactorAMethod()
    {
        int[] times = [800, 1200, 1600, 2000];
        int diff = 0;

        Console.WriteLine("Enter current GMT");
        int currentGMT = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Current Medicine Schedule:");

        /* Format and display medicine times */
        FormatAndDisplayMedicineTimes(times);

        Console.WriteLine("Enter new GMT");
        int newGMT = Convert.ToInt32(Console.ReadLine());

        if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
        {
            Console.WriteLine("Invalid GMT");
        }
        else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
        {
            diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
            AdjustTimes(currentGMT, newGMT, times, diff);
        }
        else
        {
            diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
            AdjustTimes(currentGMT, newGMT, times, diff);
        }

        Console.WriteLine("New Medicine Schedule:");

        /* Format and display medicine times */
        FormatAndDisplayMedicineTimes(times);
    }

    public static void IpAdressValidator(string ipAdress)
    {
        /*
            if ipAddress consists of 4 numbers
            and
            if each ipAddress number has no leading zeroes
            and
            if each ipAddress number is in range 0 - 255

            then ipAddress is valid

            else ipAddress is invalid
        */

        int[] requiredNumberPerSegment = [3, 1, 1, 1];
        string[] input = ipAdress.Split('.');

        bool hasInvalidInput = false;
        bool hasLeadingZero = false;
        bool isOutOfRange = false;

        Console.Write($"{ipAdress} => ");
        for (int i = 0; i < 4; i++)
        {
            if (!ValidateLength(input[i], i))
            {
                hasInvalidInput = true;
                break;
            }

            if (!ValidateZeroes(input[i], i))
            {
                hasLeadingZero = true;
                break;
            }

            if (!ValidateRange(input[i], i))
            {
                isOutOfRange = true;
                break;
            }
        }

        if (!hasInvalidInput && !hasLeadingZero && !isOutOfRange)
        {
            Console.WriteLine($"IP address '{ipAdress}' is valid IPv4.");
        }

        bool ValidateLength(string number, int segment)
        {
            if (string.IsNullOrEmpty(number))
            {
                Console.WriteLine($"Error: input is null of empty on segment '{segment + 1}'.");
                return false;
            }

            if (!int.TryParse(number, out int _))
            {
                Console.WriteLine($"Error: input is not valid on segment '{segment + 1}', '{input[segment]}', must be a number.");
                return false;
            }

            if (!(number.Length == requiredNumberPerSegment[segment]))
            {
                Console.WriteLine($"Error: length is not valid on segment '{segment + 1}', '{input[segment]}', must be {requiredNumberPerSegment[segment]} number(s) long.");
                return false;
            }

            return true;
        }

        bool ValidateZeroes(string number, int segment)
        {
            if (int.Parse(number[0].ToString()) == 0)
            {
                Console.WriteLine($"Error: input has leading zero on segment '{segment + 1}', '{number}'.");
                return false;
            }

            return true;
        }

        bool ValidateRange(string number, int segment)
        {
            if (int.Parse(number.ToString()) > 255)
            {
                Console.WriteLine($"Error: input is out of range 0 - 255 on segment '{segment + 1}', '{number}'.");
                return false;
            }

            return true;
        }
    }

    public static void TellFortune()
    {
        string[] text = ["You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"];
        string[] good = ["look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"];
        string[] bad = ["fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."];
        string[] neutral = ["appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."];

        int[] testLuck = [0, 50, 99];

        foreach (int luck in testLuck)
        {
            TellFortune(luck);
        }

        void TellFortune(int luck = -1)
        {
            if (luck < 0)
            {
                Random random = new Random();
                luck = random.Next(100);
            }

            Console.WriteLine("A fortune teller whispers the following words:");
            string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{text[i]} {fortune[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public static void ReturnValues()
    {
        double total = 0;
        double minimumSpend = 30.00;

        double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
        double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

        for (int i = 0; i < items.Length; i++)
        {
            total += GetDiscountedPrice(i);
        }

        if (TotalMeetsMinimum())
        {
            total -= 5.00;
        }

        Console.WriteLine($"Total: ${total:n2}");

        double GetDiscountedPrice(int itemIndex)
        {
            return items[itemIndex] * (1 - discounts[itemIndex]);
        }

        bool TotalMeetsMinimum()
        {
            return total >= minimumSpend;
        }
    }

    public static void CoinsForChange()
    {
        int[] targets = [30, 40, 50, 100, 300];
        int[] coins = [5, 5, 50, 25, 25, 10, 5];

        for (int i = 0; i < targets.Length; i++)
        {
            HashSet<(int, int)> result = TwoCoins(coins, targets[i]);

            Console.WriteLine($"Entry {i + 1} ".PadRight(30, '-'));

            if (result.Count == 0)
            {
                Console.WriteLine($"Target: {targets[i]}");
                Console.WriteLine($"Coins: {string.Join(", ", coins)}");
                Console.WriteLine("No two combinations found.");
            }
            else
            {
                Console.WriteLine($"Target: {targets[i]}");
                Console.WriteLine($"Coins: {string.Join(", ", coins)}");
                Console.WriteLine($"Following two combinations found:");
                foreach (var entry in result)
                {
                    Console.WriteLine($"{entry.Item1} + {entry.Item2} = {targets[i]}");
                }
            }
            Console.WriteLine();
        }

        HashSet<(int, int)> TwoCoins(int[] coins, int target)
        {
            HashSet<(int, int)> result = new HashSet<(int, int)>();

            for (int curr = 0; curr < coins.Length; curr++)
            {
                for (int next = curr + 1; next < coins.Length; next++)
                {
                    if (coins[curr] + coins[next] == target)
                    {
                        result.Add((coins[curr], coins[next]));
                    }
                }
            }

            return result;
        }
    }

    public static void DiceMiniGame()
    {
        int target;
        int roll;
        Random random = new Random();

        if (ShouldPlay())
        {
            PlayGame();
        }

        void PlayGame()
        {
            bool play = true;

            while (play)
            {
                target = random.Next(1, 5);
                roll = random.Next(1, 6);

                Console.WriteLine($"Roll a number greater than {target} to win!");
                Console.WriteLine($"You rolled a {roll}");
                Console.WriteLine(WinOrLose());
                Console.WriteLine("\nPlay again? (Y/N)");

                play = ShouldPlay(1);
            }
        }

        bool ShouldPlay(int counter = 0)
        {
            string? input;
            bool isPlay = false;

            do
            {
                if (counter == 0)
                {
                    Console.WriteLine("Would you like to play? (Y/N)");
                }

                input = Console.ReadLine();

                if (input?.ToLower() == "y")
                {
                    isPlay = true;
                    Console.Clear();
                    break;
                }
                else if (input?.ToLower() == "n")
                {
                    isPlay = false;
                    break;
                }
                else
                {
                    Console.Clear();
                    counter = 0;
                }

            } while (input?.ToLower() != "y");

            return isPlay;
        }

        string WinOrLose()
        {
            return roll > target ? "You win!" : "You lose!";
        }
    }

    public static void PettingZoo(string schoolName, int groups)
    {
        /*
         - There will be three visiting schools
            - School A has six visiting groups (the default number)
            - School B has three visiting groups
            - School C has two visiting groups

        - For each visiting school, perform the following tasks
            - Randomize the animals
            - Assign the animals to the correct number of groups
            - Print the school name
            - Print the animal groups
        */

        string[] pettingZoo =
        {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };

        RandomizeAnimals();
        string[,] group = AssignGroup(groups);
        Console.WriteLine($"{"School",-10} {schoolName}");
        PrintGroup(group);

        void RandomizeAnimals()
        {
            Random random = new Random();

            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int j = random.Next(i, pettingZoo.Length);

                string temp = pettingZoo[j];
                pettingZoo[j] = pettingZoo[i];
                pettingZoo[i] = temp;
            }
        }

        string[,] AssignGroup(int groups = 6)
        {
            string[,] result = new string[groups, pettingZoo.Length / groups];
            int start = 0;

            for (int i = 0; i < groups; i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = pettingZoo[start++];
                }
            }

            return result;
        }

        void PrintGroup(string[,] group, int tour = 0)
        {
            int counter = 0;

            while (counter < group.GetLength(0))
            {
                for (int i = 0; i < group.GetLength(0); i++)
                {
                    Console.Write($"{"Group",-10} {i + 1}  =>  ");
                    for (int j = 0; j < group.GetLength(1); j++)
                    {
                        Console.Write($"{group[i, j]} ");
                    }

                    counter++;
                    Console.WriteLine();
                }
            }
        }

        //bool ShouldContinue()
        //{
        //    string? input;

        //    do
        //    {
        //        Console.Write("\rFinished tour? (y) ");
        //        input = Console.ReadLine();

        //        if (input == "n")
        //        {
        //            return false;
        //        }

        //    } while (input?.ToLower() != "y");


        //    return true;
        //}
    }

    public static void ConsoleMiniGame()
    {
        Random random = new Random();
        Console.CursorVisible = false;
        bool shouldExit = false;

        // Terminal window size -----------------------------------------------

        int height = Console.WindowHeight - 1;
        int width = Console.WindowWidth - 5;

        // Player and food locations ------------------------------------------

        int playerX = 0;
        int playerY = 0;

        int foodX = 0;
        int foodY = 0;

        // State arrays -------------------------------------------------------

        string[] states = ["('-')", "(^-^)", "(X_X)"];
        string[] foods = ["@@@@@", "$$$$$", "#####"];

        // Current state ------------------------------------------------------

        string player = states[0];
        int food = 0;

        InitializeGame();
        while (!shouldExit)
        {
            if (TerminalResized())
            {
                Console.Clear();
                Console.WriteLine("Console was resized. Program exiting.");
                break;
            }

            if (EatFood())
            {
                ChangePlayer();
                ShowFood();

                if (HasState(1))
                {
                    Move(10);
                    Move(10);
                    Move(10);
                }

                if (HasState(2))
                {
                    FreezePlayer();
                }
            }
            else
            {
                Move();
            }
        }

        // Returns true if the Terminal was resized ---------------------------
        bool TerminalResized()
        {
            return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
        }

        // Displays random food at a random location --------------------------
        void ShowFood()
        {
            // Update food to a random index
            food = random.Next(0, foods.Length);

            // Update food position to a random location
            foodX = random.Next(0, width - player.Length);
            foodY = random.Next(0, height - 1);

            // Display the food at the location
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(foods[food]);
        }

        // Returns true if player has eaten food ------------------------------
        bool EatFood()
        {
            return playerX == foodX && playerY == foodY;
        }

        // Changes the player to match the food consumed ----------------------
        void ChangePlayer(bool restart = false)
        {
            // Update player state to initial state
            if (restart)
            {
                player = states[0];
            }
            else
            {
                player = states[food];
            }

            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        // Returns true if state matches player state -------------------------
        bool HasState(int state)
        {
            return player == states[state];
        }

        // Temporarily stops the player from moving ---------------------------
        void FreezePlayer()
        {
            Thread.Sleep(1000);
            ChangePlayer(true);
        }

        // Reads directional input from the Console and moves the player ------
        void Move(int speed = 1)
        {
            int lastX = playerX;
            int lastY = playerY;

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX -= speed;
                    break;
                case ConsoleKey.RightArrow:
                    playerX += speed;
                    break;
                case ConsoleKey.Escape:
                    shouldExit = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Non directional key pressed. Program exiting.");
                    shouldExit = true;
                    return;
            }

            // Clear the characters at the previous position
            Console.SetCursorPosition(lastX, lastY);
            for (int i = 0; i < player.Length; i++)
            {
                Console.Write(" ");
            }

            // Keep player position within the bounds of the Terminal window
            playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
            playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

            // Draw the player at the new location
            Console.SetCursorPosition(playerX, playerY);

            Console.Write(player);
        }

        // Clears the console, displays the food and player -------------------
        void InitializeGame()
        {
            Console.Clear();
            ShowFood();
            Console.SetCursorPosition(0, 0);
            Console.Write(player);
        }
    }

    public static void TryCatch()
    {
        Process1();
        Console.WriteLine("Exit program");

        void Process1()
        {
            try
            {
                HelloWorld();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message} Caught in {MethodBase.GetCurrentMethod()?.Name}");
            }
        }

        void HelloWorld()
        {
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;
            byte smallNumber;

            try
            {
                Console.WriteLine(float1 / float2);
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Exception: {e.Message} Caught in {MethodBase.GetCurrentMethod()?.Name}");
            }

            checked
            {
                try
                {
                    smallNumber = (byte)number1;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"Exception: {e.Message} Caught in {MethodBase.GetCurrentMethod()?.Name}");
                }
            }
        }
    }

    public static void SeparateExceptions()
    {
        // inputValues is used to store numeric values entered by a user
        string[] inputValues = new string[] { "three", "9999999999", "0", "2" };

        foreach (string inputValue in inputValues)
        {
            int numValue = 0;
            try
            {
                numValue = int.Parse(inputValue);
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{inputValue}' is not a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{inputValue}' is too large or too small.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void SpecificExceptions()
    {
        checked
        {
            try
            {
                int num1 = int.MaxValue;
                int num2 = int.MaxValue;
                int result = num1 + num2;
                Console.WriteLine("Result: " + result);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: The number is too large to be represented as an integer." + ex.Message);
            }
        }

        try
        {
            string str = null;
            int length = str.Length;
            Console.WriteLine("String Length: " + length);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Error: The reference is null." + ex.Message);
        }

        try
        {
            int[] numbers = new int[5];
            numbers[5] = 10;
            Console.WriteLine("Number at index 5: " + numbers[5]);
        }

        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Index out of range." + ex.Message);
        }

        try
        {
            int num3 = 10;
            int num4 = 0;
            int result2 = num3 / num4;
            Console.WriteLine("Result: " + result2);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero." + ex.Message);
        }

        Console.WriteLine("Exiting program.");
    }

    public static void ThrowExceptions()
    {
        try
        {
            OperatingProcedure1();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Exiting application.");
        }

        static void OperatingProcedure1()
        {
            string[][] userEnteredValues =
            [
                ["1", "two", "3"],
                ["0", "1", "2"]
            ];

            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    BusinessProcess1(userEntries);
                }
                catch (Exception ex)
                {
                    if (ex.StackTrace.Contains("BusinessProcess1"))
                    {
                        if (ex is FormatException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Corrective action taken in OperatingProcedure1");
                        }
                        else if (ex is DivideByZeroException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Partial correction in OperatingProcedure1 - further action required");

                            // re-throw the original exception
                            throw;
                        }
                        else
                        {
                            // create a new exception object that wraps the original exception
                            throw new ApplicationException("An error occurred - ", ex);
                        }
                    }
                }

            }
        }

        static void BusinessProcess1(string[] userEntries)
        {
            int valueEntered;

            foreach (string userValue in userEntries)
            {
                try
                {
                    valueEntered = int.Parse(userValue);

                    checked
                    {
                        int calculatedValue = 4 / valueEntered;
                    }
                }
                catch (FormatException)
                {
                    FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
                    throw invalidFormatException;
                }
                catch (DivideByZeroException)
                {
                    DivideByZeroException unexpectedDivideByZeroException = new DivideByZeroException("DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero");
                    throw unexpectedDivideByZeroException;

                }
            }
        }
    }

    public static void ExceptionMachine()
    {
        Dictionary<string, int> bounds = new Dictionary<string, int>()
        {
            { "lower", 0 },
            { "upper", 0 }
        };

        bool exit;

        // User input ---------------------------------------------------------

        foreach (var bound in bounds)
        {
            do
            {
                if (!bool.TryParse(ProcessUserInput(bound.Key), out exit))
                {
                    exit = false;
                }
            } while (!exit);

            exit = false;
        }

        decimal averageValue = 0;

        // Operation ----------------------------------------------------------

        do
        {
            try
            {
                averageValue = AverageOfEvenNumbers(bounds["lower"], bounds["upper"]);
                Console.WriteLine($"The average of even numbers between {bounds["lower"]} and {bounds["upper"]} is {averageValue}.");

                exit = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"ERROR => upper bound must be greater than lower bound.");
                Console.WriteLine();

                // New upper bound input --------------------------------------

                do
                {
                    if (!bool.TryParse(ProcessUserInput("upper", true), out exit))
                    {
                        return;
                    }
                } while (!exit);

                exit = false;
            }

        } while (!exit);

        string ProcessUserInput(string bound, bool newUpperBound = false)
        {
            try
            {
                string message = !newUpperBound ? $"Enter the {bound} bound: " : "Enter a new upper bound (or type 'exit' to exit): ";

                Console.Write(message);

                string? input = Console.ReadLine();

                if (input!.Contains("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return "exit";
                }
                else if (ValidateInput(input))
                {
                    bounds[bound] = int.Parse(input!);
                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"ERROR => {bound} bound can't be empty.\n");
                return "false";
            }
            catch (FormatException)
            {
                Console.WriteLine($"ERROR => {bound} bound must be an integer.\n");
                return "false";
            }

            return "true";
        }

        static bool ValidateInput(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException();
            }

            if (!int.TryParse(input, out int output))
            {
                throw new FormatException();
            }

            return true;
        }

        static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
        {
            if (lowerBound >= upperBound)
            {
                throw new ArgumentOutOfRangeException();
            }

            int sum = 0;
            int count = 0;
            decimal average = 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                    count++;
                }
            }

            average = (decimal)sum / count;

            return average;
        }
    }

    public static void ExceptionMachine2()
    {
        string[][] userEnteredValues =
        [
            ["1", "2", "3"],
            ["1", "two", "3"],
            ["0", "1", "2"]
        ];

        try
        {
            Workflow1(userEnteredValues);
            Console.WriteLine("'Workflow1' completed successfully.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("An error occurred during 'Workflow1'.");
            Console.WriteLine(ex.Message);
        }

        static void Workflow1(string[][] userEnteredValues)
        {
            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    Process1(userEntries);
                    Console.WriteLine("'Process1' completed successfully.");
                    Console.WriteLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("'Process1' encountered an issue, process aborted.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        static void Process1(string[] userEntries)
        {
            int valueEntered;

            foreach (string userValue in userEntries)
            {
                bool integerFormat = int.TryParse(userValue, out valueEntered);

                if (integerFormat)
                {
                    if (valueEntered != 0)
                    {
                        checked
                        {
                            int calculatedValue = 4 / valueEntered;
                        }
                    }
                    else
                    {
                        throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
                    }
                }
                else
                {
                    throw new FormatException("Invalid data. User input values must be valid integers.");
                }
            }
        }
    }

    public static void TransactionManager()
    {
        string? readResult = null;
        bool useTestData = false;

        Console.Clear();

        int[] cashTill = [0, 0, 0, 0];
        int registerCheckTillTotal = 0;

        // registerDailyStartingCash: $1 x 50, $5 x 20, $10 x 10, $20 x 5 => ($350 total)
        int[,] registerDailyStartingCash = new int[,] { { 1, 50 }, { 5, 20 }, { 10, 10 }, { 20, 5 } };

        int[] testData = [6, 10, 17, 20, 31, 36, 40, 41];
        int testCounter = 0;

        LoadTillEachMorning(registerDailyStartingCash, cashTill);

        for (int i = 0; i < registerDailyStartingCash.GetLength(0); i++)
        {
            registerCheckTillTotal += registerDailyStartingCash[i, 0] * registerDailyStartingCash[i, 1];
        }

        // display the number of bills of each denomination currently in the till
        LogTillStatus(cashTill);

        // display a message showing the amount of cash in the till
        Console.WriteLine(TillAmountSummary(cashTill));

        // display the expected registerDailyStartingCash total
        Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");
        Console.WriteLine();

        var valueGenerator = new Random((int)DateTime.Now.Ticks);

        int transactions = 100;

        if (useTestData)
        {
            transactions = testData.Length;
        }

        while (transactions > 0)
        {
            transactions -= 1;
            int itemCost = valueGenerator.Next(2, 50);

            if (useTestData)
            {
                itemCost = testData[testCounter];
                testCounter += 1;
            }

            int paymentOnes = itemCost % 2;                 // value is 1 when itemCost is odd, value is 0 when itemCost is even
            int paymentFives = (itemCost % 10 > 7) ? 1 : 0; // value is 1 when itemCost ends with 8 or 9, otherwise value is 0
            int paymentTens = (itemCost % 20 > 13) ? 1 : 0; // value is 1 when 13 < itemCost < 20 OR 33 < itemCost < 40, otherwise value is 0
            int paymentTwenties = (itemCost < 20) ? 1 : 2;  // value is 1 when itemCost < 20, otherwise value is 2
            int amountPaid = paymentTwenties * 20 + paymentTens * 10 + paymentFives * 5 + paymentOnes;
            int changeNeeded = amountPaid - itemCost;

            // display messages describing the current transaction
            Console.WriteLine($"Customer is making a ${itemCost} purchase");
            Console.WriteLine($"\t Using {paymentTwenties} twenty dollar bills");
            Console.WriteLine($"\t Using {paymentTens} ten dollar bills");
            Console.WriteLine($"\t Using {paymentFives} five dollar bills");
            Console.WriteLine($"\t Using {paymentOnes} one dollar bills");
            Console.WriteLine($"\t\tTotal paid: ${amountPaid} - ${itemCost} = ${changeNeeded}");

            try
            {
                // MakeChange manages the transaction and updates the till 
                MakeChange(itemCost, cashTill, paymentTwenties, paymentTens, paymentFives, paymentOnes, amountPaid, changeNeeded);

                Console.WriteLine($"Transaction successfully completed.");
                registerCheckTillTotal += itemCost;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR => {ex.Message}");
            }

            Console.WriteLine(TillAmountSummary(cashTill));
            Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");
            Console.WriteLine();
        }

        Console.WriteLine("Press the Enter key to exit");
        do
        {
            readResult = Console.ReadLine();

        } while (readResult == null);


        static void LoadTillEachMorning(int[,] registerDailyStartingCash, int[] cashTill)
        {
            cashTill[0] = registerDailyStartingCash[0, 1];
            cashTill[1] = registerDailyStartingCash[1, 1];
            cashTill[2] = registerDailyStartingCash[2, 1];
            cashTill[3] = registerDailyStartingCash[3, 1];
        }


        static void MakeChange(int cost, int[] cashTill, int twenties, int tens = 0, int fives = 0, int ones = 0, int amountPaid = 0, int changeNeeded = 0)
        {
            int tempTwenties = cashTill[3] + twenties;
            int tempTens = cashTill[2] + tens;
            int tempFives = cashTill[1] + fives;
            int tempOnes = cashTill[0] + ones;

            if (changeNeeded < 0)
            {
                throw new InvalidOperationException("Not enough money provided.");
            }

            Console.WriteLine("Cashier Returns:");

            while ((changeNeeded > 19) && (tempTwenties > 0))
            {
                tempTwenties--;
                changeNeeded -= 20;
                Console.WriteLine("\t A twenty");
            }

            while ((changeNeeded > 9) && (tempTens > 0))
            {
                tempTens--;
                changeNeeded -= 10;
                Console.WriteLine("\t A ten");
            }

            while ((changeNeeded > 4) && (tempFives > 0))
            {
                tempFives--;
                changeNeeded -= 5;
                Console.WriteLine("\t A five");
            }

            while ((changeNeeded > 0) && (tempOnes > 0))
            {
                tempOnes--;
                changeNeeded--;
                Console.WriteLine("\t A one");
            }

            if (changeNeeded > 0)
            {
                throw new InvalidOperationException("The till is unable to make change for the cash provided.");
            }

            cashTill[3] = tempTwenties;
            cashTill[2] = tempTens;
            cashTill[1] = tempFives;
            cashTill[0] = tempOnes;
        }

        static void LogTillStatus(int[] cashTill)
        {
            Console.WriteLine("The till currently has:");
            Console.WriteLine($"{cashTill[3] * 20} in twenties");
            Console.WriteLine($"{cashTill[2] * 10} in tens");
            Console.WriteLine($"{cashTill[1] * 5} in fives");
            Console.WriteLine($"{cashTill[0]} in ones");
            Console.WriteLine();
        }

        static string TillAmountSummary(int[] cashTill)
        {
            return $"The till has {cashTill[3] * 20 + cashTill[2] * 10 + cashTill[1] * 5 + cashTill[0]} dollars: {cashTill[3]} x $20 | {cashTill[2]} x $10 | {cashTill[1]} x $10 | {cashTill[0]} x $1";
        }
    }

    public static void ConditionalBreakpoints()
    {
        int productCount = 2000;
        string[,] products = new string[productCount, 2];

        LoadProducts(products, productCount);

        for (int i = 0; i < productCount; i++)
        {
            string result;
            result = Process1(products, i);

            if (result != "obsolete")
            {
                result = Process2(products, i);
            }
        }

        bool pauseCode = true;
        while (pauseCode == true) ;

        static void LoadProducts(string[,] products, int productCount)
        {
            Random rand = new Random();

            for (int i = 0; i < productCount; i++)
            {
                int num1 = rand.Next(1, 10000) + 10000;
                int num2 = rand.Next(1, 101);

                string prodID = num1.ToString();

                if (num2 < 91)
                {
                    products[i, 1] = "existing";
                }
                else if (num2 == 91)
                {
                    products[i, 1] = "new";
                    prodID = prodID + "-n";
                }
                else
                {
                    products[i, 1] = "obsolete";
                    prodID = prodID + "-0";
                }

                products[i, 0] = prodID;
            }
        }

        static string Process1(string[,] products, int item)
        {
            Console.WriteLine($"Process1 message - working on {products[item, 1]} product");

            return products[item, 1];
        }

        static string Process2(string[,] products, int item)
        {
            Console.WriteLine($"Process2 message - working on product ID #: {products[item, 0]}");
            if (products[item, 1] == "new")
                Process3(products, item);

            return "continue";
        }

        static void Process3(string[,] products, int item)
        {
            Console.WriteLine($"Process3 message - processing product information for 'new' product");
        }
    }

    public static void ManageState()
    {
        //int x = 5;

        //x = ChangeValue(x);

        //Console.WriteLine(x);

        //int ChangeValue(int value)
        //{
        //    return value = 10;
        //}
        //if (x == 5) {

        //}
        //else if (x == 10) {

        //}

        double x = 1.132;
        Console.WriteLine((int)x);
    }

    public static void Main()
    {
        //GetNumberOfTimesALetterAppearsInText("The quick brown fox jumps over the lazy dog.", 'o');
        //GetNumberOfTimesALetterAppearsInText("Hello World", 'l');
        //GetTheScopeOfAVariable();
        //ReadibilityIsKing();
        //ProblematicCode();
        //FlipACoin();

        //Console.WriteLine($"User permission\t\tUser level\t\tMessage\n");
        //for (int i = 0; i < 10; i++)
        //{
        //    Random permission = new Random();
        //    string permissionString = (permission.Next(0, 3) == 0 ? "Admin" : permission.Next(0, 3) == 1 ? "Manager" : "Other");

        //    Random level = new Random();

        //    User user = new User(permissionString, level.Next(0, 101));
        //    Console.Write($"{user.Permission}\t\t\t{user.Level}\t\t\t");
        //    GetAccess(user);
        //}

        //Console.WriteLine($"Employee name\t\tUser title\n");
        //for (int i = 0; i < 10; i++)
        //{
        //    Random level = new Random();
        //    string[] result = GetTitle(level.Next(0, 11));
        //    Console.WriteLine($"{result[0]}\t\t{result[1]}");
        //}

        //Console.WriteLine(string.Join(", ", IfElseIfIntoSwitch()));
        //FizzBuzz();
        //DoWhile();
        //While();
        //WhileContinue();
        //RolePlayingGame();
        //IntegerInput();
        //StringInput();
        //StringArray();
        //var instance = new Program();
        //instance.ContosoPets();
        //StringAndInt(["12.3", "45", "ABC", "11", "DEF"]);
        //NumberTypes();
        //SignedTypes();
        //UnsignedTypes();
        //FloatingTypes();
        //ReferenceTypes();
        //MyClass myClass = new MyClass();
        //RemoveEmptyElements();
        //ReverseString("abc123");
        //Pangram("The quick brown fox jumps over the lazy dog");
        //OrderIds("B123,C234,A345,C15,B177,G3003,C235,B179");
        //Formatting();
        //MagicValues();
        //Indexes2();
        //Remove();
        //Replace();
        //FormatStringData();
        //Contoso3();
        //PrintMessage("Hello world.");
        //ValueType();
        //ReferenceType();
        //StringType();
        //RSVP();
        //EmployeeEmails();
        //RefactorAMethod();

        //string[] mockInput = ["192..2.1", "19.1.2.1", "192.12.2.1", "hello.1.2.1", "192.1.test.1", "900.1.2.1", "192.1.2.1"];
        //foreach (string input in mockInput)
        //{
        //    IpAdressValidator(input);
        //}

        //TellFortune();
        //ReturnValues();
        //CoinsForChange();
        //DiceMiniGame();
        //List<(string, int)> schools = new List<(string, int)>()
        //{
        //    ("A", 2),
        //    ("B", 6),
        //    ("C", 5)
        //};

        //foreach (var school in schools)
        //{
        //    PettingZoo(school.Item1, school.Item2);
        //    Console.WriteLine();
        //}

        //ConsoleMiniGame();
        //TryCatch();
        //SeparateExceptions();
        //SpecificExceptions();
        //ThrowExceptions();
        //ExceptionMachine();
        //ExceptionMachine2();
        //TransactionManager();
        //ConditionalBreakpoints();
        ManageState();
    }
}
