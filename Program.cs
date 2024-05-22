using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics_C_Sharp
{
    internal class Program
    {
        public static void Statistic(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string word = "";

            foreach (char c in text)
            {
                if (Char.IsLetter(c) || c == '-')
                {
                    word += c;
                }
                else if (!string.IsNullOrEmpty(word))
                {
                    string key = word;
                    if (wordCount.ContainsKey(key))
                    {
                        wordCount[key]++;
                    }
                    else
                    {
                        wordCount[key] = 1;
                    }
                    word = "";
                }
            }
            Console.WriteLine($"Текст:\n{text}\n");

            Console.WriteLine("Статистика\t\tСлово:\t\t\t\tКоличество:");
            int i = 1;
            int totalWords = 0;
            foreach (var pair in wordCount)
            {
                Console.WriteLine($"{i++}.\t\t\t{pair.Key}\t\t\t\t{pair.Value}");
                totalWords += pair.Value;
            }
            int uniqueWords = i - 1;
            Console.WriteLine($"Всего слов: {totalWords} из них уникальных: {uniqueWords}\n\n");

        }
        static void Main(string[] args)
        {
            string text1 = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, " +
                 "Который построил Джек.А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном " +
                 "чулане хранится В доме, Который построил Джек.";
            Statistic(text1);

            string text2 = "52 (Алло)\r\nДа здравствует Санкт-Петербург (А), и это город наш (YEEI)\r\nЯ каждый свой новый " +
                "куплет валю как никогда (YEEI, а)\r\nАльбом, он чисто мой, никому его не продам (Он мой)\r\nНе думаю о том" +
                " (YEEI), как хорошо было вчера (А-а; мне пох)";
            Statistic(text2);


            Console.ReadKey();
        }
    }
}
