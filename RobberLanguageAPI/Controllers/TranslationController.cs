using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobberLanguageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobberLanguageAPI.Controllers
{
    [Route("api/RobberLanguage”.")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        //public Translation translation { get; set; }
        
        [HttpPost]
        public Translation Translate(Translation originalSentence)
        {
            var translation = new Translation
            {
                OrginalSentence = originalSentence.OrginalSentence,
                TranslatedSentence = TranslateSentence(originalSentence.OrginalSentence)
            };

            return translation;
        }

        public static string TranslateSentence(string input)
        {
            if (input == null)
            {
                return "You must type a word or sentence";
            }

            string translatedSentence = "";
            char[] skippedChars = { 'a', 'o', 'u', 'å', 'e', 'i', 'y', 'ä', 'ö', ' ', ',', '-', '.', '!', '?', '"' }; 

            foreach (char letter in input)
            {
                    if (Array.IndexOf(skippedChars, letter) > -1)
                    {
                        translatedSentence += letter;
                    }
                    else if (letter == 'x')
                    {
                        translatedSentence += "koksos";
                    }
                    else
                    {
                        translatedSentence += letter + "o" + letter;
                    }

            }

            return translatedSentence;
        }
    }
}
