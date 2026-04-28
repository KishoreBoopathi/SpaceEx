using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmovement : MonoBehaviour
{
    public float backgroundSize;
    Transform cameraT;
    Transform[] layers;
    int bottomIndex;
    int topIndex;
    public float scrollSpeed = -.5f;
    float viewzone = 22;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraT = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        bottomIndex = 0;
        topIndex = layers.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed* Time.deltaTime;

        if(cameraT.position.y>(layers[topIndex].transform.position.y +viewzone))
        Scroll();
    }
    void Scroll()
    {
        //Debug.Log("continue");
        int lastTop = topIndex;
        layers[topIndex].position = Vector3.up *(layers[bottomIndex].position.y + backgroundSize);
        bottomIndex = topIndex;
        topIndex--;
        if (topIndex < 0)
            topIndex = layers.Length - 1;
    }
       
}
