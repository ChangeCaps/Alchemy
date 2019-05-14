using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PixelLineRenderer : MonoBehaviour
{
    RawImage img;

    public int height;
    public int width;

    public Color32 color;

    void Start()
    {
        img = GetComponent<RawImage>();
    }

    public void DrawLines(List<int> X, List<int> Y)
    {
        if (X.Count != Y.Count)
            throw new System.IndexOutOfRangeException("Unequal array lengths");

        List<int> x = new List<int>();
        List<int> y = new List<int>();

        for (int i = 0; i < X.Count; i++)
        {
            x.Add(X[i] + 60);
            y.Add(Y[i] + 61);
        }

        Texture2D t = new Texture2D(width, height, TextureFormat.ARGB32, false);

        int xpos;
        int ypos;

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                t.SetPixel(i, j, new Color32(0, 0, 0, 0));

        for (int line = 0; line < x.Count - 1; line++)
        {
            xpos = x[line];
            ypos = y[line];

            int xdiff = x[line + 1] - xpos;
            int ydiff = y[line + 1] - ypos;

            if (xdiff > ydiff)
            {
                for (int _x = xpos; _x != x[line + 1] + xdiff / Mathf.Abs(xdiff); _x += xdiff/Mathf.Abs(xdiff))
                {
                    t.SetPixel(_x, (int)((float)ydiff / (float)xdiff * ((float)_x - xpos)) + xpos, color);
                }
            } else
            {
                for (int _y = ypos; _y != y[line + 1] + ydiff / Mathf.Abs(ydiff); _y += ydiff / Mathf.Abs(ydiff))
                {
                    t.SetPixel((int)((float)xdiff / (float)ydiff * ((float)_y - ypos)) + ypos, _y, color);
                }
            }
        }

        t.Apply();
        t.filterMode = FilterMode.Point;
        img.texture = t;
    }
}
