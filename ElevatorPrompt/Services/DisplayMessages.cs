namespace ConsoleApp2
{
    public class DisplayMessages : IDisplayMessages
    {
        public void DisplayErrorMessage(Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        public void DisplayFloorNotExistMessage()
        {
            Console.WriteLine("Sorry, the floor does not exist.");
        }

        public void DisplayWelcomeMessage(int currentFloor)
        {
            Console.WriteLine("Welcome to floor {0}", currentFloor);
        }

        public void DisplayInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
}
