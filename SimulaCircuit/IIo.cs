namespace SimulaCircuit
{
    public interface IOutput
    {
        bool this[int i] { get; }
        ulong Id { get; }
    }

    public interface IInputsOutput : IOutput
    {
        IOutput[] Inputs { get; set; }
    }
}
