namespace SimulaCircuit.Gates
{
    public class Wire : IOutput
    {
        public IOutput Input { get; set; }
        public bool this[int i]
        {
            get { return Input[0]; }
        }

        public ulong Id { get; private set; }

        public Wire(IOutput input)
        {
            Id = IdManager.Next();
            Input = input;
        }
    }
}
