using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMPro.TMP_InputField NameInput;
    public string CurrentPlayerName;

    [System.Serializable]
    public struct ScoreNamePair
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class Leaderboard
    {
        public List<ScoreNamePair> LeaderboardData;
    }

    public Leaderboard leaderboard = new Leaderboard();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadHighScores();
    }

    public void SaveHighScores(ScoreNamePair newScore)
    {
        Leaderboard data = leaderboard;
        for (int i = 0; i < 5; i++)
        {
            if (i < data.LeaderboardData.Count)
            {
                if (newScore.score > data.LeaderboardData[i].score)
                {
                    data.LeaderboardData.Insert(i, newScore);
                    if (data.LeaderboardData.Count > 5)
                        data.LeaderboardData.RemoveAt(data.LeaderboardData.Count - 1);
                    break;
                }
            }
            else
            {
                data.LeaderboardData.Insert(i, newScore);
                break;
            }
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Leaderboard data = JsonUtility.FromJson<Leaderboard>(json);

            leaderboard = data;
        }
    }
}
