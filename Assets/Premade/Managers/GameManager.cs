using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string SCORE = "Score";
    private const string SAMPLE_SCENE_NAME = "SampleScene";
    private string saveScore = "ScoreSaved";

    public static GameManager Instance;
    public CameraManager CameraManager;
    public GameEventsSystem GameEventsSystem;
    public CardsManager CardManager;
    public Canvas canvas;
    [SerializeField] public MoneyManager MoneyManager;
    private bool isFlagGameOver = false;
    float _prevTimeScale = 1;

    private void Awake()
    {
        Instance = this;
        
        SetupSystems();
        StartCoroutine(Wait10Sec());
    }

    private IEnumerator Wait10Sec()
    {
        yield return new WaitForSeconds(10);
        CardManager.GenerateRandomCard();
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
        Time.timeScale = 1;
        Pool.pools = new Dictionary<PooledMonobehaviour, Pool>();
        SceneManager.LoadScene(SAMPLE_SCENE_NAME);
        Debug.Log("Restart");
    }

    public void GameOver()
    {
        if (!isFlagGameOver)
        {
            isFlagGameOver = true;
            Time.timeScale = 0;
            canvas.GetComponent<Animator>().SetBool("GameOver", true);
            SaveHighScore();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

}
