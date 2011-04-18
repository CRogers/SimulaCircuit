namespace SimulaCircuit.Gates
{
    public class Wire : IInputsOutput
    {
        public IOutput[] Inputs { get; set; }
        public bool this[int i]
        {
            get { return Inputs[0][0]; }
        }

        public ulong Id { get; private set; }

        public Wire(IOutput input)
        {
            Id = IdManager.Next(this);
            Inputs = new[] { input };
        }
    }
}
