using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HA_TextUI : MonoBehaviour
{
    public GameObject linesObject;  // 텍스트를 담당할 게임 오브젝트 할당
    private TextMesh lines;         // 텍스트를 담당할 게임 오브젝트에서 필요한 컴포넌트 할당하는 용도

    private string[] diglogue;      // 출력할 자막의 내용을 저장하는 배열

    // 출력하는 자막의 순서를 조정하는 배열의 인덱스를 저장하는 변수
    // 이벤트별로 변수를 달리해야 할 듯 *다른 메소드에서 똑같은 변수를 사용할 경우, 초기화 위치가 애매함, 메소드 처음에 초기화를 하면 호출할 때마다 0으로 초기화 되기 때문에 인덱스 증가 안됨*
    private int countEvent4 = 0;

    private void Update()
    {
        lines = linesObject.GetComponent<TextMesh>(); // 텍스트 오브젝트의 TextMesh 컴포넌트를 찾아서 할당함
    }

    public void Event4()    // 이벤트별로 메소드 관리 -> 해당 메소드는 Event4번에 해당하는 자막을 출력하는 것으로, 시그널로 출력될 때마다 인덱스 번호가 +1 됨
    {
        diglogue = new string[] { "이게 무슨 소리지?", "학교에 또 누가 있는거 같은데", "TEST01" }; // 배열에 Event4에 필요한 대사를 배열에 저장
        lines.text = diglogue[countEvent4]; // TestMesh의 Text에 countEvent4번에 따른 배열의 인수를 넣음

        // start
        // 원래 linesObject는 투명 상태임 *비활성화 상태일 경우, 처음 활성화 될 때 이상한 값이 출력됨*
        // 대사가 출력될 때 linesObject를 불투명으로 바꾸는 과정이 필요함
        Color color = lines.color;
        color.a = 255f;
        lines.color = color;

        countEvent4++;  // 다음 대사 출력을 위해 countEvent4를 하나씩 증가시킴

        // 만약 자막이 일정 시간 경과 후 사라지길 원한다면
        // Invoke("LineOff", 3f);   // 3초 후 LineOff를 통해 자막이 투명해짐
    }

    public void LineOff()   // 해당 메소드를 이용해 자막을 투명하게 만듦 *자막의 활성화 여부를 본인이 조절하고 싶은 경우 사용하세요*
    {
        Color color = lines.color;
        color.a = 0f;
        lines.color = color;
    }
}
