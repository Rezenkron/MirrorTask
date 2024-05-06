using UnityEngine;
using Zenject;

public class InputHandler : IInputHandler
{
    const string HORIZONTAL_AXIS = "Horizontal";

    private IInput _horizontal;

    public InputHandler([Inject(Id = InjectDataID.Horizontal)]IInput horizontal)
    {
        _horizontal = horizontal;
    }

    public void Handle()
    {
        _horizontal.ReadInput(HORIZONTAL_AXIS);
    }
}
