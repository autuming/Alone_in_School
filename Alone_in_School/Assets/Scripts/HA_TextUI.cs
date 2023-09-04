using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class HA_TextUI : MonoBehaviour
{
    public GameObject linesObject;  // 텍스트를 담당할 게임 오브젝트 할당
    private TextMesh lines;         // 텍스트를 담당할 게임 오브젝트에서 필요한 컴포넌트 할당하는 용도

    private string[] diglogue;      // 출력할 자막의 내용을 저장하는 배열

    // 출력하는 자막의 순서를 조정하는 배열의 인덱스를 저장하는 변수
    // 이벤트별로 변수를 달리해야 할 듯 *다른 메소드에서 똑같은 변수를 사용할 경우, 초기화 위치가 애매함, 메소드 처음에 초기화를 하면 호출할 때마다 0으로 초기화 되기 때문에 인덱스 증가 안됨*
    private int countEvent0 = 0;
    private int countEvent4 = 0;

    private void Start()
    {
        lines = linesObject.GetComponent<TextMesh>(); // 텍스트 오브젝트의 TextMesh 컴포넌트를 찾아서 할당함
    }

    public void TextEvent0()
    {
        diglogue = new string[] { "...졸리다", "한 숨 자고 싶은데", "수업까지 시간이 남았으니 좀 자볼까...", "(책상에 엎드려 잠을 잔다)" };
        lines.text = diglogue[countEvent0];

        Color color = lines.color;
        color.a = 255f;
        lines.color = color;

        countEvent0++;
    }

    public void LineOff()   // 해당 메소드를 이용해 자막을 투명하게 만듦 *자막의 활성화 여부를 본인이 조절하고 싶은 경우 사용하세요*
    {
        Color color = lines.color;
        color.a = 0f;
        lines.color = color;
    }
}
