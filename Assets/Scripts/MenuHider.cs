using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHider : MonoBehaviour
{
    public float x;
    public float width;

    void Update()
    {
        Vector3 pos = (transform as RectTransform).localPosition;
        pos.x = Mathf.Min(-Input.mousePosition.x*2 + width/2 + Screen.width/2 + x, x);
        (transform as RectTransform).localPosition = pos;
    }
}
