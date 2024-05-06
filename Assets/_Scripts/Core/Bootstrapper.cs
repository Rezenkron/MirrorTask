using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    private IInputHandler _inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    void Update()
    {
        _inputHandler.Handle();
    }
}
