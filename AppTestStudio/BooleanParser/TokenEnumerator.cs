using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BooleanParser
{
    /// <summary>
    /// Supports enumerating over tokens (words and parenthesis) while also
    /// supporting stack-based backtracking.
    /// </summary>
    public class TokenEnumerator
    {
        private readonly Stack<int> indexes = new Stack<int>();
        private readonly string[] tokens;

        public TokenEnumerator(string str)
        {
            // Get all the tokens from the string
            // Mmmmmm what a lovely Regex
            tokens = Regex.Split(str, @"([ \(\)])")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            indexes.Push(0);
        }

        /// <summary>
        /// The current token
        /// </summary>
        public string Current => 
            indexes.Peek() < tokens.Length ? tokens[indexes.Peek()] : null;

        /// <summary>
        /// Push the current point onto the stack as a point that can be 
        /// backtracked to using <see cref="Backtrack"/>.
        /// </summary>
        public void SetBacktrackPoint() => indexes.Push(indexes.Peek());

        /// <summary>
        /// Go back to the appropriate point set using 
        /// <see cref="SetBacktrackPoint"/>
        /// </summary>
        public void Backtrack() => indexes.Pop();

        /// <summary>
        /// Move to the next token
        /// </summary>
        /// 
        /// <returns>
        /// Can <see cref="Current"/> be used?
        /// </returns>
        public bool MoveNext()
        {
            indexes.Push(indexes.Pop() + 1);
            return tokens.Length > indexes.Peek();
        }

        /// <summary>
        /// Create a <see cref="UnexpectedTokenException"/> for the current
        /// token.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="UnexpectedTokenException"/>.
        /// </returns>
        public UnexpectedTokenException UnexpectedToken() => 
            new UnexpectedTokenException(tokens[indexes.Peek()]);
    }
}
//MIT License
//Copyright(c) 2019 Tom Humphreys
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.