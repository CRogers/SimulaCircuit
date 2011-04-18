namespace SimulaCircuit
{
    public interface IOutput
    {
        bool this[int i] { get; }
        ulong Id { get; }
    }
}
