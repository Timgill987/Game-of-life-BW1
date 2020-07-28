using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cell : MonoBehaviour
{
    public bool Dead { get; set; }

    public void colChange(Color c)
    {
        // set color my image
        gameObject.GetComponent<Image>().color = c;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
