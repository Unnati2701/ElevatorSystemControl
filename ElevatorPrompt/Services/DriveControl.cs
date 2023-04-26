namespace ElevatorPrompt
{
    public class DriveControl : IDriveControl
    {
        private IElevatorInput _elevatorInput;
        private IDisplayMessages _displayMessage;

        public DriveControl(IElevatorInput elevatorInput, IDisplayMessages displayMessage)
        {
            _elevatorInput = elevatorInput;
            _displayMessage = displayMessage;
        }

        public int MoveUp(int currentFloor, int numOfFloors, int nextFloor)
        {
            try
            {
                if (nextFloor <= numOfFloors)
                {
                    int floorsToMove = nextFloor - currentFloor;
                    currentFloor += floorsToMove;

                    _displayMessage.DisplayWelcomeMessage(currentFloor);
                }
                else if (nextFloor > numOfFloors)
                {
                    _displayMessage.DisplayFloorNotExistMessage();
                }
                else
                {
                    nextFloor = _elevatorInput.PromptToMoveUp();

                    return MoveUp(currentFloor, numOfFloors, nextFloor);
                }
            }
            catch (Exception ex)
            {
                _displayMessage.DisplayErrorMessage(ex);
            }
            return currentFloor;
        }

        public int MoveDown(int currentFloor, int numOfFloors, int nextFloor)
        {
            try
            {
                if (currentFloor > 0 && nextFloor < currentFloor)
                {
                    int floorsToMove = currentFloor - nextFloor;
                    currentFloor -= floorsToMove;

                    _displayMessage.DisplayWelcomeMessage(currentFloor);
                }
                else if (nextFloor > currentFloor)
                {
                    nextFloor = _elevatorInput.PromptToMoveDown();

                    return MoveDown(currentFloor, numOfFloors, nextFloor);
                }
                else
                {
                    _displayMessage.DisplayFloorNotExistMessage();
                }
            }
            catch (Exception ex)
            {
                _displayMessage.DisplayErrorMessage(ex);
            }
            return currentFloor;
        }
    }
}




