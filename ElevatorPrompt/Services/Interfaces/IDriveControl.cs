namespace ElevatorPrompt
{
    public interface IDriveControl
    {
        int MoveDown(int currentFloor, int numOfFloors, int nextFloor);
        int MoveUp(int currentFloor, int numOfFloors, int nextFloor);
    }
}