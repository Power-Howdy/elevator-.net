using NUnit.Framework;
using ControlService;

namespace ControlService.UnitTests;

public class Tests
{
    private ControlService _controlService;

    [SetUp]
    public void Setup()
    {
        _controlService = new ControlService();
    }

    [Test]
    public void CallElevator_ShouldAddFloorToRequestedFloors()
    {
        _controlService.CallElevator(5);

        Assert.Contains(5, _controlService.requestedFloors);
    }

    [Test]
    public void PressFloorButton_ShouldAddFloorToRequestedFloors()
    {
        _controlService.PressFloorButton(3);

        Assert.Contains(3, _controlService.requestedFloors);
    }

    [Test]
    public void MoveElevator_ShouldMoveElevatorToAllRequestedFloors()
    {
        _controlService.CallElevator(5);
        _controlService.PressFloorButton(3);
        _controlService.PressFloorButton(2);
        _controlService.CallElevator(1);

        var expectedFloors = new List<int> { 5, 3, 2, 1 };
        _controlService.MoveElevator();

        Assert.AreEqual(1, _controlService.currentFloor);
        Assert.IsEmpty(_controlService.requestedFloors);
    }

    [Test]
    public void DoorsOpen_ShouldSetDoorsOpenToTrue()
    {
        _controlService.DoorsOpen();

        Assert.IsTrue(_controlService.doorsOpen);
    }

    [Test]
    public void DoorsClose_ShouldSetDoorsOpenToFalse()
    {
        _controlService.DoorsOpen();
        _controlService.DoorsClose();

        Assert.IsFalse(_controlService.doorsOpen);
    }
}