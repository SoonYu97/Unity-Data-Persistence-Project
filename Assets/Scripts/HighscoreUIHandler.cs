using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreUIHandler : MonoBehaviour
{
    public TMPro.TMP_Text name1;
    public TMPro.TMP_Text name2;
    public TMPro.TMP_Text name3;
    public TMPro.TMP_Text name4;
    public TMPro.TMP_Text name5;
    public TMPro.TMP_Text score1;
    public TMPro.TMP_Text score2;
    public TMPro.TMP_Text score3;
    public TMPro.TMP_Text score4;
    public TMPro.TMP_Text score5;

    private UIManager.Leaderboard leaderboard;
    private void Start()
    {
        List<TMPro.TMP_Text> NameList = new List<TMPro.TMP_Text>
        {
            name1,
            name2,
            name3,
            name4,
            name5
        };
        List<TMPro.TMP_Text> ScoreList = new List<TMPro.TMP_Text>
        {
            score1,
            score2,
            score3,
            score4,
            score5,
        };
        leaderboard = UIManager.Instance.leaderboard;
        for (int i = 0; i < 5; i++)
        {
            if (i < leaderboard.LeaderboardData.Count)
            {
                NameList[i].text = leaderboard.LeaderboardData[i].name;
                ScoreList[i].text = leaderboard.LeaderboardData[i].score.ToString();
            }
            else
            {
                break;
            }
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
