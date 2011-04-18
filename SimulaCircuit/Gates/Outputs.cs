namespace SimulaCircuit.Gates
{
    public class True : InputsOutput
    {
        public override bool this[int i]
        {
            get { return true; }
        }
    }

    public class False : InputsOutput
    {
        public override bool this[int i]
        {
            get { return false; }
        }
    }
}
