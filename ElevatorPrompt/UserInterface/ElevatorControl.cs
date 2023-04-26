namespace ElevatorPrompt
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
        private Elevator[] elevator;

        public ElevatorControl(IElevatorInput elevatorInput, IDriveControl driveControl, IDisplayMessages displayMessages, Elevator[] elevator)
        {
            _elevatorInput = elevatorInput;
            _driveControl = driveControl;
            _displayMessages = displayMessages;

            this.elevator = elevator;
            
        }

        public void RequestElevator(int currentFloor)
        {
            Elevator closestElevator = null;
            int minDistance = int.MaxValue;

            for(int i = 0; i < elevator.Length; i++)
            {
                int distance = Math.Abs(elevator[i].elevator_Floor - currentFloor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestElevator = elevator[i];
                    elevator[i].elevator_Floor = currentFloor;
                }
            }

            closestElevator.elevator_Floor = currentFloor;
            Console.WriteLine("Elevator {0} is coming to floor {1}", closestElevator.id, currentFloor);
            
        }

        public void Choice()
        {
            Boolean isflag = true;
            this.numOfFloors = _elevatorInput.GetNumOfFloors();

            while (isflag)
            {
                this.currentFloor = _elevatorInput.GetCurrentFloor();
                option = _elevatorInput.GetOption();                

                switch (option)
                {
                    case 1:
                        nextFloor = _elevatorInput.GetNextFloor();
                        RequestElevator(currentFloor);
                        currentFloor = _driveControl.MoveUp(currentFloor, numOfFloors, nextFloor);
                        break;

                    case 2:
                        nextFloor = _elevatorInput.GetNextFloor();
                        RequestElevator(currentFloor);
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
