namespace CI
{
    public class One_11
    {
        public bool X => true;

        public static bool IsRotation(string original, string candidate)
        {
            //rotation is cutting a substring from 0 -n and appending it to the end
            var lastPos = original.Length - 1;
            var longestSubstring = 0;
            for (var outerPos = lastPos; outerPos >= 0; outerPos--)
            {
                var charTocompare = original[outerPos];
                var found = false;
                for (var innerPos = outerPos; innerPos >= 0; innerPos--)
                {
                    if (candidate[innerPos] != charTocompare) continue;
                    found = true;
                    for (var innerNext = innerPos-1; innerNext >= 0; innerNext--) {
                        if (candidate[innerNext] == charTocompare) {
                            found = true;
                            break;
                        }
                    }
                    break;
                }
                
            }
            return false;
        }
    }
}