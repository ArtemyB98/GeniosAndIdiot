using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        static void Delay (int delayInt,int waitInt, string text, int conoslePositionX, int consolePositionY, bool isClear)
        {
            var delay = Task.Delay(delayInt);
            if (isClear == true)
            {
                Console.Clear();
            }
            for (int i = 5; i >= 0; i--)
            {
                Console.SetCursorPosition(conoslePositionX, consolePositionY);
                Console.Write(text + i +" ");
                delay.Wait(waitInt);
            }
            Console.Clear();
        }

        static void startInformation (string name)
        {
            
            Console.Clear();
            Console.WriteLine($"Давайте приступим, {name}, к выполнению теста! \nВам будут заданы поочередно пять вопросов.\nНа каждый вопрос будет выделено 10 секунд. \nДля того чтобы начать нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            Delay(5000, 1000, "Начинаем через: ", 0,0,true);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, господин(жа) хороший(ая), как к Вам можно обращаться по имени?");
            string Name = Console.ReadLine();
            startInformation(Name);

            List<string[]> questionsAndAnswers = GetQustionsAndAswers();
            List<string> diagnoses = GetDiagnoses();
            
            string answer;
            Random randomStart = new Random();
            int numberForRandomStartAsking;
            
            int countOfQuestions = 0;
            int countRightAnswers = 0;
            

            while (countOfQuestions < 5)
            {
                numberForRandomStartAsking = randomStart.Next(0, questionsAndAnswers.Count);
                Console.WriteLine($"Вопрос №{countOfQuestions + 1}: \n{questionsAndAnswers[numberForRandomStartAsking][0]}");
                Delay(10000, 1000, "Осталось времени на вопрос: ", 0, 3,false);
                answer = Console.ReadLine();
                if (answer == questionsAndAnswers[numberForRandomStartAsking][1])
                {
                    countRightAnswers++;
                }
                questionsAndAnswers.Remove(questionsAndAnswers[numberForRandomStartAsking]);
                countOfQuestions++;
            }
            Console.WriteLine($"Уважаемый(ая), {Name}, Ваш диагноз: {diagnoses[countRightAnswers]}");
        }
    }
}
