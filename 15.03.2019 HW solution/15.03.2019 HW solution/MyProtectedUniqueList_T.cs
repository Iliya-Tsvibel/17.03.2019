using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._03._2019_HW_solution
{
    class MyProtectedUniqueList_T<T> : IEnumerable<T>
    {
        private List<T> words = new List<T>();
        private string secretWord;

        public MyProtectedUniqueList_T(List<T> words, string secretWord)
        {
            this.words = words;
            this.secretWord = secretWord;
        }

        public void Add(T word)
        {
            if (word == null)
                throw new ArgumentNullException("The word is not exist or empty");
            else if (words.Contains(word))
                throw new InvalidOperationException($"In the library already exist this word: {word}");
            else
                words.Add(word);


        }
        public void Remove(T word)
        {
            if (word == null)
                throw new ArgumentNullException("The word is not exist or empty");
            else if (!words.Contains(word))
                throw new ArgumentException($"The library does not contain this word: {word}");
            else
                words.Remove(word);

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


            string BaseLibrary = string.Empty;
            for (int i = 0; i < words.Count; i++)
            {
                BaseLibrary += (words[i] + "\n");
            }
            return BaseLibrary;

        }

       public IEnumerator<T> GetEnumerator()
        {
            return words.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return words.GetEnumerator();
        }
    }
}
