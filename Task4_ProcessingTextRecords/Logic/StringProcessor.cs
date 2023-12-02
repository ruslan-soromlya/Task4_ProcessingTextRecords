﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_ProcessingTextRecords.Logic
{
    internal static class StringProcessor
    {
        private static readonly string[] _wordDividers = { " ", ",", ".", "!", ":", "?", ";", "-" };

        private static readonly char[] _vowelsCharsToSearch = { 'ї', 'а' };
        private static readonly char[] _consonantsCharsToSearch = { 'р', 'з', 'с' };

        private static readonly string _lettersThatEndsByPattern = "ти";


        public static IEnumerable<string> Task1Process(string s)
        {
            var words = s.ToWords();
            var wordsAndReverse = words.Select(x => x + " -> " + x.Reverse());
            return wordsAndReverse;

        }

        public static int Task2Process(string s, bool shouldCountVowels)
        {
            var charsToCount = shouldCountVowels ? _vowelsCharsToSearch : _consonantsCharsToSearch;
            return CountCharsInString(s, charsToCount);
        }

        public static IEnumerable<string> Task3Process(string s)
        {
            return s.ToWords().Where(x => x.ToLowerInvariant().EndsWith(_lettersThatEndsByPattern));
        }

        private static int CountCharsInString(string s, char[] charsToCount)
        {
            return s.Count(x => charsToCount.Contains(char.ToLowerInvariant(x)));
        }

        private static IEnumerable<string> ToWords(this string s)
        {
            return s.Split(_wordDividers, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
