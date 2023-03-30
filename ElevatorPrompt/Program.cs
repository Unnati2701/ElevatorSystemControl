namespace ConsoleApp2
{
    public class Program
    {
       
        public static void Main(String[] args)
        {
            ElevatorInput elevatorInput = new ElevatorInput();
            DisplayMessages displayMessages = new DisplayMessages();
            DriveControl driveControl = new DriveControl(elevatorInput, displayMessages);

            ElevatorControl obj = new ElevatorControl(elevatorInput, driveControl, displayMessages);
            obj.Choice();
            
        }
    }
}