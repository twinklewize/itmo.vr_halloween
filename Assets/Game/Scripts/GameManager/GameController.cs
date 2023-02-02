using Oculus.Platform.Samples.VrBoardGame;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isTestMode;
    public int maxPointsCount = 5;
    public GameObject blackSphere;

    private int points;
    private int currentItemIndex;
    private GameState gameState;

    private GameObject player;
    private SpawnController spawnController;
    private UIController uiController;
    private TimeController timeController;
    private FadeController fadeController;

    public bool isGameProcessing
    {
        get => gameState == GameState.processing;
    }

    public string currentObjectName
    {
        get => spawnController.ObjectName(currentItemIndex);
    }

    void Start()
    {
        var gameManager = GameObject.Find("GameManager");
        spawnController = gameManager.GetComponent<SpawnController>();
        uiController = gameManager.GetComponent<UIController>();
        timeController = gameManager.GetComponent<TimeController>();
        player = GameObject.Find("Player");
        gameState = GameState.mainMenu;
        if (isTestMode)
        {
            StartGame();
        }
    }

    void Update()
    {
        if (isGameProcessing)
        {
            if (timeController.timerValue > 0)
            {
                uiController.ShowTimerText(timeController.timerValue);
            }
            else
            {
                GameOver();
            }
        }
    }

    private void Win()
    {
        if (isGameProcessing)
        {
            gameState = GameState.win;
            EndGame();
        }
    }


    private void GameOver()
    {
        if (isGameProcessing)
        {
            gameState = GameState.gameOver;
            EndGame();
        }
    }

    private void EndGame()
    {
        uiController.HideText();
        timeController.ResetTimer();
        currentItemIndex = -1;

        Instantiate(blackSphere, player.transform.position + Vector3.up, blackSphere.transform.rotation);
        fadeController = blackSphere.GetComponent<FadeController>();
        fadeController.FadeInAndFadeOut();
    }


    public void StartGame()
    {
        points = 0;
        currentItemIndex = -1;
        uiController.HidePanels();
        uiController.ShowPointsText(points, maxPointsCount);
        spawnController.SpawnAll();
        NextItem();
        gameState = GameState.processing;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void AddPoint()
    {
        points++;
        uiController.ShowPointsText(points, maxPointsCount);
        if (points == maxPointsCount)
        {
            Win();
        }
    }

    public void NextItem()
    {
        currentItemIndex++;
        if (currentItemIndex >= spawnController.itemsLength)
        {
            GameOver();
            return;
        }
        timeController.StartTimer();
        uiController.ShowTaskText(currentObjectName);
    }

    public void AfterFadeIn()
    {

        uiController.ShowMainMenuPanel(gameState);
        spawnController.RemoveAll();
    }
}

public enum GameState
{
    mainMenu,
    processing,
    gameOver,
    win,
}