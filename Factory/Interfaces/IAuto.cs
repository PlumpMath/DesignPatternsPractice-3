namespace Factory.Interfaces
{
    internal interface IAuto
    {
        string Name { get; set; }
        void TurnOn();
        void TurnOff();
    }
}