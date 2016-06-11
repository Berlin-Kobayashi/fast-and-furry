using UnityEngine;
using System.Collections;
using SVGImporter;
using System;

public class CatBehaviour : MonoBehaviour {

    private int prefabIndex;
    public float speed = 0.1f;
    private string name;

    // Use this for initialization
    void Start () {
	Debug.Log(name);
	}
	
	// Update is called once per frame
	void Update () {
        Controls();
    }

    public void setName(string name)
    {
        this.name = name;
    }

    private void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
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
