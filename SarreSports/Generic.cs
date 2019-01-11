//Project Name: SarreSports | File Name: Generic.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 7/1/2019 | 14:32
//Last Updated On:  10/1/2019 | 23:51
using System;
using System.Globalization;
using System.Linq;

namespace SarreSports
{
    class Generic
    {
        //Generic Methods
        /// <summary>
        /// Check whether each character within a given string is an integer
        /// </summary>
        /// <param name="value">Return boolean result</param>
        /// <returns></returns>
        public static bool IsInteger(string value) => value.All(c => c >= '0' && c <= '9');

        /// <summary>
        /// Method truncates string to meet a maximum character requirement
        /// </summary>
        /// <param name="value">String value to be truncated</param>
        /// <param name="maxChars">Maxmium character length (integer) permitted</param>
        /// <param name="addEllipsis">By default, ellipsis added to truncated string as defined by boolean value</param>
        /// <returns>Truncated string value</returns>
        public static string Truncate(string value, int maxChars, bool addEllipsis = true)
        {
            string ellipsis = addEllipsis ? "..." : "";
            return value.Length <= maxChars ? value : value.Substring(0, maxChars - ellipsis.Length) + ellipsis;
        }
    }

    /// <summary>
    /// Extension to String Class to allow  new string specific functions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalises first character of a string and returns the new string
        /// </summary>
        /// <param name="input">Input String</param>
        /// <returns>Capitalised Input String</returns>
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": return null; //throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)) IsUdtRet;
                default:
                    if (input.Contains(' '))
                    {
                        TextInfo textInfo = new CultureInfo("en-UK",false).TextInfo;
                        return (string)textInfo.ToTitleCase(input);
                    } else
                    {
                        return input.First().ToString().ToUpper() + input.Substring(1);
                    }
            }
        }
    }
}
