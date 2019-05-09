using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public static List<Ingredient> ingredients = new List<Ingredient>();
    public List<Ingredient> Ingredients = new List<Ingredient>();

    [SerializeField]
    bool load;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadGame();
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    void SaveGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save/ingredients.txt");
        var json = JsonUtility.ToJson(ingredients);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/save/ingredients.txt") && load)
        {
            FileStream file = File.Open(Application.persistentDataPath + "/save/ingredients.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), ingredients);
            file.Close();

            Ingredients = ingredients;
        } else
        {
            ingredients = Ingredients;
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
