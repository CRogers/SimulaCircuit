namespace SimulaCircuit.Gates
{
    public class Wire : InputsOutput
    {
        public override string Name { get { return "WIRE"; } }
        public override bool this[int i]
        {
            get { return Inputs[0].Value; }
        }

        public Wire(Pin input) : base(1,1)
        {
            Inputs = new[] { input };
        }
    }
}
