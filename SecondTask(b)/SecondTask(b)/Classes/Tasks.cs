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


           for (int i = 0; i < processedText.text.Count; i++) {
               for (int j = 0; j < processedText[i].items.Count; j++) {

                   if (!markedValueWords.Contains(processedText[i].items[j].WordValue)) {
                       markedValueWords.Add(processedText[i].items[j].WordValue);
                       markedWords.Add(processedText[i].items[j]);


                   }
                      
                       
                            

               }
           }


       }





    }
}
