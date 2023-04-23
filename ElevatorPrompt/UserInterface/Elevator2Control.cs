namespace ElevatorPrompt
{
    public class Elevator2Control : IElevatorControl
    {
        private int numOfFloors;
        private int currentFloor;

        private IElevatorInput _elevatorInput;
        private IDriveControl _driveControl;
        private IDisplayMessages _displayMessages;

        public Elevator2Control(IElevatorInput elevatorInput, IDriveControl driveControl, IDisplayMessages displayMessages)
        {
            _elevatorInput = elevatorInput;
            _driveControl = driveControl;
            _displayMessages = displayMessages;
        }

        public void AssignElevator(int nextFloor)
        {
            Console.WriteLine("Elevator 2 is assigned to floor {0}", nextFloor);
        }

        public void Choice()
        {
            Boolean isflag = true;
            this.numOfFloors = _elevatorInput.GetNumOfFloors();
            this.currentFloor = _elevatorInput.GetCurrentFloor();

            while (isflag)
            {
                int option = _elevatorInput.GetOption();
                int nextFloor = _elevatorInput.GetNextFloor();

                switch (option)
                {
                    case 1:
                        AssignElevator(nextFloor);
                        currentFloor = _driveControl.MoveUp(currentFloor, numOfFloors, nextFloor);
                        break;
                
                   case 2:
                        AssignElevator(nextFloor);
                        currentFloor = _driveControl.MoveDown(currentFloor, numOfFloors, nextFloor);
                        break;

                    default:
                        _displayMessages.DisplayInvalidChoiceMessage();
                         break;
                }

                var ch = _elevatorInput.GetContinueChoice();

                while (ch != "N" && ch != "Y")
                {
                    ch = _elevatorInput.GetContinueChoice();
                }

                if (ch == "N")
                {
                    isflag = false;
                }
            }
        }
    }
}

