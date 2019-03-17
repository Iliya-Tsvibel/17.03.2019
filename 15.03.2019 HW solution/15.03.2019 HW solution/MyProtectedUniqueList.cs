using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._03._2019_HW_solution
{
    class MyProtectedUniqueList : IEnumerable<string>
    {
        private List<string> words = new List<string>();
        private string secretWord;
        private string v;

        public MyProtectedUniqueList(List<string> words, string secretWord) : this(words)
        {
            this.secretWord = secretWord;
        }

        public MyProtectedUniqueList(List<string> words)
        {
            this.words = words;
        }

        public MyProtectedUniqueList(string v)
        {
            this.v = v;
        }

        public void Add(string word)
        {
            if (word == "" || word == null)
            {
                throw new ArgumentNullException("The word is not exist or empty");
            }
            foreach (string library in words)
            {
                if (library == word)
                {
                    throw new InvalidOperationException("This word already exist in library");
                }
                words.Add(word);
            }
            
        }
        public void Remove(string word)
        {
            if (word == "" || word == null)
            {
                throw new ArgumentNullException("The word is not exist or empty");
            }
            foreach (string library in words)
            {
                if (library == word)
                {
                    words.Remove(word);
                }
                throw new ArgumentException("This word not exist in the library");
            }
            
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > words.Count)
            {
                throw new ArgumentOutOfRangeException("The word's index is smaller than zero or bigger than list");
            }
            words.RemoveAt(index);
        }
        public void Clear(string MySecretWord)
        {
            if (MySecretWord == this.secretWord)
                words.Clear();
            else
                throw new AccessViolationException("Wrong keyword");
        }
        public void Sort(string MySecretWord)
        {
            if (MySecretWord == this.secretWord)
                words.Sort();
            else
                throw new AccessViolationException("Wrong keyword");
        }
        public override string ToString()
        {
           

            string result = "";
            foreach (string library in words)
            {
                result = result + $"{library}\n";
            }
            return result;

        }

        public IEnumerator<string> GetEnumerator()
        {
            return words.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return words.GetEnumerator();
        }
    }
}
