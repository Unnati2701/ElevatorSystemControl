namespace ElevatorPrompt
{
    public class ElevatorInput : IElevatorInput
    {
        public int GetNumOfFloors()
        {
            Console.WriteLine("How many floors are there in the building?");
            return int.Parse(Console.ReadLine());
        }

        public int GetCurrentFloor()
        {
            int currentFloor = 0;

            Console.WriteLine("Which floor are you on?");
            return int.Parse(Console.ReadLine());
        }

        public int GetNextFloor()
        {
            Console.WriteLine("Enter the floor you want to go to.");
            return int.Parse(Console.ReadLine());
        }

        public int GetOption()
        {
            Console.WriteLine("Where do you want to go?");

            Console.WriteLine("1. Up \n2. Down");
            return int.Parse(Console.ReadLine());
        }

        public string GetContinueChoice()
        {
            Console.WriteLine("Do you want to continue?");
            Console.WriteLine("1. Y \n2. N");
            return Console.ReadLine()?.ToUpper();

        }

        public int PromptToMoveUp()
        {
            Console.WriteLine("Please enter the floor to move up.");
            return int.Parse(Console.ReadLine());
        }

        public int PromptToMoveDown()
        {
            Console.WriteLine("Please enter the floor to move down.");
            return int.Parse(Console.ReadLine());
        }

    }
}
