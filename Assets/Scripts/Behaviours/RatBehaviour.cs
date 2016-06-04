using UnityEngine;
using System.Collections;
using SVGImporter;

public class RatBehaviour : MonoBehaviour
{
    private int prefabIndex;

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

    public void toCat()
    {
        Transform cat = GameObject.FindObjectOfType<GameController>().baseCats[this.prefabIndex];
        gameObject.AddComponent<CatBehaviour>();
        gameObject.tag = "Cat";
        gameObject.GetComponent<SVGRenderer>().vectorGraphics = cat.GetComponent<SVGRenderer>().vectorGraphics;
        Destroy(gameObject.GetComponent<RatBehaviour>());
    }

}
