Console.WriteLine("Welcome to Knight vs Goblin!");
Console.WriteLine("----------------------------");
Console.Write("Enter knight health: ");
string input = Console.ReadLine();

Random randomNumberGenerator = new Random();

int knightHealth;

if (int.TryParse(input, out knightHealth))
{
    if (knightHealth <= 0 || knightHealth > 100)
    {
        Console.WriteLine("Invalid number, default value 100 is used.");
        knightHealth = 100;
    }
}
else
{
    Console.WriteLine("Invalid number, default value 100 is used.");
    knightHealth = 100;
}

int goblinHealth = randomNumberGenerator.Next(1, 101);

if (knightHealth <= 0)
{
    Console.WriteLine("You have died!");
}
else
{
    Console.WriteLine($"Knight health: {knightHealth}");
}

if (goblinHealth <= 0)
{
    Console.WriteLine("The goblin has died!");
}
else
{
    Console.WriteLine($"Goblin health: {goblinHealth}");
}
Console.WriteLine();

int move;
int knightAttack = 10;
int goblinAttack;
int round = 0;

while (knightHealth > 0 && goblinHealth > 0)
{
    round++;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Round {round}.");
    Console.ResetColor();
    goblinAttack = randomNumberGenerator.Next(5, 16);

    Console.WriteLine("Choose an action:\n1. Attack\n2. Heal");

    while (!int.TryParse(Console.ReadLine(), out move))
    {
        Console.WriteLine("Please enter an action.\n1. Attack\n2. Heal");
    }
    switch (move)
    {
        case 1:
            goblinHealth -= knightAttack;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Goblin was attacked and lost {knightAttack} health!");
            Console.ResetColor();
            if (goblinHealth < 0)
            {
                goblinHealth = 0;
            }
            Console.WriteLine($"Score:\nKnight: {knightHealth} health\nGoblin: {goblinHealth} health");
            Console.WriteLine();
            break;
        case 2:
            knightHealth += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Knight healed and gained 10 health!");
            Console.ResetColor();
            Console.WriteLine($"Score:\nKnight: {knightHealth} health\nGoblin: {goblinHealth} health");
            Console.WriteLine();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Invalid input for knight action");
            Console.ResetColor();
            break;
    }
    if (goblinHealth > 0)
    {
        knightHealth -= goblinAttack;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Knight was attacked and lost {goblinAttack} health!");
        Console.ResetColor();
        if (knightHealth < 0)
        {
            knightHealth = 0;
        }
        Console.WriteLine($"Score:\nKnight: {knightHealth} health\nGoblin: {goblinHealth} health");
        Console.WriteLine();
    }
}
if (goblinHealth <= 0)
{
    Console.WriteLine("Game over. Knight wins.");
}
else if (knightHealth <= 0)
{
    Console.WriteLine("Game over. Goblin wins.");
}
