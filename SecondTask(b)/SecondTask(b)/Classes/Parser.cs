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
       private string path;

       public Parser(string path) {
           textObject = new Text();
           sep = new Separators();
           this.path = path;
       }


       private Line LineParse(string str) {
           Line newLine = new Line();

               string[] containsWords = str.Split(sep.AllSeparators, StringSplitOptions.RemoveEmptyEntries);

               for (int i = 0; i < containsWords.Length; i++)
               {
                   newLine.Add(new Word(containsWords[i].ToLower()));
               }
               return newLine;
           
       }

     
       public Text TextParse() {

           using (reader = new StreamReader(this.path))
           {
               string str = null;

               while (true)
               {
                   str = reader.ReadLine();
                   if (str == null) { break; }
                   else
                   {
                       textObject.Add(LineParse(str));
                   }
               }
           }
           return textObject;
       }

      




    }
}
