using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour
{

    public Transform baseCat;

    public void spawnCat(string name, string color, Vector2 position)
    {
        Debug.Log("sadsad");
        Instantiate(baseCat, position, Quaternion.identity);
    }

}