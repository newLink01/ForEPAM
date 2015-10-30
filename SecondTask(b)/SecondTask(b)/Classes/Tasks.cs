using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Tasks
    {

       public Text processedText;
       

       public Tasks(string path) {
           this.processedText = new Parser(path).TextParse();
       }

       public void ShowConcordance() {

           List<string> markedValueWords = new List<string>();
           List<IWord> markedWords = new List<IWord>();
           IWord toAdd = new Word();


           for (int i = 0; i < processedText.text.Count; i++)
           {
               for (int j = 0; j < processedText[i].items.Count; j++)
               {



                   if (!markedValueWords.Contains(processedText[i].items[j].WordValue))
                   {
                       string currentWord = processedText[i].items[j].WordValue;
                       markedValueWords.Add(currentWord);
                       toAdd.WordValue = currentWord;

                       for (int nest_i = 0; nest_i < processedText.text.Count; nest_i++)
                       {
                           for (int nest_j = 0; nest_j < processedText[i].items.Count; nest_j++)
                           {

                               if (processedText[nest_i].items[nest_j].WordValue == currentWord) {
                                   if (!toAdd.LineIndexes.Contains(nest_i)) {
                                       toAdd.LineIndexes.Add(nest_i);
                                   }


                               }


                           }
                           //markedWords.Add(processedText[i].items[j]);


                       }




                   }
               }

           }
       }





    }
}
