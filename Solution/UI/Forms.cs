// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Api;
using System;
using System.Collections.Generic;

namespace BigTask2.Ui
{
    class XMLForm : IForm
    {
        Dictionary<string, string> Values;

        public XMLForm()
        {
            Values = new Dictionary<string, string>();
        }

        public bool GetBoolValue(string name)
        {
            if (Values[name] == "True")
                return true;
            else
                return false;
        }

        public int GetNumericValue(string name)
        {
            return Int32.Parse(Values[name]);
        }

        public string GetTextValue(string name)
        {
            return Values[name];

        }

        public void Insert(string command)
        {
            string key = "";
            foreach (var letter in command.Substring(1))
            {
                if (letter == '>')
                    break;
                key += letter;
            }
            string value = "";
            foreach (var letter in command.Substring(key.Length + 2))
            {
                if (letter == '<')
                    break;
                value += letter;
            }
            if (Values.ContainsKey(key))
                Values[key] = value;
            else
                Values.Add(key, value);
        }
    }

    class KeyValueForm : IForm
    {
        Dictionary<string, string> Values;

        public KeyValueForm()
        {
            Values = new Dictionary<string, string>();
        }

        public bool GetBoolValue(string name)
        {
            if (Values[name] == "True")
                return true;
            else
                return false;
        }

        public int GetNumericValue(string name)
        {
            return Int32.Parse(Values[name]);
        }

        public string GetTextValue(string name)
        {
            return Values[name];

        }

        public void Insert(string command)
        {
            string key = "";
            foreach (var letter in command)
            {
                if (letter == '=')
                    break;
                key += letter;
            }
            string value = "";
            foreach (var letter in command.Substring(key.Length + 1))
            {
                value += letter;
            }
            if (Values.ContainsKey(key))
                Values[key] = value;
            else
                Values.Add(key, value);
        }
    }
}