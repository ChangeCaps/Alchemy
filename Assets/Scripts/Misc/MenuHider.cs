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
        pos.x = Mathf.Min(-Input.mousePosition.x + width/2 + Screen.width/2 + x, x);
        pos.y -= Input.mouseScrollDelta.y * 5;
        pos.y = Mathf.Max(pos.y, 0);
        (transform as RectTransform).localPosition = pos;
    }
}
