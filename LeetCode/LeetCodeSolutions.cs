using System.Text;

namespace LeetCode
{
    internal static class LeetCodeProblems
    {
        //Методы названы именами заданий и сортированы в алфавитном порядке ради удобства

        #region Build Array From Permutation
        public static int[] BuildArrayFromPermutation(int[] nums)
        {
            if (nums.Length == 1) return nums;
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }
            return ans;
        }
        #endregion

        #region Concatenation Of Array
        public static int[] GetConcatenation(int[] nums)
        {
            int[] ans = new int[nums.Length * 2];
            int i = 0;
            foreach (var el in ans)
            {
                if (i >= nums.Length)
                {
                    ans[i] = nums[i - nums.Length];
                }
                else
                {
                    ans[i] = nums[i];
                }
                i++;
            }
            return ans;
        }
        #endregion

        #region Decode The Message
        public static string DecodeTheMessage(string key, string message)
        {
            StringBuilder answer = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, char> decodingAlphabet = new Dictionary<char, char>(26);
            int alphabetPointer = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (decodingAlphabet.Count >= 26) break;
                if (key[i] == ' ') continue;
                if (decodingAlphabet.ContainsKey(key[i])) continue;
                decodingAlphabet[key[i]] = alphabet[alphabetPointer];
                alphabetPointer++;
            }
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    answer.Append(message[i]);
                    continue;
                }
                answer.Append(decodingAlphabet[message[i]]);
            }
            return answer.ToString();
        }
        #endregion

        #region How Many Numbers Are Smaller Than The Current Number
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                {
                    if (nums[i] == nums[i - 1])
                    {
                        result[i] = result[i - 1];
                        continue;
                    }
                }
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j == i) continue;
                    else if (nums[i] > nums[j])
                    {
                        result[i] += 1;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Integer To Roman
        public static string IntegerToRoman(int num)
        {
            Dictionary<int, string> romanIntegers = new Dictionary<int, string>(){
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100 , "C"},
            {90 , "XC"},
            {50 , "L"},
            {40 , "XL"},
            {10 , "X"},
            {9 , "IX"},
            {5 , "V"},
            {4 , "IV"},
            {1, "I"}};
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < romanIntegers.Count; i++)
            {
                while (num >= romanIntegers.ElementAt(i).Key)
                {
                    num -= romanIntegers.ElementAt(i).Key;
                    result.Append(romanIntegers.ElementAt(i).Value);
                }
            }
            return result.ToString();
        }
        #endregion

        #region Jewels In Stones
        public static int JewelsInStones(string jewels, string stones)
        {
            HashSet<char> jewelsSet = new HashSet<char>(jewels);
            short answer = 0;
            while (answer >> 8 < stones.Length)
            {
                if (jewelsSet.Contains(stones[answer >> 8])) answer = (short)(answer + 0b0000_0000_0000_0001);
                answer = (short)(answer + 0b0000_0001_0000_0000);
            }
            return answer & 0b_0000_0000_1111_1111;
        }
        #endregion

        #region Longest Common Prefix
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            string commonPrefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                string word = strs[i];

                if (word.Length == 0) return String.Empty;
                if (word.Length < commonPrefix.Length)
                {
                    commonPrefix = commonPrefix.Substring(0, word.Length);
                }
                for (int j = 0; j < commonPrefix.Length; j++)
                {
                    if (word[j] != commonPrefix[j])
                    {
                        commonPrefix = commonPrefix.Substring(0, j);
                        break;
                    }
                }
                if (commonPrefix.Length == 0) return String.Empty;
            }
            return String.Join("", commonPrefix);
        }
        #endregion

        #region Merge Two 2D Arrays By Summing Values
        public static int[][] MergeMergeTwo2DArraysBySummingValuesArrays(int[][] nums1, int[][] nums2)
        {
            List<List<int>> sumOfArrays = new List<List<int>>();
            int index = 0;
            int j = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1[i][0] == nums2[j][0])
                {
                    sumOfArrays.Add(new List<int> { nums1[i][0], nums1[i][1] + nums2[j][1] });
                    j++;
                }
                else if (nums1[i][0] < nums2[j][0])
                {
                    sumOfArrays.Add(new List<int> { nums1[i][0], nums1[i][1] });
                }
                else
                {
                    sumOfArrays.Add(new List<int> { nums2[j][0], nums2[j][1] });
                    j++;
                    i--;
                }
                index = i;
                if (j >= nums2.Length)
                {
                    for (int k = index + 1; k < nums1.Length; k++)
                    {
                        sumOfArrays.Add(new List<int> { nums1[k][0], nums1[k][1] });
                    }
                    break;
                }
            }
            index++;
            if (index >= nums1.Length && j < nums2.Length)
            {
                for (int k = j; k < nums2.Length; k++)
                {
                    sumOfArrays.Add(new List<int> { nums2[k][0], nums2[k][1] });
                }
            }
            int[][] answer = new int[sumOfArrays.Count][];
            for (int i = 0; i < sumOfArrays.Count; i++)
            {
                answer[i] = new int[] { sumOfArrays[i][0], sumOfArrays[i][1] };
            }
            return answer;
        }
        #endregion

        #region Palindrome Number
        public static bool PalindromeNumber(int x)
        {
            if (x < 0) return false;
            string str = x.ToString();
            int j = str.Length - 1;
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[j]) return false;
                j--;
            }
            return true;
        }
        #endregion

        #region Remove Duplicates From Sorted Array
        public static int RemoveDuplicatesFromSortedArray(int[] nums)
        {
            if (nums.Length == 1) return 1;

            HashSet<int> uniqueNums = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!uniqueNums.Contains(nums[i])) uniqueNums.Add(nums[i]);
            }
            for (int i = 0; i < uniqueNums.Count; i++)
            {
                nums[i] = uniqueNums.ElementAt(i);
            }
            return uniqueNums.Count;
        }
        #endregion

        #region Roman To Integer
        public static int RomanToInteger(string s)
        {
            Dictionary<Char, int> romanIntegers = new Dictionary<Char, int>() { {'I', 1 }, {'V', 5}, {'X', 10}, {'L', 50},
                                                                                {'C', 100}, {'D', 500}, {'M', 1000} };
            int answer = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i >= s.Length - 1)
                {
                    answer += romanIntegers[s[i]];
                    break;
                }
                else if (s[i] == 'I' && s[i + 1] == 'V' | s[i + 1] == 'X')
                {
                    answer += romanIntegers[s[i + 1]] - 1;
                    i++;
                }
                else if (s[i] == 'X' && s[i + 1] == 'L' | s[i + 1] == 'C')
                {
                    answer += romanIntegers[s[i + 1]] - 10;
                    i++;
                }
                else if (s[i] == 'C' && s[i + 1] == 'D' | s[i + 1] == 'M')
                {
                    answer += romanIntegers[s[i + 1]] - 100;
                    i++;
                }
                else
                {
                    answer += romanIntegers[s[i]];
                }
            }
            return answer;
        }
        #endregion

        #region Shuffle The Array
        public static int[] ShuffleTheArray(int[] nums, int n)
        {
            int[] result = new int[n << 1];
            int xPointer = 0;
            int yPointer = n;
            for (int i = 0; i < n << 1; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = nums[xPointer];
                    xPointer++;
                }
                else
                {
                    result[i] = nums[yPointer];
                    yPointer++;
                }
            }
            return result;
        }
        #endregion

        #region Two Sum
        public static int[]? TwoSum(int[] nums, int target)
        {
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (hash.ContainsKey(diff))
                    return new int[] { hash[diff], i };
                else
                {
                    if (!hash.ContainsKey(nums[i]))
                        hash.Add(nums[i], i);
                }
            }

            return null;
        }
        #endregion

        #region Valid Parentheses
        public static bool ValidParentheses(string s)
        {
            if (s.Length % 2 != 0) return false;
            Stack<Char> stack = new Stack<Char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '('
                    || s[i] == '['
                    || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char top = stack.Pop();

                    if (top != '(' && s[i] == ')' ||
                        top != '{' && s[i] == '}' ||
                        top != '[' && s[i] == ']')
                    {
                        return false;
                    }
                }
            }
            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}