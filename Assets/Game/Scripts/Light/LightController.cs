using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private float dist;

    const int maxdist = 10;
    const int maxIntensity = 2;
    const int minDist = 2;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (dist >= maxdist)
        {
            gameObject.GetComponent<Light>().intensity = 0;
        }
        else if (dist <= minDist)
        {
            gameObject.GetComponent<Light>().intensity = maxIntensity;
        }
        else
        {
            gameObject.GetComponent<Light>().intensity = maxIntensity * (maxdist - dist) / (maxdist - minDist);
        }

    }
}
