using LeetCode;
using System;

LeetCodeSolutions.MyHashMap hashMap = new LeetCodeSolutions.MyHashMap();

var commands = new string[] {
    "MyHashMap","remove","put","remove","remove","get","remove","put","get","remove","put","put","put","put","put","put","put","put","put","put","put","remove","put","put","get","put","get","put","put","get","put","remove"};
var nums = new int[][]
{
new int[]{},
new int[]{27},
new int[]{65,65},
new int[]{19},
new int[]{0},
new int[]{18},
new int[]{3},
new int[]{42,0},
new int[]{19},
new int[]{42},
new int[]{17,90},
new int[]{31,76},
new int[]{48,71},
new int[]{5,50},
new int[]{7,68},
new int[]{73,74},
new int[]{85,18},
new int[]{74,95},
new int[]{84,82},
new int[]{59,29},
new int[]{71,71},
new int[]{42},
new int[]{51,40},
new int[]{33,76},
new int[]{17},
new int[]{89,95},
new int[]{95},
new int[]{30,31},
new int[]{37,99},
new int[]{51},
new int[]{95,35},
new int[]{65}
};

for (int i = 0; i < commands.Length; i++)
{
    switch (commands[i])
    {
        case "remove":
            hashMap.Remove(nums[i][0]);
            break;
        case "put":
            hashMap.Put(nums[i][0], nums[i][1]); 
            break;
        case "get":
            Console.WriteLine(hashMap.Get(nums[i][0]));
            break;
    }
}
Console.WriteLine();
