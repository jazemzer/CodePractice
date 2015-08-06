using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CodePractice.Utilities
{
    public static class TextHelper
    {
        public static string AskGoogle(this string ambigousToken)
        {
            string result = string.Empty;
            string url = @"http://www.google.com/search?start=0&num=10&client=google-csbe&output=xml_no_dtd&cx=014771461593579869765:fm6bfyrneqa&q=" + ambigousToken;

            var response = MakeGETRequest(url);

            if(!string.IsNullOrEmpty(response))
            {
                XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(response));                
                XDocument doc = XDocument.Load(reader);

                var spelling = doc.Element("GSP").Element("Spelling");
                if (spelling != null)
                {
                    result = spelling.Element("Suggestion").Attribute("q").Value;
                }                
            }
           
            return result;
        }

        public static string MakeGETRequest(string url)
        {
            var req = HttpWebRequest.Create(url);
            req.Method = "GET";
            string xmlResponse = string.Empty;
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    using (StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc))
                    {
                        xmlResponse = loResponseStream.ReadToEnd();
                    }
                }

                return xmlResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string SpaceDelimit(this string phrase, bool textOnly = false)
        {
            if (string.IsNullOrEmpty(phrase))
                return null;

            char spacer = ' ';

            char previous = spacer;
            char current = spacer;

            var characters = new List<char>();

            bool addSpace = false;
            bool swallow = false;
            char character = spacer;
            foreach (var temp in phrase.ToCharArray())
            {
                addSpace = false;
                swallow = false;

                if (textOnly && !char.IsLetter(temp))
                    character = spacer;
                else
                    character = temp;

                if (char.IsLetter(character))
                {
                    if (previous == spacer)
                    {

                    }
                    else if (!char.IsLetter(previous))
                    {
                        addSpace = true;
                    }
                    else if (char.IsUpper(character)
                        && char.IsLower(previous))
                    {
                        addSpace = true;
                    }
                }
                else if (char.IsDigit(character))
                {
                    if (previous == spacer
                        || char.IsDigit(previous)
                        || previous == '.' || previous == ',' || previous == '-')
                    {

                    }
                    else
                    {
                        addSpace = true;
                    }
                }
                else if (character == '.' || character == ',' || character == '-') //To retain number separators
                {                    
                    if (!char.IsDigit(previous))
                    {
                        addSpace = true;
                        swallow = true;
                    }
                }
                else if (character == '%')
                {
                }
                else if (character == spacer)
                {
                    if (previous == spacer)  //To Avoid double spaces
                    {
                        swallow = true;
                    }
                }
                else
                {
                    if (previous == spacer)
                    {

                    }
                    else if (char.IsLetterOrDigit(previous))
                    {
                        addSpace = true;
                    }
                    swallow = true;
                }

                if (addSpace)
                {
                    characters.Add(spacer);
                }

                if (!swallow)
                {
                    characters.Add(character);
                    previous = character;
                }
                else
                {
                    previous = spacer;
                }

            }
            return string.Join("", characters).ToLowerInvariant();
        }
    }
}
