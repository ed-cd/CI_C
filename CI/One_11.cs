using System.Linq;

namespace CI
{
    public class One_11
    {
        public bool X => true;

        public static bool IsRotation(string original, string candidate)
        {
            if (original.Length != candidate.Length) return false;
            //rotation is cutting a substring from 0 -n and appending it to the end
            var lastPos = original.Length - 1;

            var innerStartPos = lastPos;

            const string original1 = "AABABBA";
            const string rotation1 = "BABBAAA";
            var outerPos = lastPos;
            for (var innerPos = innerStartPos;;)
            {
                var charToCompare = original[outerPos];
                if (candidate[innerPos] != charToCompare)
                {
                    if (innerPos == 0)
                    {
                        return false;
                    }
                    innerStartPos--;
                    innerPos = innerStartPos;
                    outerPos = lastPos;
                }
                else
                {
                    if (innerPos == 0)
                    {
                        goto breakOutOfOuterLoop;
                    }
                    outerPos--;
                    innerPos--;
                }
            }
            breakOutOfOuterLoop:
            var candidateSubstring = candidate.Substring(innerStartPos + 1, candidate.Length - innerStartPos - 1);
            return !candidateSubstring.Where((val, index) => original[index] != val).Any();
        }
    }
}