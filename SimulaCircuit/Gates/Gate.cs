namespace SimulaCircuit.Gates
{
    public abstract class Gate
    {
        public bool[] Inputs { get; set; }

        public bool Output 
        {
            get { return Func(); }
        }

        protected abstract bool Func();
    }

    public abstract class Gate1 : Gate
    {
        protected Gate1()
        {
            Inputs = new bool[1];
        }
    }
}
