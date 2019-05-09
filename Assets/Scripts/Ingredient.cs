using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public Sprite sprite;
    public new string name;

    public float rareity;

    public int potentcy;

    public enum Currency {
        CP,
        SP,
        GP
    }
    public Currency currency;
    public float cost;

    public int count;

    public int x;
    public int y;

    public int notex;
    public int notey;
}
