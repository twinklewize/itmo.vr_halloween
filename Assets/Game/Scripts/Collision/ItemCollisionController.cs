using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollisionController : MonoBehaviour
{
    public string objectName;
    public AudioClip itemSound;

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
            if (gameController.currentObjectName == objectName)
            {
                var dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist < minDist && (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Q)))
                {
                    AudioSource.PlayClipAtPoint(itemSound, transform.position);
                    Destroy(gameObject);
                    gameController.NextItem();
                }
            }
        }
    }
}