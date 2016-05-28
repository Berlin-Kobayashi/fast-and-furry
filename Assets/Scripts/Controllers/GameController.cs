using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SVGImporter;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{

    public Transform baseCat1;
    public Transform baseCat2;
    public Transform baseCat3;
    public Transform baseCat4;
    public Transform baseCat5;
    public Transform baseRat1;
    public Transform baseRat2;
    public Transform baseRat3;
    public Transform baseRat4;
    public Transform baseRat5;

    private Dictionary<String, Transform> playerMap;

    void Start()
    {
        playerMap = new Dictionary<string, Transform>();
    }

    public void spawnPlayer(string name)
    {
        Vector2 position = createRandomVisiblePosition();

        Transform player = null;

        int random = Random.Range(1, 6);

        switch (random)
        {
            case 1:
                if (GameObject.Find("cat (1)(Clone)") == null && GameObject.Find("cat (2)(Clone)") == null && GameObject.Find("cat (3)(Clone)") == null && GameObject.Find("cat (4)(Clone)") == null && GameObject.Find("cat (5)(Clone)") == null)
                {
                    player = (Transform)Instantiate(baseCat1, position, Quaternion.identity);
                }
                else
                {
                    player = (Transform)Instantiate(baseRat1, position, Quaternion.identity);
                }
                break;
            case 2:
                if (GameObject.Find("cat (1)(Clone)") == null && GameObject.Find("cat (2)(Clone)") == null && GameObject.Find("cat (3)(Clone)") == null && GameObject.Find("cat (4)(Clone)") == null && GameObject.Find("cat (5)(Clone)") == null)
                {
                    player = (Transform)Instantiate(baseCat2, position, Quaternion.identity);
                }
                else
                {
                    player = (Transform)Instantiate(baseRat2, position, Quaternion.identity);
                }
                break;
            case 3:
                if (GameObject.Find("cat (1)(Clone)") == null && GameObject.Find("cat (2)(Clone)") == null && GameObject.Find("cat (3)(Clone)") == null && GameObject.Find("cat (4)(Clone)") == null && GameObject.Find("cat (5)(Clone)") == null)
                {
                    player = (Transform)Instantiate(baseCat3, position, Quaternion.identity);
                }
                else
                {
                    player = (Transform)Instantiate(baseRat3, position, Quaternion.identity);
                }
                break;
            case 4:
                if (GameObject.Find("cat (1)(Clone)") == null && GameObject.Find("cat (2)(Clone)") == null && GameObject.Find("cat (3)(Clone)") == null && GameObject.Find("cat (4)(Clone)") == null && GameObject.Find("cat (5)(Clone)") == null)
                {
                    player = (Transform)Instantiate(baseCat4, position, Quaternion.identity);
                }
                else
                {
                    player = (Transform)Instantiate(baseRat4, position, Quaternion.identity);
                }
                break;
            case 5:
                if (GameObject.Find("cat (1)(Clone)") == null && GameObject.Find("cat (2)(Clone)") == null && GameObject.Find("cat (3)(Clone)") == null && GameObject.Find("cat (4)(Clone)") == null && GameObject.Find("cat (5)(Clone)") == null)
                {
                    player = (Transform)Instantiate(baseCat5, position, Quaternion.identity);
                }
                else
                {
                    player = (Transform)Instantiate(baseRat5, position, Quaternion.identity);
                }
                break;
        }


        playerMap.Add(name,player);

    }

    private Vector2 createRandomVisiblePosition()
    {
        int maxX = 10;
        int maxY = 4;

        return new Vector2(Random.Range(maxX * -1, maxX), Random.Range(maxY * -1, maxY));
    }

    public void movePlayer(string name, Vector2 direction)
    {
        Transform player = playerMap[name];
        player.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * 1000, ForceMode2D.Force);
    }
}