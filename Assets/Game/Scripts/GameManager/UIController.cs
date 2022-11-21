using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject pointsText;
    private GameObject taskText;
    private GameObject timeText;
    private GameObject informationText;

    private GameObject mainMenuPanel;
    private GameObject plotPanel;

    void Start()
    {
        pointsText = GameObject.Find("PointsText");
        taskText = GameObject.Find("TaskText");
        timeText = GameObject.Find("TimeText");
        informationText = GameObject.Find("InformationText");

        mainMenuPanel = GameObject.Find("MainMenuPanel");
        plotPanel = GameObject.Find("PlotPanel");
    }

    public void ShowMainMenuPanel(GameState state = GameState.mainMenu)
    {
        mainMenuPanel.SetActive(true);
        if (state == GameState.mainMenu)
        {
            informationText.GetComponent<Text>().text = "";
        }
        else if (state == GameState.gameOver)
        {
            informationText.GetComponent<Text>().text = "You loose!";
        }
        else if (state == GameState.win)
        {
            informationText.GetComponent<Text>().text = "You escaped!";
        }
    }

    public void HidePanels()
    {
        mainMenuPanel.SetActive(false);
        plotPanel.SetActive(false);
    }

    public void ShowPlotPanel()
    {
        plotPanel.SetActive(true);
    }

    public void HideText()
    {
        taskText.GetComponent<TextMeshProUGUI>().text = "";
        pointsText.GetComponent<TextMeshProUGUI>().text = "";
        timeText.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void ShowPointsText(int points, int maxPointCount)
    {
        pointsText.GetComponent<TextMeshProUGUI>().text = "Keys: " + points + "/" + maxPointCount;
    }


    public void ShowTaskText(string currentObjectName)
    {
        taskText.GetComponent<TextMeshProUGUI>().text = "– Where is my " + currentObjectName + "?";
    }

    public void ShowTimerText(float time)
    {
        timeText.GetComponent<TextMeshProUGUI>().text = "– " + Mathf.RoundToInt(time).ToString() + "...";
    }
}
