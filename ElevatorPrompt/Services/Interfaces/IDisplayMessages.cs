namespace ConsoleApp2
{
    public interface IDisplayMessages
    {
        void DisplayErrorMessage(Exception ex);
        void DisplayFloorNotExistMessage();
        void DisplayInvalidChoiceMessage();
        void DisplayWelcomeMessage(int currentFloor);
    }
}