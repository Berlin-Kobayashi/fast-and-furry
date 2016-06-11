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
    private int numberOfRats = 0;
    private Boolean running = false;

    void Start()
    {
        playerMap = new Dictionary<string, Transform>();
    }

    public void spawnPlayer(string name)
    {
        Transform player;

        if (doesCatExist())
        {
            Vector2 position = createRandomPosition(0,10,-4,4);
            int random = Random.Range(0, baseRats.Length);
            Transform randomRat = baseRats[random];
            player = (Transform)Instantiate(randomRat, position, Quaternion.identity);
            player.GetComponent<RatBehaviour>().setPrefabIndex(random);
        }
        else
        {
            Vector2 position = createRandomPosition(-10, 0, -4, 4);
            int random = Random.Range(0, baseCats.Length);
            Transform randomCat = baseCats[random];
            player = (Transform)Instantiate(randomCat, position, Quaternion.identity);
            player.GetComponent<CatBehaviour>().setPrefabIndex(random);
        }
        
        playerMap.Add(name,player);
    }

    public void deSpawnPlayer(string name)
    {
        Destroy(playerMap[name].gameObject);
    }

    private Vector2 createRandomPosition(int minX, int maxX , int minY, int maxY)
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
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
        if (running)
        {
        Transform player = playerMap[name];
            player.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * 1000, ForceMode2D.Force);
         //   player.transform.position = direction;
        }
    }

    public void setRunning(Boolean running)
    {
        this.running = running;

        GameObject.FindObjectOfType<SocketIOC>().socket.Emit("game-running", "");
    }
}