using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SVGImporter;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Transform[] baseCats;
    public Transform[] baseRats;

    private Dictionary<String, Transform> playerMap;

    void Start()
    {
        playerMap = new Dictionary<string, Transform>();
    }

    public void spawnPlayer(string name)
    {
        Vector2 position = createRandomVisiblePosition();

        Transform player;

        if (doesCatExist())
        {
            int random = Random.Range(0, baseRats.Length);
            Transform randomRat = baseRats[random];
            player = (Transform)Instantiate(randomRat, position, Quaternion.identity);
        }
        else
        {
            int random = Random.Range(0, baseCats.Length);
            Transform randomCat = baseCats[random];
            player = (Transform)Instantiate(randomCat, position, Quaternion.identity);
        }
        
        playerMap.Add(name,player);
    }

    private Vector2 createRandomVisiblePosition()
    {
        int maxX = 10;
        int maxY = 4;

        return new Vector2(Random.Range(maxX * -1, maxX), Random.Range(maxY * -1, maxY));
    }

    private Boolean doesCatExist()
    {
        foreach (Transform cat in baseCats)
        {
            if (GameObject.Find(cat.name + "(Clone)") != null)
            {
                return true;
            }
        }

        return false;
    }

    public void movePlayer(string name, Vector2 direction)
    {
        Transform player = playerMap[name];
        player.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * 1000, ForceMode2D.Force);
    }
}