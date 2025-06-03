using System;
using UnityEngine;
using Random = System.Random;

public class RandomMake
{
    private int[][] levels = new int[][]
 {
    new int[] { 90, 10, 0 },
    new int[] { 70, 20, 10 },
    new int[] { 50, 30, 20 }
 };

    public int[] GetRandoms(int lvl, int count)
    {
        var randoms = new int[count];
        

        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            var percent = rand.Next(1, 100);

            for (int j = 0; j < 3; j++)
            {
                if (percent < levels[lvl][j])
                {
                    randoms[i] = rand.Next(1, (int)Mathf.Pow(10, lvl));
                }
            }
        }


        for (int i = 0;i<randoms.Length;i++)
        {
            str += randoms[i] + "/";
        }
        Debug.Log(str);

        return randoms;
    }
}
