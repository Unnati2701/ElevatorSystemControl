using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorPrompt
{
    public interface IElevator
    {
        int CurrentFloor { get; }
        void MoveUp(int floor);
        void MoveDown(int floor);
        bool IsIdle();

    }
}
