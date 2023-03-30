namespace ConsoleApp2
{
    public class ElevatorControl
    {
        int option;
        int nextFloor;
        int numOfFloors;
        int currentFloor;

        private IElevatorInput _elevatorInput;
        private IDriveControl _driveControl;
        private IDisplayMessages _displayMessages;

        public ElevatorControl(IElevatorInput elevatorInput, IDriveControl driveControl, IDisplayMessages displayMessages)
        {
            _elevatorInput = elevatorInput;
            _driveControl = driveControl;
            _displayMessages = displayMessages;
        }

        public void Choice()
        {
            Boolean isflag = true;
            this.numOfFloors = _elevatorInput.GetNumOfFloors();
            this.currentFloor = _elevatorInput.GetCurrentFloor();

            while (isflag)
            {
                option = _elevatorInput.GetOption();

                switch (option)
                {
                    case 1:
                        nextFloor = _elevatorInput.GetNextFloor();

                        currentFloor = _driveControl.MoveUp(currentFloor, numOfFloors, nextFloor);
                        break;

                    case 2:
                        nextFloor = _elevatorInput.GetNextFloor();

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
