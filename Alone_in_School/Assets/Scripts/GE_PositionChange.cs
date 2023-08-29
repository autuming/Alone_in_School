using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GE_PositionChange : MonoBehaviour
{
    public void MoveCamera()
    {
        transform.position = new Vector3(-2.884f, 4.008f, -16.96f);
    }

    public void ReturnCamera()
    {
        transform.position = new Vector3(-7.62f, 4.008f, -16.96f);
    }

    public void MoveGhost()
    {
        transform.position += new Vector3(0.0f, 0.0f, -10.00f); 
    }
}
