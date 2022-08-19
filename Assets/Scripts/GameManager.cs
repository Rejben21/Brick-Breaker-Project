using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Ball ball { get; private set; }

    public Paddle paddle { get; private set; }

    public int level;
    public int score, lives = 3;

    public bool hasStarted = false;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;

        LoadLevel(1);
    }

    public void Miss()
    {
        lives--;
        if(lives > 0)
        {
            ResetLevel();
        }
        else if(lives <=0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        NewGame();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    public void ScoreUpdate()
    {
        score++;
    }
}
