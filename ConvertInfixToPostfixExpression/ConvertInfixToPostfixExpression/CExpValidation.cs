using System.Linq;

namespace ConvertInfixToPostfixExpression
{
    public class CExpValidation
    {
        /* Only excepted characters are 4 operators, brackets, dot and digit number which can be contained in expression
         * Only start with number, negative number or open bracket. Case (*)6 + 7 - 8 is invalid
         * Only end with number, close bracket. Case 7 * 9 (+) is invalid
         * All open brackets has close bracket of itself and vice versa. Assume open bracket is +1 and close bracket is -1, if number is negative or final number is not 0, expression will be wrong.
         * String for number must be a number and it's in range of decimal
         * A number is not more than 1 dot and minus is in front if it has
         * Not 2 operators near by even minus, it need bracket such as 8+(-3)
         * Division by Zero is optional, but it should check in program
         */

        public static ErrorItem ExpValidate(string exp)
        {
            string expTrimed = exp.Replace(" ", string.Empty);

            ErrorItem validReturn = ValideExceptedCharacters(expTrimed);
            if (validReturn.Code != 0)
                return validReturn;

            validReturn = ValidBracket(expTrimed);
            if (validReturn.Code != 0)
                return validReturn;

            //todo:

            return new ErrorItem {Code = 0, Msg = string.Empty};
        }

        private static ErrorItem ValidBracket(string exp)
        {
            return new ErrorItem {Code = 0, Msg = string.Empty};
        }

        /// <summary>
        /// Only excepted characters are 4 operators, brackets, dot and digit number which can be contained in expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static ErrorItem ValideExceptedCharacters(string exp)
        {
            for (int i = 0; i < exp.Length; i++)
            {
                if (!char.IsDigit(exp[i]) && !"()+-*/.".Contains(exp[i]))
                {
                    return new ErrorItem {Code = i, Msg = Messages.InvalidCharacters};
                }
            }

            return new ErrorItem {Code = 0, Msg = string.Empty};
        }
    }
}