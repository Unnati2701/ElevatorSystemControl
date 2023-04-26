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
            elevator[0] = new Elevator { id = 1, elevator_Floor = 0 };
            elevator[1] = new Elevator { id = 2, elevator_Floor = 0 };
        }

        public void RequestElevator(int currentFloor)
        {
            Elevator closestElevator = null;
            int minDistance = int.MaxValue;

            foreach(Elevator e in elevator)
            {
                int distance = Math.Abs(e.elevator_Floor - currentFloor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestElevator = e;
                }
            }

            Console.WriteLine("Elevator {0} is coming to floor {1}", closestElevator.id, currentFloor);
            closestElevator.elevator_Floor = currentFloor;
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
