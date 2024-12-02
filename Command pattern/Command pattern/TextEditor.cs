using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_pattern
{
    public class TextEditor
    {
        private string _text = string.Empty;
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();
        public void InsertText(string text)
        {
            _text += text;
            Console.WriteLine($"Текущий текст: {_text}");
        }
        public string DeleteText(int length)
        {
            if (length > _text.Length) length = _text.Length;
            var deletedText = _text.Substring(_text.Length - length);
            _text = _text.Substring(0, _text.Length - length);
            Console.WriteLine($"Текущий текст: {_text}");
            return deletedText;
        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }
        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("Нет команд для отмены.");
            }
        }
    }
}
