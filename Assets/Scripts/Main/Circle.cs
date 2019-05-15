using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Circle : MonoBehaviour
{
    public static int x;
    public static int y;

    public static int notex;
    public static int notey;

    static int _ingredients_left = 1;
    public int ingredients_left
    {
        get { return _ingredients_left; }
        set
        {
            _ingredients_left = value;
            il_text.SetText(_ingredients_left+"");
        }
    } 
    public TextMeshProUGUI il_text;

    public static Ingredient ingredient;

    public GameObject result_screen;
    public Image potion_image;
    public TextMeshProUGUI name_text;

    public TMP_InputField potion_name;

    public static bool selected = false;

    public PixelLineRenderer plr;

    [SerializeField]
    static List<int> x_history = new List<int>();
    [SerializeField]
    static List<int> y_history = new List<int>();

    Potion potion;

    void Start()
    {
        ingredients_left = ingredients_left;
        ingredient = null;
        selected = false;

        if (x_history.Count == 0)
        {
            ingredients_left = Mathf.FloorToInt((Manager.level + 1) / 2);

            x_history.Add(0);
            y_history.Add(0);
        }

        plr.DrawLines(x_history, y_history);
    }

    public void DrawNotes()
    {
        if (ingredient != null)
        {
            x_history.Add(ingredient.notex + notex);
            y_history.Add(ingredient.notey + notey);

            plr.DrawLines(x_history, y_history);

            x_history.RemoveAt(x_history.Count - 1);
            y_history.RemoveAt(y_history.Count - 1);
        }
    }

    public void DrawHistory()
    {
        plr.DrawLines(x_history, y_history);
    }

    public void Operate(string o)
    {
        
        if (ingredients_left > 0 && selected)
        {
            selected = false;

            ingredient.count--;

            GameObject.Find("Inventory").GetComponent<Inventory>().UpdateInventory();

            switch (o)
            {
                case "add":
                    x += ingredient.x;
                    y += ingredient.y;

                    notex += ingredient.notex;
                    notey += ingredient.notey;

                    x_history.Add(notex);
                    y_history.Add(notey);

                    plr.DrawLines(x_history, y_history);

                    break;
                case "sub":
                    x -= ingredient.x;
                    y -= ingredient.y;

                    notex -= ingredient.notex;
                    notey -= ingredient.notey;
                    break;
            }

            ingredients_left--;
        } else
        {

        }
    }

    public void AddPotion()
    {
        potion.name = potion_name.text;

        Manager.potions.Add(potion);
    }

    public void GetPotion()
    {
        if (ingredients_left < Mathf.FloorToInt((Manager.level + 1) / 2))
        {
            x_history = new List<int>();
            y_history = new List<int>();

            x_history.Add(0);
            y_history.Add(0);

            selected = false;

            ingredients_left = Mathf.FloorToInt((Manager.level + 1) / 2);

            var c = CheckPosition(x, y);

            result_screen.SetActive(true);

            if (c == null)
            {

            }
            else
            {
                potion = new Potion();

                potion_image.sprite = Resources.Load<Sprite>("Potions/" + c.gameObject.name + " Potion");
                name_text.SetText(c.gameObject.name + " " + c.potentcy + " " + c.name);

                potion.type = c.gameObject.name;
                potion.info = c.gameObject.name + " " + c.potentcy + " " + c.name;
            }
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
            if (g.GetComponent<CirclePart>())
            {
                if (g.sprite.texture.GetPixel(x + g.sprite.texture.height * g.GetComponent<CirclePart>().num, y).a != 0)
                {
                    return g.GetComponent<CirclePart>();
                }
            }
        }

        return null;
    }
}
