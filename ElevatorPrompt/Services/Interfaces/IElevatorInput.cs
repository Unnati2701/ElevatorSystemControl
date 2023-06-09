﻿namespace ElevatorPrompt
{
    public interface IElevatorInput
    {
        string GetContinueChoice();
        int GetCurrentFloor();
        int GetNextFloor();
        int GetNumOfFloors();
        int GetOption();
        int PromptToMoveDown();
        int PromptToMoveUp();
    }
}