using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SecondTask_b_.Interfaces;
namespace SecondTask_b_.Classes
{
   public class Parser
    {
       private StreamReader reader;
       private Text textObject;
       private Separators sep;

       public Parser(string path) {
           textObject = new Text();
           sep = new Separators();
           try
           {
               reader = new StreamReader(path);
           }
           catch (FileNotFoundException ex) {
               Console.Write(ex.Message);
           }
           textObject = new Text();
       }


       private Line LineParse(string str) {
           Line newLine = new Line();

               string[] containsWords = str.Split(sep.AllSeparators, StringSplitOptions.RemoveEmptyEntries);

               for (int i = 0; i < containsWords.Length; i++)
               {
                   newLine.items.Add(new Word(containsWords[i].ToLower()));
               }
               return newLine;
           
       }

     
       public Text TextParse() {

           string str = null;

           while (true)
           {
               str = reader.ReadLine();
               if (str == null/*String.IsNullOrWhiteSpace(str)*/) { break; }
               else
               {
                   textObject.text.Add(LineParse(str));
               }
           }

           return textObject;
       }

      




    }
}
