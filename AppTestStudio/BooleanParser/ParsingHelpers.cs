//MIT License
//Copyright(c) 2019 Tom Humphreys
using System;

namespace BooleanParser
{
    public partial class Parser
    {
        private bool? Not(bool? val) => 
            val.HasValue ? !val.Value : val;

        private bool? BinaryOperation(bool lhs, string op, bool rhs)
        {
            switch (op)
            {
                case "AND":
                    return lhs && rhs;
                case "OR":
                    return lhs || rhs;
                case "XOR":
                    return lhs ^ rhs;
                case "NOR":
                    return !(lhs || rhs);
                case "NAND":
                    return !(lhs && rhs);
                case "XNOR":
                    return !(lhs ^ rhs);
                default:
                    return null;
            }
        }

        private T? ParseWith<T>(params Func<T?>[] parseMethods)
            where T : struct
        {
            foreach (var parseMethod in parseMethods)
            {
                tokens.SetBacktrackPoint();

                T? result = parseMethod();

                if (result is null)
                {
                    tokens.Backtrack();
                }
                else
                {
                    return result;
                }
            }

            return null;
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