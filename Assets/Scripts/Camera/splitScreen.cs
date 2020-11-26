using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitScreen : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1.rect = new Rect(0, 0, .5f, 1);
        cam2.rect = new Rect(0.5f, 0, 0.52f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
