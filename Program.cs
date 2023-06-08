using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SkillFactoru_13_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new HttpClient().GetStringAsync(@"https://lms-cdn.skillfactory.ru/assets/courseware/v1/dc9cf029ae4d0ae3ab9e490ef767588f/asset-v1:SkillFactory+CDEV+2021+type@asset+block/Text1.txt").Result;

            string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            string[] splitted = noPunctuationText.Split(new char[] { ' ', '\n' });

            List<string> list = splitted.Cast<string>().ToList();

            list = list.Where(x => x != "").ToList();

            var grouppedWords = list.GroupBy(x => x).OrderByDescending(x => x.Count());

            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(grouppedWords.ElementAt(i).Key);
            }
            Console.ReadKey();
        }
    }
}
