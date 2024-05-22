Единственное примечание: если выводит ошибку: MSBuild MSB8020 из-за того, что используется версия сборки v143 (Visual Studio 2022), поменяйте версию до v142 (Visual Studio 2019) по этим действиям: ПРОЕКТ -> Свойства: ... -> Набор инструментов платформы -> Visual Studio 2019 (v142)

Разбор главной функции Statistic(string text):
//Текст для примера 
string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек.А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

//Создание коллекции (wordCount), содержащей в качестве ключа (TKey) слова, а значением (TValue) - кол-во данных слов
Dictionary<string, int> wordCount = new Dictionary<string, int>();

//Пустая строка (word), для поиска и сборки слов
string word = "";

//Цикл (foreach) по поиску слов в тексте (text), и добавления их в коллекцию (wordCount)
foreach (char c in text)
{
  //Условие, которое собирает слово (word) из букв Юникода и '-'
  if (Char.IsLetter(c) || c == '-')
  {
    word += c;
  }
  //Если 1 условие вернуло False, то дальше, если слово (word) сформировано (т.е. не равно ничему (word != "") или вовсе существует (word != null)) оно добавляется в коллекцию (wordCount)
  else if (!string.IsNullOrEmpty(word))
  {
    //Создание переменной-ключа (key) хранящее в себе значение word
    string key = word;

    //Если ключ (key) уже есть в коллекции то кол-во (TValue) увеличивается на 1 
    if (wordCount.ContainsKey(key))
    {
      wordCount[key]++;
    }

    //Если нет - то создание нового ключа (TKey) в коллекции (wordCount), с количеством таких значений - 1 (TValue = 1)
    else
    {
      wordCount[key] = 1;
    }

    //Обнуление значения word
    word = "";
  }
}

//Вывод Статистики на экран
Console.WriteLine("Статистика\t\tСлово:\t\t\t\tКоличество:");
int i = 1;
int totalWords = 0;
foreach (var pair in wordCount)
{
  Console.WriteLine($"{i++}.\t\t\t{pair.Key}\t\t\t\t{pair.Value}");
  totalWords += pair.Value;
}
int uniqueWords = i - 1;
Console.WriteLine($"Всего слов: {totalWords} из них уникальных: {uniqueWords}");
