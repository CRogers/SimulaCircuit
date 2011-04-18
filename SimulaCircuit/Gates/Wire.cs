namespace SimulaCircuit.Gates
{
    public class Wire : InputsOutput
    {
        public override bool this[int i]
        {
            get { return Inputs[0][0]; }
        }

        public Wire(IInputsOutput input)
        {
            Inputs = new[] { input };
        }
    }
}
