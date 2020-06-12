// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

namespace BigTask2.Ui
{
    class XMLSystem : ISystem
    {
        public IForm Form { get; set; }

        public IDisplay Display { get; set; }
    }

    class KeyValueSystem : ISystem
    {
        public IForm Form { get; set; }

        public IDisplay Display { get; set; }
    }
}