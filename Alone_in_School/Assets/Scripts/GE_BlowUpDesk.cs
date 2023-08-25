using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GE_BlowUpDesk : MonoBehaviour
{

    public GameObject blowObject;
    private Rigidbody objectRigid; 

    public float power;

    // Start is called before the first frame update
    void Start()
    {
        objectRigid = blowObject.GetComponent<Rigidbody>();
        objectRigid.AddForce((transform.up + transform.forward) * power);
    }  
}
