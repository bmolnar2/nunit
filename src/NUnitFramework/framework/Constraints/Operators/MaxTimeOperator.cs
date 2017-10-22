// *****************************************************************************
//Copyright(c) 2017 Charlie Poole, Rob Prouse

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
// ****************************************************************************

using System;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// Operator that tests if executed code terminated within
    /// specified maximum time.
    /// </summary>
    public class MaxTimeOperator : SelfResolvingOperator
    {
        private readonly TimeSpan _maxTime;

        /// <summary>
        /// Constructs MaxTimeOperator with specified timeout.
        /// </summary>
        public MaxTimeOperator(TimeSpan maxTime)
        {
            this._maxTime = maxTime;
            left_precedence = 1;
            right_precedence = 100;
        }

        /// <summary>
        /// Reduce produces a constraint from the operator and 
        /// any arguments. It takes the arguments from the constraint 
        /// stack and pushes the resulting constraint on it.
        /// </summary>
        public override void Reduce(ConstraintBuilder.ConstraintStack stack)
        {
            stack.Push(new MaxTimeConstraint(_maxTime));
        }
    }
}
