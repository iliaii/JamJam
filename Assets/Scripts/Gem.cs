using System;
using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    public static event Action<int> OnGemCollect;
    public int worth = 1;

    public void Collect()
    {
        OnGemCollect.Invoke(worth);
        Destroy(gameObject);
    }
}
