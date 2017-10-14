using System;

namespace TimezoneNanoService
{
    class LambdaSyntax
    {
        private void DoWorkWithFunction(Func<string, int> functionToUse)
        {
            // performs work using provided function
        }

        private void SyntaxExample()
        {
            // call method "DoWorkWithFunction" and pass in function to use
            DoWorkWithFunction(str => str.Length);
        }

        private int GetLength(string str)
        {
            return str.Length;
        }

    }
}
