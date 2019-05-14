using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float min;
    public float max;

    Vector3 startpos;

    private void Start()
    {
        startpos = (transform as RectTransform).position;
    }

    void Update()
    {
        Vector3 pos = (transform as RectTransform).localPosition;
        pos.y -= Input.mouseScrollDelta.y * 5;
        pos.y = Mathf.Min(Mathf.Max(pos.y, min), max);
        (transform as RectTransform).localPosition = pos;
    }

    public void ResetPosition()
    {
        (transform as RectTransform).position = startpos;
    }
}
