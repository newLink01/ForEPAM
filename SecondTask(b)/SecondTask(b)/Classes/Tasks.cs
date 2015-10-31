using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;
using System.IO;
namespace SecondTask_b_.Classes
{
   public class Tasks
    {

       public Text processedText;
       

       public Tasks(string path) {
           this.processedText = new Parser(path).TextParse();
       }

     
       public void ShowConcordance()
       {
           List<string> markedValueWords = new List<string>();
           List<IWord> markedWords = new List<IWord>();
           IWord toAdd = new Word();

           #region
           for (int i = 0; i < processedText.text.Count; i++)
           {
               for (int j = 0; j < processedText[i].items.Count; j++)
               {


                   if (!markedValueWords.Contains(processedText[i].items[j].WordValue))
                   {
                       toAdd.WordValue = processedText[i].items[j].WordValue;
                       markedValueWords.Add(toAdd.WordValue);
                       markedWords.Add(toAdd);
                       toAdd = new Word();
                   }

                   foreach (var m in markedWords) {

                       if (m.WordValue == processedText[i].items[j].WordValue) {
                           m.Count++;
                           if (!m.LineIndexes.Contains(i)) { m.LineIndexes.Add(i); }
                       }
                   }
               }
           }

           #endregion

           foreach (var c in markedWords.OrderBy(x => x.WordValue))
           {
               Console.WriteLine(c.WordValue+new string('.',20-c.WordValue.Length)+c.Count+":" + c.GetLineIndexesAsString());
           }
       }






       public void ShowSecond(int linesInPage)
       {

        
           List<string> markedValueWords = new List<string>();
           List<IWord> markedWords = new List<IWord>();
           IWord toAdd = new Word();
           int currentPage = 0;
           //////////////////////////////////////
           for (int i = 0; i < processedText.text.Count; i++)
           {
               for (int j = 0; j < processedText[i].items.Count; j++)
               {


                   if (!markedValueWords.Contains(processedText[i].items[j].WordValue))
                   {
                       toAdd.WordValue = processedText[i].items[j].WordValue;
                       markedValueWords.Add(toAdd.WordValue);
                       toAdd.PageNumbers.Add(currentPage);
                       markedWords.Add(toAdd);
                       toAdd = new Word();
                   }

                   foreach (var m in markedWords)
                   {

                       if (m.WordValue == processedText[i].items[j].WordValue)
                       {
                           m.Count++;
                           if (!m.LineIndexes.Contains(i)) { m.LineIndexes.Add(i); }
                           if (!m.PageNumbers.Contains(currentPage)) { m.PageNumbers.Add(currentPage); }
                       }
                   }
               }
               if (i % linesInPage == 0) { currentPage++; }
           }
           ///////////////////////////////



           foreach()
       }










    }
}
