using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    public string PlayerName;

    public string HighScorePlayerName;

    

    public int HighestScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighestScorePlayer();
    }
    [System.Serializable]
    class HighestScorePlayer
    {
        public string HighScorePlayerName;
        public int HighestScore;
    }  

    public void SaveHighestScorePlayer()
    {
        HighestScorePlayer highestScorePlayer = new HighestScorePlayer();
        highestScorePlayer.HighScorePlayerName = HighScorePlayerName;
        highestScorePlayer.HighestScore = HighestScore;


        string json = JsonUtility.ToJson(highestScorePlayer);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadHighestScorePlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighestScorePlayer highestScorePlayer = JsonUtility.FromJson<HighestScorePlayer>(json);
            HighScorePlayerName = highestScorePlayer.HighScorePlayerName;
            HighestScore = highestScorePlayer.HighestScore;
       }       
    }
}
