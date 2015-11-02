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
       private string[] sep;
       
       private string path;

       public Parser(string path) {

           try
           {
               reader = new StreamReader(path);
           }
           catch (Exception ex)
           {
               Console.Write(ex.Message);
               reader = null;
           }
           
           
           textObject = new Text();
           sep = new Separators().GetAllSeparators().ToArray();
           this.path = path;
       }


       private ILine LineParse(string str) {
           ILine newLine = new Line();

               string[] containsWords = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);

               for (int i = 0; i < containsWords.Length; i++)
               {
                   newLine.items.Add(new Word(containsWords[i].ToLower()));
               }
               return newLine;
           
       }

     
       public Text TextParse() {
           if (reader != null)
           {
               using (reader)
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
           }
           return textObject;
       }

      




    }
}
