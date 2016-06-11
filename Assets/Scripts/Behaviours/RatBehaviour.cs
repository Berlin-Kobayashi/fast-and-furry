using UnityEngine;
using System.Collections;
using SVGImporter;
using System;

public class RatBehaviour : MonoBehaviour
{
    private int prefabIndex;
    GameObject[] leftRats;
    private string name;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPrefabIndex(int prefabIndex)
    {
        this.prefabIndex = prefabIndex;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void toCat()
    {
        Transform cat = GameObject.FindObjectOfType<GameController>().baseCats[this.prefabIndex];
        gameObject.AddComponent<CatBehaviour>();
        gameObject.tag = "Cat";
        gameObject.GetComponent<SVGRenderer>().vectorGraphics = cat.GetComponent<SVGRenderer>().vectorGraphics;
        Destroy(gameObject.GetComponent<RatBehaviour>());

        CheckIfWon();
    }

    private void CheckIfWon()
    {
      leftRats = GameObject.FindGameObjectsWithTag("Rat");
        if (leftRats.Length <= 1)
        {
            GameManager.instance.SwitchCanvas();
            GameManager.instance.StartCountdown();
            GameObject.FindObjectOfType<GameController>().setRunning(false);

        }
       
    }
}
