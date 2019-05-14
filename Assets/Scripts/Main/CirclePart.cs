using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePart : MonoBehaviour
{
    public int num;

    public int potentcy;
    public new int name;

    private void Start()
    {
        if (PlayerPrefs.GetInt("cpname" + num) == 0 || Manager.new_campain)
        {
            name = Mathf.FloorToInt(Random.Range(1, 3.9999f));
            PlayerPrefs.SetInt("cpname" + num, name);
        } else
        {
            name = PlayerPrefs.GetInt("cpname" + num);
        }
    }
}
