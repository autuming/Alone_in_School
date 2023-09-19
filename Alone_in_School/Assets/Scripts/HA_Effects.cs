using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 작성일 :   2023-08-13 일요일
/// 작성자 :   정현아 작성
/// 
/// ==설명==
/// StartScene, BeforeScene, MainScene, EndScene 마다 MainCamera에 부착된 스크립트
/// 필요에 따라 BlackOut 효과를 내거나 게임을 StartScene OR BeforeScene으로 이동 및 종료시킨다 
/// </summary>

public class HA_Effects : MonoBehaviour
{
    public GameObject blackCubes;   // BlackOut 효과를 위해 배치한 검은 큐브들을 할당하는 변수

    private void Update()   // 해당 부분은 논의가 필요, 만약 모든 씬에서 해당 키를 누르면 게임이 종료되거나 씬이 이동됨, 유용할 수 있지만 실수로 누를 가능성도 있음
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("BeforeScene");
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void BlackOutOn()
    {
        blackCubes.SetActive(true);
    }

    public void BlackOutOff()
    {
        blackCubes.SetActive(false);
    }
}
