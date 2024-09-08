public class Delay 
{
    public int DelayInt { get; set; }
    public int WaitInt { get; set; }
    public string Text { get; set; }
    public int ConsolePositionX { get; set; }
    public int ConsolePositionY { get; set; }
    public bool IsClear { get; set; }
    public bool Timeout = true;
    public Delay(int delayInt, int waitInt, string text, int conoslePositionX, int consolePositionY, bool isClear)
    {
        DelayInt = delayInt;
        WaitInt = waitInt;
        Text = text;
        ConsolePositionX = conoslePositionX;
        ConsolePositionY = consolePositionY;
        IsClear = isClear;
    }
}
