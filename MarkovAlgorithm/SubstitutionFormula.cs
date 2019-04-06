using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace MarkovAlgorithm
{
    public class Formula
    {
        readonly string from;
        readonly string to;
        public bool isFinal { get; }

        public Formula(string str)
        {
            var ind = str.IndexOf("->", StringComparison.InvariantCulture);
            from = str.Substring(0, ind).Trim();
            isFinal = str[ind + 2] == '.';
            ind += isFinal ? 3 : 2;
            to = str.Substring(ind).Trim();
        }

        public string Apply(string word)
        {
            var ind = word.IndexOf(from, StringComparison.InvariantCulture);
            var prefix = word.Substring(0, ind);
            var postfix = word.Substring(ind + from.Length);
            return $"{prefix}{to}{postfix}";
        }

        public bool CanApply(string word)
        {
            return word.Contains(from);  
        } 
    }
}