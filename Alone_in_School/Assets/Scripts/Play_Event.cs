using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

/* 
 * 작성일  :   2023-07-25 화요일
 * 작성자  :   이가을 작성
 * 
 * ==설명==
 * 각 객체에 생성된 타임라인 이벤트를 모아
 * 한번에 관리하고 재생하는 스크립트입니다.
 */

/// <summary>
/// 작성일 :   2023-08-11 금요일
/// 작성자 :   정현아 작성
/// 
/// ==설명==
/// 수정 1. Evnet 관련 스크립트를 하나로 통합
/// 수정 2. GetKey -> GetKeyDown으로 변경
/// 추가 1. 이벤트 1회 재생으로 제한함
/// 추가 2. 이벤트가 모두 1회 출력되었을 때 자동으로 EndSCene으로 이동함
/// </summary>

public class Play_Event : MonoBehaviour
{
    public GameObject Event1;   // Event 1, 게임 오브젝트 할당 변수
    public GameObject Event2;   // Event 2, 게임 오브젝트 할당 변수
    public GameObject Event3;   // Event 3, 게임 오브젝트 할당 변수
    public GameObject Event4;   // Event 4, 게임 오브젝트 할당 변수
    public GameObject Event5;   // Event 5, 게임 오브젝트 할당 변수
    private PlayableDirector Event1playableDirector;    // Event 1, 게임 오브젝트 내 PlayableDirector 컴포넌트를 저장할 변수
    private PlayableDirector Event2playableDirector;    // Event 2, 게임 오브젝트 내 PlayableDirector 컴포넌트를 저장할 변수
    private PlayableDirector Event3playableDirector;    // Event 3, 게임 오브젝트 내 PlayableDirector 컴포넌트를 저장할 변수
    private PlayableDirector Event4playableDirector;    // Event 4, 게임 오브젝트 내 PlayableDirector 컴포넌트를 저장할 변수
    private PlayableDirector Event5playableDirector;    // Event 5, 게임 오브젝트 내 PlayableDirector 컴포넌트를 저장할 변수

    private bool[] IsEventCall = new bool[5];   // 이벤트가 1회 호출되었는지 판단하기 위해 bool 형태의 배열을 선언
    private int eventCount; // 모든 이벤트가 호출되었는지 확인하기 위해 정수형 변수를 선언

    void Start()
    {
        // 객체 내 PlayableDirector 할당
        Event1playableDirector = Event1.GetComponent<PlayableDirector>();
        Event2playableDirector = Event2.GetComponent<PlayableDirector>();
        Event3playableDirector = Event3.GetComponent<PlayableDirector>();
        Event4playableDirector = Event4.GetComponent<PlayableDirector>();
        Event5playableDirector = Event5.GetComponent<PlayableDirector>();
    }

    void Update()
    {
        switch (Input.inputString)
        {
            case "a":
                // 복도에서...
                if (IsEventCall[0] == false)
                {
                    Event1playableDirector.Play();
                    IsEventCall[0] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
                }
                Invoke("IsEventAllDone", (float)Event1playableDirector.duration);    // (float)Event1playableDirector.duration == 이벤트 총 재생시간, IsEventAllDone 메소드를 호출함
                break;

            case "s":
                // 누군가의 생일 파티
                IsEventCall[1] = true;
                break;

            case "d":
                // 옆자리 친구
                if (IsEventCall[2] == false)
                {
                    Event3playableDirector.Play();
                    IsEventCall[2] = true;  // 1회 호출되었기에 0번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
                }
                Invoke("IsEventAllDone", (float)Event3playableDirector.duration);    // (float)Event3playableDirector.duration == 이벤트 총 재생시간, 이벤트가 끝나면  IsEventAllDone 메소드를 호출함
                break;

            case "f":
                // 귀신의 방문
                if (IsEventCall[3] == false)
                {
                    Event4playableDirector.Play();
                    IsEventCall[3] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
                }
                Invoke("IsEventAllDone", (float)Event4playableDirector.duration);    // (float)Event4playableDirector.duration == 이벤트 총 재생시간, IsEventAllDone 메소드를 호출함
                break;

            case "g":
                // 밤 중의 발소리
                if (IsEventCall[4] == false)
                {
                    Event5playableDirector.Play();
                    IsEventCall[4] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
                }
                Invoke("IsEventAllDone", (float)Event5playableDirector.duration);    // (float)Event5playableDirector.duration == 이벤트 총 재생시간, 이벤트가 끝나면 IsEventAllDone 메소드를 호출함
                break;

            default:

                break;
        }

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    if (IsEventCall[3] == false)
        //    {
        //        Event1playableDirector.Play();
        //        IsEventCall[3] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
        //    }
        //    // Invoke("IsEventAllDone", 30.0f);    // 20.7초 딜레이 후(Event 5번이 완료하는데 걸리는 시간) IsEventAllDone 메소드를 호출함
        //}

        //if (Input.GetKeyDown(KeyCode.A)) 
        //{
        //    if (IsEventCall[0] == false)
        //    {
        //        Event3playableDirector.Play(); // ==> 타임라인 이벤트 재생
        //        IsEventCall[0] = true;  // 1회 호출되었기에 0번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
        //    }
        //    // Invoke("IsEventAllDone", 20.0f);    // 13초 딜레이 후(Event 3번이 완료하는데 걸리는 시간) IsEventAllDone 메소드를 호출함
        //}

        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    if (IsEventCall[1] == false)
        //    {
        //        Event4playableDirector.Play();
        //        IsEventCall[1] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
        //    }
        //    // Invoke("IsEventAllDone", 22.0f);    // 22초 딜레이 후(Event 4번이 완료하는데 걸리는 시간) IsEventAllDone 메소드를 호출함
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    if (IsEventCall[2] == false)
        //    {
        //        Event5playableDirector.Play();
        //        IsEventCall[2] = true;  // 1회 호출되었기에 1번 인덱스의 값을 true로 저장함 => 추후 각 이벤트 번호에 맞는 인덱스 할당할 예정
        //    }
        //    // Invoke("IsEventAllDone", 20.7f);    // 20.7초 딜레이 후(Event 5번이 완료하는데 걸리는 시간) IsEventAllDone 메소드를 호출함
        //}
    }

    private void IsEventAllDone()   // 모든 이벤트가 호출되었는지 판단하는 메소드
    {
        eventCount = 0;

        for(int i = 0; i < IsEventCall.Length; i++) // 각 이벤트마다 1회 호출되었는지 판단하는 배열에 담겨있는 원소의 값을 비교하는 조건문
        {
            if (IsEventCall[i]) // 만약 원소의 값이 true라면, 즉 1회 호출되었다면 eventCount 수를 1씩 증가
            {
                eventCount++;
            }
        }

        if (eventCount >= IsEventCall.Length)    // eventCount가 씬 내 배치된 이벤트 수와 같거나 크다면, 게임을 종료하기 위해 EndScene으로 이동
        {
            SceneManager.LoadScene("EndScene");
        }
        else
            Debug.Log("이벤트 남아있음");  // 디버깅을 위해 넣은 로그로 추후 삭제 예정
    }
}
