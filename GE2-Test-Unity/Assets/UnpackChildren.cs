using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        while (transform.childCount > 0)
        {
            transform.GetChild(0).parent = transform.parent;
        }
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
