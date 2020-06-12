// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

namespace BigTask2.Ui
{
    class XMLFactory : IFactory
    {
        public ISystem GetSystem()
        {
            return new XMLSystem();
        }

        public IDisplay GetDisplay()
        {
            return new XMLDisplay();
        }

        public IForm GetForm()
        {
            return new XMLForm();
        }
    }
    class KeyValueFactory : IFactory
    {
        public ISystem GetSystem()
        {
            return new KeyValueSystem();
        }

        public IDisplay GetDisplay()
        {
            return new KeyValueDisplay();
        }

        public IForm GetForm()
        {
            return new KeyValueForm();
        }
    }
}