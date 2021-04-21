using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobberLanguageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RobberLanguageAPI.Models;

namespace RobberLanguageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        public static string TranslateSentence(string input)
        {
            string translatedSentence = "";
            char[] vowels = { 'a', 'o', 'u', 'å', 'e', 'i', 'y', 'ä', 'ö', ' ' }; 

            foreach (char letter in input)
            {
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (letter == vowels[i])
                    {
                        translatedSentence += letter;
                    }
                    else if (letter == 'x')
                    {
                        translatedSentence += "koksos";
                    }
                    else
                    {
                        translatedSentence += letter + 'o' + letter;
                    }
                }
            }

            return translatedSentence;
        }
    }
}
