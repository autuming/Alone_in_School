using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트
    public AudioSource sound; // 3D 사운드의 AudioSource 컴포넌트
    public float maxAngle = 170f; // 최대 각도 (소리가 꺼지는 각도 임계값)
    public GameObject childObject; // 자식 오브젝트를 가리키는 변수

    private Material originalMaterial; // 자식 오브젝트의 원래 Material을 저장할 변수

    private void Start()
    {
        // 자식 오브젝트의 Renderer 컴포넌트를 가져옴
        Renderer childRenderer = childObject.GetComponent<Renderer>();

        // 자식 오브젝트의 Material을 가져와서 originalMaterial 변수에 저장
        originalMaterial = childRenderer.material;
    }

    private void Update()
    {
        // 플레이어와 오브젝트 사이의 방향을 계산
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // 플레이어의 시야 방향 벡터를 가져옴
        Vector3 playerForward = player.forward;

        // 플레이어가 오브젝트를 바라보는 방향 벡터와의 각도를 계산
        float angleToPlayer = Vector3.Angle(playerForward, directionToPlayer);

        Debug.Log(angleToPlayer);
        // 만약 플레이어가 오브젝트를 기준 각도(maxAngle) 이하로 바라보면 소리를 끔
        if (angleToPlayer > maxAngle)
        {
            sound.volume = 0f;

            // 자식 오브젝트의 Material의 alpha 값을 0으로 설정하여 투명하게 만듦
            Color materialColor = originalMaterial.color;
            materialColor.a = 0f;
            childObject.GetComponent<Renderer>().material.color = materialColor;
        }
        //else
        //{
        //    sound.volume = 1f;

        //    // 자식 오브젝트의 Material의 alpha 값을 원래 상태로 복원
        //    childObject.GetComponent<Renderer>().material = originalMaterial;
        //}
    }
}