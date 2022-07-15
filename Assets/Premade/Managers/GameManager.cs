using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string SCORE = "Score";
    private const string SAMPLE_SCENE_NAME = "SampleScene";
    
    public static GameManager Instance;
    public CameraManager CameraManager;
    public GameEventsSystem GameEventsSystem;
    
    float _prevTimeScale = 1;

    private void Awake()
    {
        Instance = this;

        SetupSystems();
    }
    private void OnEnable()
    {
        Instance = this;
    }

    private void SetupSystems()
    {
        CameraManager = new CameraManager();
        GameEventsSystem = new GameEventsSystem();
    }
    
    public void SaveHighScore()
    {
        var currentMaxScore = SaveLocallyHandler.LoadInt(SCORE);
        var currentGameScore = 0;
        
        if (currentGameScore > currentMaxScore)
        {
            SaveLocallyHandler.SaveInt(SCORE, currentGameScore);
        }
    }
    
    public void PauseGame()
    {
        _prevTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = _prevTimeScale;
        Pool.pools = new Dictionary<PooledMonobehaviour, Pool>();
        SceneManager.LoadScene(SAMPLE_SCENE_NAME);
    }
}
