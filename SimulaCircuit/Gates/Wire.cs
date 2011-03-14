namespace SimulaCircuit.Gates
{
    public class Wire : IOutput
    {
        public IOutput Input { get; set; }
        public bool Output
        {
            get { return Input.Output; }
        }

        public Wire(IOutput input)
        {
            Input = input;
        }
    }
}
