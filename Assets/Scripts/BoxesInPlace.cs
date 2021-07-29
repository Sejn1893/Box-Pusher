using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesInPlace : MonoBehaviour
{

    public List<GameObject> Boxes = new List<GameObject>();
    public GameObject YouWin;

    // Start is called before the first frame update
    void Start()
    {
        YouWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Boxes.Count == 0)
        {
            YouWin.SetActive(true);
        }
    }
   
}
