using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target; //카메라가 따라다닐 타겟

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;

    public Transform targetTransform;
    public float dist = 20.0f; //player의 transform 컴포넌트
    public float height = 15.0f; //player와의 높이
    public float dampTrace = 1.0f; //부드러운 추적위한 변수,,?

    public float min = -20f; //y 최소 각도
    public float max = 20f; //y 최대 각도

    private Transform transform;  //카메라 자시의 transform 컴포넌트

    public float CameraSpeed = 10.0f;
    Vector3 offset; //타겟 위치

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - Target.transform.position;
        transform = GetComponent<Transform>();
    }
    private void LateUpdate() //플레이어 이동이 끝난 후 카메라 이동하기 위해 lateupdate 사용
    {
        //선형 보간 시켜주는 함수 이용해서 카메라 위치 지정
        transform.position = Vector3.Lerp(transform.position, targetTransform.position - (targetTransform.forward * dist) + (Vector3.up * height),
            Time.deltaTime * dampTrace);

        //카메라가 타켓(플레이어)를 바라볼 수 있게 설정
        transform.LookAt(targetTransform.position);
    }


    //Update와 달리 프레임에 영향받지 않음 == 버벅거리는 현상 보정
    void FixedUpdate()
    {
        //transform.position = Target.transform.position + offset;
    }

    private Quaternion ClampRotationY(Quaternion quat)
    {
        quat.x /= quat.x;
        quat.y /= quat.y;
        quat.z /= quat.z;

        quat.y = 0.0f;

        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(quat.y);
        angleY = Mathf.Clamp(angleY, min, max);

        return quat;
    }
}