using Command_pattern;
public interface ICommand
{
    void Execute();
    void Undo();
}

class Program
{
    static void Main(string[] args)
    {
        var editor = new TextEditor();

        // Ввод текста
        var insertHello = new InsertTextCommand(editor, "Hello");
        editor.ExecuteCommand(insertHello);

        var insertWorld = new InsertTextCommand(editor, " World");
        editor.ExecuteCommand(insertWorld);

        // Удаление текста
        var deleteWorld = new DeleteTextCommand(editor, 6); // Удаляем " World"
        editor.ExecuteCommand(deleteWorld);

        editor.Undo(); // Восстанавливаем " World"

        editor.Undo(); // Восстанавливаем "Hello World"

        editor.Undo(); // Восстанавливаем пустую строку

        editor.Undo(); // Нет команд для отмены.
    }
}
