using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public float highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    [System.Serializable]
    class SaveData
    {
        public float SavedScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.SavedScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string filePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.SavedScore;
        }
    }
    
}
