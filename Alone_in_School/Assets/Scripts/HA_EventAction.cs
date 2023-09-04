using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HA_EventAction : MonoBehaviour
{
    public GameObject backMusic;
    public PlayableDirector EventplayableDirector;

    public void OnPointerEnter()
    {
        try
        {
            backMusic.SetActive(false);
            EventplayableDirector.Play();
        }
        catch (Exception e)
        {

        } 
    }
}