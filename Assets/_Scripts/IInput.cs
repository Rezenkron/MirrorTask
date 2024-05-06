public interface IInput
{
    float Value { get; }
    float ReadInput(string axis);
}