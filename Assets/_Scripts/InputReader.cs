using UnityEngine;

public class InputReader : IInput
{
    public float Value { get; private set; } = 0;
    public float ReadInput(string axis)
    {
        return Value = Input.GetAxisRaw(axis);
    }
}
