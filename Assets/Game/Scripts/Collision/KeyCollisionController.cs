using Oculus.Platform.Samples.VrBoardGame;
using TMPro;
using UnityEngine;

public class KeyCollisionController : MonoBehaviour
{
    public AudioClip coinSound;

    private GameObject player;
    private GameController gameController;

    private float minDist = 1.25f;

    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        player = GameObject.Find("Player");
    }

    public void Update()
    {
        if (gameController.isGameProcessing)
        {
            var dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < minDist && (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Q)))
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
                gameController.AddPoint();
            }
        }
    }
}

