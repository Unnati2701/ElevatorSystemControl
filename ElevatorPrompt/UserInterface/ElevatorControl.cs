using System.Collections.Immutable;

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

        public int RequestElevator(int currentFloor)
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
            return closestElevator.id;
        }

        public void Choice()
        {
            Boolean isflag = true;
            this.numOfFloors = _elevatorInput.GetNumOfFloors();

            while (isflag)
            {
                this.currentFloor = _elevatorInput.GetCurrentFloor();
                option = _elevatorInput.GetOption();
                int elevatorId = RequestElevator(currentFloor);

                switch (option)
                {
                    case 1:
                        nextFloor = _elevatorInput.GetNextFloor();
                        currentFloor = _driveControl.MoveUp(currentFloor, numOfFloors, nextFloor);
                        elevator[elevatorId - 1].elevator_Floor = nextFloor;
                        break;

                    case 2:
                        nextFloor = _elevatorInput.GetNextFloor();
                        currentFloor = _driveControl.MoveDown(currentFloor, numOfFloors, nextFloor);
                        elevator[elevatorId - 1].elevator_Floor = nextFloor;
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
