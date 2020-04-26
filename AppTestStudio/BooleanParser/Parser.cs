namespace BooleanParser
{
    /// <summary>
    /// Parses a given string of input as a boolean expression and produces
    /// the boolean output of the expression
    /// </summary>
    public partial class Parser
    {
        private readonly TokenEnumerator tokens;

        /// <summary>
        /// Construct a parser with a given boolean expression
        /// </summary>
        /// 
        /// <param name="input">
        /// The boolean expression to parse
        /// </param>
        public Parser(string input) => tokens = new TokenEnumerator(input);

        /// <summary>
        /// Parse the boolean expression given on instantiation
        /// </summary>
        /// 
        /// <returns>
        /// The result of parsing the boolean expression
        /// </returns>
        /// 
        /// <exception cref="UnexpectedTokenException">
        /// Thrown when a token was unexpected during parsing
        /// </exception>
        public bool Parse()
        {
            if (tokens.Current is null)
            {
                throw new UnexpectedTokenException("<EOF>");
            }

            var expression = ParseWith(Expression);

            if (expression is null || !(tokens.Current is null))
            {
                throw tokens.UnexpectedToken();
            }

            return expression.Value;
        }

        // Expression := Term {BinaryOperator Term}
        private bool? Expression()
        {
            var result = ParseWith(Term);

            if (result is null)
            {
                return null;
            }

            while (true)
            {
                var opAndTerm = ParseWith(GetOpAndTerm);

                if (opAndTerm is null)
                {
                    return result;
                }

                (string op, bool term) = opAndTerm.Value;

                result = BinaryOperation(result.Value, op, term);

                if (result is null)
                {
                    return null;
                }
            }

            (string op, bool term)? GetOpAndTerm()
            {
                var op = tokens.Current;

                if (op is null)
                {
                    return null;
                }

                tokens.MoveNext();

                var term = ParseWith(Term);

                if (term is null)
                {
                    return null;
                }

                return (op, term.Value);
            }
        }

        // Term := [UnaryOperator] Factor
        private bool? Term()
        {
            bool isNot = false;

            if (tokens.Current == "NOT")
            {
                isNot = true;
                tokens.MoveNext();
            }

            var factor = ParseWith(Factor);

            return isNot ? Not(factor) : factor;
        }

        // Factor := Boolean | ParenthesisedExpression
        private bool? Factor()
        {
            return ParseWith(Boolean, ParenthesisedExpression);
        }

        // ParenthesisedExpression := '(' Expression ')'
        private bool? ParenthesisedExpression()
        {
            if (tokens.Current != "(")
            {
                return null;
            }

            tokens.MoveNext();

            var expression = ParseWith(Expression);

            if (tokens.Current != ")")
            {
                return null;
            }

            tokens.MoveNext();

            return expression;
        }

        // Boolean := 'TRUE' | 'FALSE'
        private bool? Boolean()
        {
            if (bool.TryParse(tokens.Current, out bool value))
            {
                tokens.MoveNext();
                return value;
            }
            else
            {
                return null;
            }
        }
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