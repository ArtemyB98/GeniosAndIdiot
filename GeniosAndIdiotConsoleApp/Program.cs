using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
namespace GeniosAndIdiotConsoleApp
{
    internal class Program
    {
        static List<string[]> GetQustionsAndAswers()
        {
            List<string[]> baseOfData = new List<string[]>();
            baseOfData.Add(new String[] { "Сколько будет два плюс два умноженное на два?", "6" });
            baseOfData.Add(new String[] { "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", "9" });
            baseOfData.Add(new String[] { "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "25" });
            baseOfData.Add(new String[] { "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", "60" });
            baseOfData.Add(new String[] { "Пять свечей горело, две потухли. Сколько свечей осталось?", "2" });
            return baseOfData;
        }

        static List<string> GetDiagnoses()
        {
            List<string> diagnoses = new List<string>()
            {
                "Идиот",
                "Кретин",
                "Дурак",
                "Нормальный",
                "Талантливый",
                "Гений"
            };
            return diagnoses;
        }

        static void DelayBase(object delayObject)
        {
            Delay delayDelay = delayObject as Delay;
            var delay = Task.Delay(delayDelay.DelayInt);
            if (delayDelay.IsClear == true)
            {
                Console.Clear();
            }
            for (int i = delayDelay.DelayInt / 1000; i >= 0; i--)
            {
                if (delayDelay.Timeout == false)
                {
                    
                    break;
                }
                Console.SetCursorPosition(delayDelay.ConsolePositionX, delayDelay.ConsolePositionY);
                Console.Write(delayDelay.Text + i + " \n");
                delay.Wait(delayDelay.WaitInt);
            }
            delayDelay.Timeout = false;

        }

        static void StartInformation(string name)
        {

            Console.Clear();
            Console.WriteLine($"Давайте приступим, {name}, к выполнению теста! \nВам будут заданы поочередно пять вопросов.\nНа каждый вопрос будет выделено 10 секунд. \nДля того чтобы начать нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            DelayBase(new Delay(5000, 1000, "Начинаем через: ", 0, 0, true));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, господин(жа) хороший(ая), как к Вам можно обращаться по имени?");
            string Name = Console.ReadLine();
            StartInformation(Name);

            List<string[]> questionsAndAnswers = GetQustionsAndAswers();
            List<string> diagnoses = GetDiagnoses();

            string answer = null;
            Random randomStart = new Random();
            int numberForRandomStartAsking;

            int countOfQuestions = 0;
            int countRightAnswers = 0;
            bool workProgramm = true;

            while (workProgramm == true)
            {
                while (countOfQuestions < 5)
                {
                    numberForRandomStartAsking = randomStart.Next(0, questionsAndAnswers.Count);
                    Console.Clear();
                    Console.WriteLine($"Вопрос №{countOfQuestions + 1}: \n{questionsAndAnswers[numberForRandomStartAsking][0]}");
                    Delay delayAfterQuestion = new Delay(10000, 1000, "Осталось времени: ", 0, 2, false);
                    ParameterizedThreadStart delayBase = new ParameterizedThreadStart(DelayBase);
                    Thread thread = new Thread(delayBase);
                    thread.Start(delayAfterQuestion);

                    answer = Console.ReadLine();
                    while (delayAfterQuestion.Timeout == true)
                    {
                        Console.SetCursorPosition(0, 3);
                        if (answer == null)
                        {
                            continue;
                        }
                        else if (answer != null)
                        {
                            if (answer == questionsAndAnswers[numberForRandomStartAsking][1])
                            {
                                countRightAnswers++;

                            }
                            delayAfterQuestion.Timeout = false;
                            break;
                        }
                    }


                    questionsAndAnswers.Remove(questionsAndAnswers[numberForRandomStartAsking]);
                    countOfQuestions++;
                    Console.Clear();
                }
                countOfQuestions = 0;
                while (true)
                {
                    Console.WriteLine($"Уважаемый(ая), {Name}, Ваш диагноз: {diagnoses[countRightAnswers]}\nХотите пройти тест ещё раз?\n1.Да\n2.Нет");
                    string repeatOrExit = Console.ReadLine();
                    if (repeatOrExit == "1")
                    {
                        questionsAndAnswers = GetQustionsAndAswers();
                        break;
                    }
                    else if (repeatOrExit == "2")
                    {
                        workProgramm = false;
                        Console.Clear();
                        Console.WriteLine("Заверешение программы");
                        break;
                        
                    }
                    Console.Clear();
                }
            }
        }
    }
}
