using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("Had");
        GameObject.Find("Circle").GetComponent<Circle>().DrawNotes();
    }
}
