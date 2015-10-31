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

       private Text processedText;
       
       public Tasks(string path) {
           this.processedText = new Parser(path).TextParse();
       }
       public void ShowFirstConcordance()
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
       public void ShowSecondConcordance(int linesInPage)
       {
           if (linesInPage <= 0) { return; }
        
           List<string> markedValueWords = new List<string>();
           List<IWord> markedWords = new List<IWord>();
           IWord toAdd = new Word();
           int currentPage = 0;
           char currentFirstLetter = ' ';
           //////////////////////////////////////
           for (int i = 0; i < processedText.text.Count; i++)
           {
               if ((i + 1) % linesInPage == 0) { currentPage++; }
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
               
           }
           ///////////////////////////////


           foreach (var c in markedWords.OrderBy(x=>x.WordValue)) {

              
               if (!char.Equals(currentFirstLetter,c.WordValue[0])) {
                   currentFirstLetter = c.WordValue[0];
                   Console.WriteLine(char.ToUpper(currentFirstLetter));
               }

               Console.WriteLine(c.WordValue + new string('.',20-c.WordValue.Length) + c.Count + " :" + c.GetPageNumbersAsString());

           }



       }
       public void Test(int linesInPage) {
           int p = 0;
           if (linesInPage <= 0) { return; }

           foreach (var c in processedText) {
               foreach (var k in c.items) {

                   Console.Write(k.WordValue + " ");
               }
               Console.WriteLine();
               p++;
               if (p % (linesInPage) == 0) {
                   Console.WriteLine();
               }
           }

            
       }









    }
}
