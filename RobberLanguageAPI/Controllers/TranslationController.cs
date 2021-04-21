using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobberLanguageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobberLanguageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        public Translation translation { get; set; }
        
        [HttpPost]
        public string Post(string text)
        {
            string newtext = TranslateSentence(text);
            return newtext;
        }

        public static string TranslateSentence(string input)
        {
            if (input == null)
            {
                return "You must type a word or sentence";
            }

            string translatedSentence = "";
            char[] vowels = { 'a', 'o', 'u', 'å', 'e', 'i', 'y', 'ä', 'ö', ' ' }; 

            foreach (char letter in input)
            {
                    if (Array.IndexOf(vowels, letter) > -1)
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
