using System;
namespace Quest
{
    public class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer name)
        {
            if (name.Awesomeness > 0)
            {
                for (int i = 0; i < name.Awesomeness; i++)
                Console.WriteLine(_text);
            }
            else 
            {
                Console.WriteLine("You're a disgusting corpse. Even the maggots avoid you.");
            }
        }
    }
}