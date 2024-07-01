using System;

namespace ControlService;

public class ControlService
{
        public int currentFloor = 1;
        public bool isMoving = false;
        public bool doorsOpen = false;
        public List<int> requestedFloors = new List<int>();

        public void CallElevator(int floor)
        {
            requestedFloors.Add(floor);
            MoveElevator();
        }

        public void PressFloorButton(int floor)
        {
            requestedFloors.Add(floor);
            MoveElevator();
        }

        public void MoveElevator()
        {
            if (!isMoving)
            {
                isMoving = true;
                DoorsClose();

                while (requestedFloors.Count > 0)
                {
                    int nextFloor = requestedFloors[0];
                    requestedFloors.RemoveAt(0);

                    Console.WriteLine($"Elevator moving from floor {currentFloor} to floor {nextFloor}.");
                    currentFloor = nextFloor;

                    DoorsOpen();
                    Console.WriteLine($"Elevator stopped at floor {currentFloor}.");
                    DoorsClose();
                }

                isMoving = false;
            }
        }

        public void DoorsOpen()
        {
            doorsOpen = true;
            Console.WriteLine("Elevator doors open.");
        }

        public void DoorsClose()
        {
            doorsOpen = false;
            Console.WriteLine("Elevator doors close.");
        }
}