using UnityEngine;

public class FadeController : MonoBehaviour
{
    public Material sphereMaterial;

    private FadeState fadeState;

    private GameObject player;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Color color = sphereMaterial.color;
        if (fadeState == FadeState.fadeIn)
        {
            if (color.a < 1.0)
            {
                color.a += 0.4f * Time.deltaTime;
                sphereMaterial.color = color;
                if (color.a >= 1.0)
                {
                    gameController.AfterFadeIn();
                    FadeOut();
                }
            }
        } else if (fadeState == FadeState.fadeOut)
        {
            if (color.a > 0.0)
            {
                color.a -= 0.4f * Time.deltaTime;
                sphereMaterial.color = color;
                if (color.a <= 0.0)
                {
                    Destroy(gameObject);
                }

            }
        }

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.up / 2;
    }

    public void FadeInAndFadeOut()
    {
        Debug.Log("start fade in");
        fadeState = FadeState.fadeIn;
        Color color = sphereMaterial.color;
        color.a = 0;
        sphereMaterial.color = color;
    }

    private void FadeOut()
    {
        Debug.Log("start fade out");
        fadeState = FadeState.fadeOut;
        Debug.Log(fadeState);
        Color color = sphereMaterial.color;
        color.a = 1;
        sphereMaterial.color = color;
    }
}

enum FadeState
{
    fadeIn,
    fadeOut,
}