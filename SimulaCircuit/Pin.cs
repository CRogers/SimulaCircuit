namespace SimulaCircuit
{
    public struct Pin
    {
        public ulong Id { get; set; }
        public int PinNumber { get; set; }

        public bool Value
        {
            get { return IdManager.Items[Id][PinNumber]; }
        }

        public Pin(ulong id, int pinNumber) : this()
        {
            Id = id;
            PinNumber = pinNumber;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Pin : {1}, Value: {2}", Id, PinNumber, Value);
        }
    }
}
