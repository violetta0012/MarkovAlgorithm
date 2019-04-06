using System;
using System.Collections.Generic;

namespace MarkovAlgorithm
{
    public class Scheme
    {
        private List<Formula> formulas;

        public Scheme(IEnumerable<string> strings)
        {
            formulas = new List<Formula>();
            foreach (var str in strings)
                formulas.Add(new Formula(str));
        }

        public string Apply(string origWord)
        {
            var word = origWord;
            var final = false;
            Console.WriteLine(word);
            while (true)
            {
                for (var i = 0; i < formulas.Count; i++)
                {
                    if (formulas[i].CanApply(word))
                    {
                        word = formulas[i].Apply(word);
                        Console.WriteLine(word);
                        final = formulas[i].isFinal;
                        break;
                    }

                    if (i == formulas.Count - 1)
                        final = true;
                }

                if (final)
                    break;
            }

            return word;
        }
    }
}