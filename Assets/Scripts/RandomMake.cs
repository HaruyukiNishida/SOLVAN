using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public static class RandomMake
{
    private static int[][] levels = new int[][]
 {
    new int[] { 100, 0, 0 },
    new int[] { 90, 10, 0 },
    new int[] { 85, 15, 0 },
    new int[] { 75, 25, 0 },
    new int[] { 25, 75, 0 },
    new int[] { 10, 90, 0 },
    new int[] { 10, 80, 10 },
    new int[] { 10, 50, 40 },
    new int[] { 0, 50, 50 },
    new int[] { 0, 0, 100 }
 };

    static List<int> randoms;
    static Random rand;

    public static List<int> GetRandoms(int lvl, int count)
    {
        List<int> randoms = new List<int>();
        Random rand = new Random();

        int[] ranges = { 1, 10, 100 };
        int[] probabilities = levels[lvl];

        for (int i = 0; i < count; i++)
        {
            int percent = rand.Next(1, 101);
            int sum = 0;

            for (int j = 0; j < probabilities.Length; j++)
            {
                sum += probabilities[j];
                if (percent <= sum)
                {
                    randoms.Add(rand.Next(ranges[j], ranges[j] * 10));
                    break;
                }
            }
        }

        var str = $"Level:{lvl} count:{randoms.Count} / ";

        for (int i = 0; i < randoms.Count; i++)
        {
            str += randoms[i].ToString() + " / ";
        }
        Debug.Log(str);

        return randoms;

    }

}
