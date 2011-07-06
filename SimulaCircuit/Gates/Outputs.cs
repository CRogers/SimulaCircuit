namespace SimulaCircuit.Gates
{
    public class True : InputsOutput
    {
        protected override void InitId() { }

        public override int Id
        {
            get { return 1; }
        }

        public override bool this[int i]
        {
            get { return true; }
        }
    }

    public class False : InputsOutput
    {
        protected override void InitId(){}

        public override int Id
        {
            get { return 0; }
        }

        public override bool this[int i]
        {
            get { return false; }
        }
    }
}
