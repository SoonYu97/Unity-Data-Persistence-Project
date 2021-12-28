using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMPro.TMP_InputField NameInput;
    public struct HighScore
    {
        public string name;
        public int score;
    }

    public HighScore[] leaderboard = new HighScore[5];

    private void Start()
    {
        HighScore newScore = new HighScore {
            name = "test",
            score = 1
        };
        leaderboard[0] = newScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
