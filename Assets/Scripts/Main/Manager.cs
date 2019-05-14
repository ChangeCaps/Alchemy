using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Note
{
    public string Title;
    public string[] Lines;
}

public class Potion
{
    public string name;
    public string type;
    public string info;
}

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public static List<Ingredient> ingredients = new List<Ingredient>();
    public List<Ingredient> Ingredients = new List<Ingredient>();

    public static List<Potion> potions = new List<Potion>();

    [SerializeField]
    bool NewCampain;

    public static bool new_campain;

    public static int level = 2;

    private void Awake()
    {
        new_campain = NewCampain;

        if (instance == null)
        {
            ingredients = Ingredients;

            instance = this;

            if (!NewCampain)
            {
                LoadGame();
            }

            foreach (Ingredient i in ingredients)
            {
                if (NewCampain)
                {
                    i.count = 0;
                    i.notex = 0;
                    i.notey = 0;
                }

                if ((i.x == 0 && i.y == 0) || (NewCampain && !i.Fixed))
                {
                    float a = Random.Range(0, 360);

                    i.x = Mathf.RoundToInt(Mathf.Cos(a) * i.potentcy);
                    i.y = Mathf.RoundToInt(Mathf.Sin(a) * i.potentcy);
                }
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        new_campain = NewCampain;
    }

    void Update()
    {
        
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("potionnum", potions.Count);

        for (int i = 0; i < potions.Count; i++)
        {
            PlayerPrefs.SetString("potionname" + i, potions[i].name);
            PlayerPrefs.SetString("potiontype" + i, potions[i].type);
            PlayerPrefs.SetString("potioninfo" + i, potions[i].info);
        }

        for (int i = 0; i < ingredients.Count; i++)
        {
            PlayerPrefs.SetInt("icount" + i, ingredients[i].count);
            PlayerPrefs.SetInt("ix" + i, ingredients[i].x);
            PlayerPrefs.SetInt("iy" + i, ingredients[i].y);
            PlayerPrefs.SetInt("inotex" + i, ingredients[i].notex);
            PlayerPrefs.SetInt("inotey" + i, ingredients[i].notey);
        }
    }

    void LoadGame()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("potionnum"); i++)
        {
            Potion p = new Potion();

            p.name = PlayerPrefs.GetString("potionname" + i);
            p.type = PlayerPrefs.GetString("potiontype" + i);
            p.info = PlayerPrefs.GetString("potioninfo" + i);

            potions.Add(p);
        }

        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredients[i].count = PlayerPrefs.GetInt("icount"+i);
            ingredients[i].x = PlayerPrefs.GetInt("ix" + i);
            ingredients[i].y = PlayerPrefs.GetInt("iy" + i);
            ingredients[i].notex = PlayerPrefs.GetInt("inotex" + i);
            ingredients[i].notey = PlayerPrefs.GetInt("inotey" + i);
        }

        Ingredients = ingredients;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
