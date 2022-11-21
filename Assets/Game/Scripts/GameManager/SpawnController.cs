using System;
using UnityEngine;
using Random = System.Random;

public class SpawnController : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] keys;
    public GameObject furniture;



    public int minItemsCount = 7;
    public int maxItemsCount = 10;

    private GameObject[] randomItems = {};
    private GameObject[] randomKeys = {};

    private static Vector3[] positions = {
        new Vector3(27.25f, 0.25f, 8.75f),
        new Vector3(27.5f, 0.56f, 7.5f),
        new Vector3(25f, 1f, 11.4f),
        new Vector3(24.75f, 0.2f, 9f),
        new Vector3(29.5f, 0.2f, 6.75f),
        new Vector3(29.25f, 0.2f, 0.75f),
        new Vector3(29.25f, 0.2f, 3.25f),
        new Vector3(22.25f, 0.05f, 1f),
        new Vector3(22.3f, 0.05f, 3f),
        new Vector3(22.5f, 0.5f, 7.5f),
        new Vector3(22.5f, 0.95f, 6.75f),
        new Vector3(23.25f, 0.95f, 7.5f),
        new Vector3(24.5f, 0.05f, 5f),
        new Vector3(27f, 0.05f, 5.75f),
        new Vector3(22.75f, 1f, 3.25f),
        new Vector3(23.5f, 1f, 3.45f),
        new Vector3(24.45f, 1f, 3.2f),
        new Vector3(24.5f, 1f, 3.75f),
        new Vector3(22.9f, 0.9f, 0.45f),
        new Vector3(23.7f, 0.9f, 0.5f),
        new Vector3(23.6f, 0.18f, 0.55f),
        new Vector3(23f, 0.18f, 0.55f),
        new Vector3(23.15f, 1.52f, 0.55f),
        new Vector3(23.8f, 1.52f, 0.55f),
    };

    public int itemsLength
    {
        get => randomItems.Length;
    }

    private GameController gameController;


    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }


    void SpawnItemsAndKeys()
    {
        Random rand = new Random();
        int itemsCount = rand.Next(minItemsCount, maxItemsCount + 1);

        //var keysCount = gameController.maxPointsCount;
        var keysCount = 5;

        Vector3[] randomPositions = new Vector3[itemsCount + keysCount];
        randomKeys = new GameObject[keysCount];
        randomItems = new GameObject[itemsCount];

        for (int i = 0; i < itemsCount + keysCount; i++)
        {
            int r = rand.Next(0, positions.Length);
            if (!Array.Exists(randomPositions, a => a == positions[r]))
            {
                randomPositions[i] = positions[r];
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < itemsCount; i++)
        {
            int r = rand.Next(0, items.Length);
            if (!Array.Exists(randomItems, a => a == items[r]))
            {
                randomItems[i] = items[r];
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < keysCount; i++)
        {
            int r = rand.Next(0, keys.Length);
            randomKeys[i] = keys[r];
        }


        for (int i = 0; i < itemsCount; i++)
        {
            Instantiate(randomItems[i], randomPositions[i], randomItems[i].transform.rotation);
        }

        for (int i = 0; i < keysCount; i++)
        {
            Instantiate(randomKeys[i], randomPositions[itemsCount + i], randomKeys[i].transform.rotation);
        }
    }


    public void SpawnAll()
    {
        SpawnItemsAndKeys();
        Instantiate(furniture, furniture.transform.position, furniture.transform.rotation);
    }

    public void RemoveAll()
    {
        GameObject[] furniture = GameObject.FindGameObjectsWithTag("Furniture");
        foreach (GameObject part in furniture) Destroy(part);

        GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
        foreach (GameObject key in keys) Destroy(key);

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items) Destroy(item);
    }


    public string ObjectName(int currentItemIndex)
    {
        return currentItemIndex >= itemsLength ? "" : randomItems[currentItemIndex].GetComponent<ItemCollisionController>().objectName;
    }
}