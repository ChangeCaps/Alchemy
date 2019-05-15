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

    void Awake()
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
            y.Add(Y[i] + 59);
        }

        Texture2D t = new Texture2D(width, height, TextureFormat.ARGB32, false);

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                t.SetPixel(i, j, new Color32(0, 0, 0, 0));

        for (int line = 0; line < x.Count - 1; line++)
        {
            int xdiff = x[line + 1] - x[line];
            int ydiff = y[line + 1] - y[line];

            if (xdiff != 0 || ydiff != 0)
            {
                if (Mathf.Abs(xdiff) > Mathf.Abs(ydiff))
                {
                    int sx = x[line] > x[line + 1] ? x[line + 1] : x[line];
                    int sy = x[line] > x[line + 1] ? y[line + 1] : y[line];
                    int ex = x[line] > x[line + 1] ? x[line] : x[line + 1];
                    int ey = x[line] > x[line + 1] ? y[line] : y[line + 1];

                    for (int _x = sx; _x <= ex; _x++)
                    {
                        t.SetPixel(_x, Mathf.RoundToInt((float)(ey - sy) / (float)(ex - sx) * ((float)_x - sx)) + sy, color);
                    }
                }
                else
                {
                    int sy = y[line] > y[line + 1] ? y[line + 1] : y[line];
                    int sx = y[line] > y[line + 1] ? x[line + 1] : x[line];
                    int ey = y[line] > y[line + 1] ? y[line] : y[line + 1];
                    int ex = y[line] > y[line + 1] ? x[line] : x[line + 1];

                    ydiff = sy - ey;

                    for (int _y = sy; _y <= ey; _y++)
                    {
                        t.SetPixel(Mathf.RoundToInt((float)(ex - sx) / (float)(ey - sy) * ((float)_y - sy)) + sx, _y, color);
                    }
                }
            }
        }

        t.Apply();
        t.filterMode = FilterMode.Point;
        img.texture = t;
    }
}
