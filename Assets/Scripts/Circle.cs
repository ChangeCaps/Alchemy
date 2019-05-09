using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public int x;
    public int y;

    public static int tempx;
    public static int tempy;

    public static Ingredient ingredient;

    void Start()
    {
        CheckPosition(0, 0);
    }

    public void Operate(string o)
    {
        switch (o)
        {
            case "add":
                x += tempx;
                y += tempy;
                break;
            case "sub":
                x -= tempx;
                y -= tempy;
                break;
        }
    }

    public void GetPotion()
    {
        var c = CheckPosition(x, y);

        if (c == null)
        {

        } else
        {

        }
    }

    CirclePart CheckPosition(int x, int y)
    {
        if (x == 0 && y == 0)
        {

        }

        x += 60;
        y += 60;

        foreach (Image g in GetComponentsInChildren<Image>())
        {
            if (g.sprite.texture.GetPixel(x + g.sprite.texture.height * g.GetComponent<CirclePart>().num, y).a != 0)
            {
                return g.GetComponent<CirclePart>();
            }
        }

        return null;
    }
}
