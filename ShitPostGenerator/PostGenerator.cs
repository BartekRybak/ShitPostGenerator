using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShitPostGenerator
{
    class PostGenerator
    {
        public static Post Generate(int title_lenght,int body_length, string title = "", string body = "")
        {
            Post post = new Post();
            Random rand = new Random();
            string[] words = File.ReadAllLines("random_words.txt");
            
            // Title
            if(title.Length <= 0)
            {
                for (int i = 0; i < title_lenght; i++)
                {
                    if (i == 0)
                    {
                        post.Title += wordToUpper(words[rand.Next(words.Length)]);
                    }
                    post.Title += " " + words[rand.Next(words.Length)];
                }
                post.Title += '.';
            }
            else
            {
                post.Title = title;
            }
            

           // Body
           if(body.Length <= 0)
           {
                for (int i = 0; i < body_length; i++)
                {
                    bool upNextWord = false;

                    if (i == 0)
                    {
                        upNextWord = true;
                        post.Body += wordToUpper(words[rand.Next(words.Length)]);
                    }
                    post.Body += " " + words[rand.Next(words.Length)];


                    foreach (int dot in randomDots(body_length, 5))
                    {
                        char[] inter = new char[] { '!', '?', ',', '.' };
                        if (dot == i)
                        {
                            post.Body += inter[rand.Next(inter.Length)];
                            upNextWord = true;
                        }
                    }

                    if (upNextWord)
                    {
                        post.Body += " " + wordToUpper(words[rand.Next(words.Length)]);
                    }
                    else
                    {
                        post.Body += " " + words[rand.Next(words.Length)];
                    }
                }
                post.Body += ".";
           }
           else
           {
                post.Body = body;
           }
           
            return post;
        }

        private static int[] randomDots(int textLenght,int minSpace)
        {
            Random rand = new Random();
            List<int> dotsIndex = new List<int>();
            int dotsCount = textLenght / minSpace;

            while(dotsIndex.Count < dotsCount)
            {
                int randDot = rand.Next(textLenght - minSpace);

                if(dotsIndex.Count == 0)
                {
                    dotsIndex.Add(randDot);
                }
                else
                {
                    if(!dotsIndex.Contains(randDot))
                    {
                        dotsIndex.Add(randDot);
                    }
                }
            }
            return dotsIndex.ToArray();
        }

        private static string wordToUpper(string word)
        {
            string w = string.Empty;
            for(int i=0;i<word.Length;i++)
            {
                if(i == 0)
                {
                    w += word[i].ToString().ToUpper();
                }
                else
                {
                    w += word[i];
                }
            }
            return w;
        }
    }
}
