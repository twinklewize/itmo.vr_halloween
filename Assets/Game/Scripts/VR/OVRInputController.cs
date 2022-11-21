using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OVRInputController : MonoBehaviour
{
    public OVRTrackedKeyboard trackedKeyboard;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        trackedKeyboard.TrackingEnabled = true;
    }

    public void StartGame()
    {
        trackedKeyboard.Presentation = OVRTrackedKeyboard.KeyboardPresentation.PreferOpaque;
        gameController.StartGame();
    }

    public void QuitGame()
    {
        gameController.QuitGame();
    }
}
