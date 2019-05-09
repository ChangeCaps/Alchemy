using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckPosition(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckPosition(int x, int y)
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
                g.gameObject.SetActive(false);
            }
        }
    }
}
