using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCheck : MonoBehaviour
{
    
    
    List<GameObject> b = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        
        b = FindObjectOfType<BoxesInPlace>().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            b.RemoveAt(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            b.Add(gameObject);
        }
    }
}
