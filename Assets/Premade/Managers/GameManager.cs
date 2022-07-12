using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string SCORE = "Score";
    private const string SAMPLE_SCENE_NAME = "SampleScene";
    
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera cvc;
    public static GameManager instance;
    float _prevTimeScale = 1;
    GameState gameState = GameState.MenuScreen;

    private void Awake()
    {
        instance = this;
        PauseGame();
    }
    private void OnEnable()
    {
        instance = this;
    }

    public void PlayGame()
    {
        if (gameState == GameState.GameScreen)
        {
            Time.timeScale = _prevTimeScale;
        }
    }

    public void SaveHighScore()
    {
        var currentMaxScore = PlayerPrefs.GetInt(SCORE);
        var currentGameScore = 0;
        
        if (currentGameScore > currentMaxScore)
        {
            PlayerPrefs.SetInt(SCORE, currentGameScore);
        }
    }

    public void SetMenuScreenGameState()
    {
        gameState = GameState.MenuScreen;
    }

    public void SetGameScreenGameState()
    {
        gameState = GameState.GameScreen;
    }

    public void PauseGame()
    {
        _prevTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public enum GameState
    {
        MenuScreen,
        GameScreen,
    }

    public void Restart()
    {
        Time.timeScale = _prevTimeScale;
        Pool.pools = new Dictionary<PooledMonobehaviour, Pool>();
        SceneManager.LoadScene(SAMPLE_SCENE_NAME);
    }
}
