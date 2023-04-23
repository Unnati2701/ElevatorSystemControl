namespace ElevatorPrompt
{
    public class Program
    {
        public static void Main(String[] args)
        {
            IElevatorInput elevatorInput = new ElevatorInput();
            IDisplayMessages displayMessages = new DisplayMessages();
            IDriveControl driveControl = new DriveControl(elevatorInput, displayMessages);


            Elevator1Control elevator1Control = new Elevator1Control(elevatorInput, driveControl, displayMessages);
            Elevator2Control elevator2Control = new Elevator2Control(elevatorInput, driveControl, displayMessages);

            IElevatorControl elevatorControl = new ElevatorControl(elevator1Control, elevator2Control);

            elevatorControl.Choice();
        }
    }
}