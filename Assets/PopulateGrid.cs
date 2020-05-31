using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{


    public GameObject monster_tilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }


    void Populate()
    {
        GameObject newObj;

        for (int i = 0; i < 22; i++)
        {
            newObj = (GameObject)Instantiate(monster_tilePrefab, transform);
            newObj.GetComponent<Image>().color = Color.white;
        }

    }
}
