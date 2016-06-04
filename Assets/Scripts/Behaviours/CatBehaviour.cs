using UnityEngine;
using System.Collections;
using SVGImporter;

public class CatBehaviour : MonoBehaviour {

    private int prefabIndex;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rat"))
        {
           other.gameObject.GetComponent<RatBehaviour>().toCat();
        }
    }

    public void setPrefabIndex(int prefabIndex)
    {
        this.prefabIndex = prefabIndex;
    }
}
