using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GE_CameraPositionChange : MonoBehaviour
{
    public GameObject cam;
    private Position camPos;

    // Start is called before the first frame update
    void Start()
    {
        camPos = cam.GetComponent<Position>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
