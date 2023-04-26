namespace ElevatorPrompt
{
    public class Program
    {
       
        public static void Main(String[] args)
        {
            ElevatorInput elevatorInput = new ElevatorInput();
            DisplayMessages displayMessages = new DisplayMessages();
            DriveControl driveControl = new DriveControl(elevatorInput, displayMessages);
            Elevator[] elevator = new Elevator[2];

            ElevatorControl obj = new ElevatorControl(elevatorInput, driveControl, displayMessages, elevator);
            obj.Choice();
            
        }
    }
}