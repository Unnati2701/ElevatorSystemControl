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

            for (int i = 0; i < elevator.Length; i++)
            {
                elevator[i] = new Elevator { id = i + 1, elevator_Floor = 0 };
            }

            ElevatorControl obj = new ElevatorControl(elevatorInput, driveControl, displayMessages, elevator);
            obj.Choice();
            
        }
    }
}