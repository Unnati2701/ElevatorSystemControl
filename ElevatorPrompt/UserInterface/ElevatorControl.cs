namespace ElevatorPrompt
{
    public class ElevatorControl : IElevatorControl
    {
        private IElevatorControl _elevator1Control;
        private IElevatorControl _elevator2Control;

        public ElevatorControl(IElevatorControl elevator1Control, IElevatorControl elevator2Control)
        {
            _elevator1Control = elevator1Control;
            _elevator2Control = elevator2Control;
        }

        public void AssignElevator(int nextFloor)
        {

            _elevator1Control.AssignElevator(nextFloor);
            _elevator2Control.AssignElevator(nextFloor);
        }

        public void Choice()
        {
            _elevator1Control.Choice();
            _elevator2Control.Choice();
        }






        /*public void Run()
        {
            Boolean isflag = true;
            Console.WriteLine("Welcome to Elevator Control System!");

            while (isflag)
            {
                Console.WriteLine("Which elevator would you like to use?");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _elevator1Control.Choice();
                        break;

                    case "2":
                        _elevator2Control.Choice();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please choose 1 or 2.");
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
    }*/
    }
}

        

