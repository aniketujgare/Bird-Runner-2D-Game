using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{
    public static LeaderBoardController instance;

    private const string ID = "CgkI2t7127IWEAIQAg";

    private Button leaderboardsBtn;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        GetTheButton();
    }

    // Update is called once per frame
    void Start()
    {
        PlayGamesPlatform.Activate();
    }

    void GetTheButton ()
    {
        leaderboardsBtn = GameObject.Find("Leaderboards Button").GetComponent<Button>();
        leaderboardsBtn.onClick.RemoveAllListeners();
        leaderboardsBtn.onClick.AddListener(() => OpenLeaderboardScore());
    }
    void OnLevelWasLoaded(int level)
    {
        PostScore();
    }
    public void OpenLeaderboardScore()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ID);
        }
        else
        {
            Social.localUser.Authenticate((bool success) => {
                PlayGamesPlatform.Instance.SignOut();
            });
        }
    }
    void PostScore()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("Score"),ID,(bool success)=> { 
            
            });
            
        }
    }
}
