using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target; //ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;

    public Transform targetTransform;
    public float dist = 20.0f; //player�� transform ������Ʈ
    public float height = 15.0f; //player���� ����
    public float dampTrace = 1.0f; //�ε巯�� �������� ����,,?

    public float min = -20f; //y �ּ� ����
    public float max = 20f; //y �ִ� ����

    private Transform transform;  //ī�޶� �ڽ��� transform ������Ʈ

    public float CameraSpeed = 10.0f;
    Vector3 offset; //Ÿ�� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - Target.transform.position;
        transform = GetComponent<Transform>();
    }
    private void LateUpdate() //�÷��̾� �̵��� ���� �� ī�޶� �̵��ϱ� ���� lateupdate ���
    {
        //���� ���� �����ִ� �Լ� �̿��ؼ� ī�޶� ��ġ ����
        transform.position = Vector3.Lerp(transform.position, targetTransform.position - (targetTransform.forward * dist) + (Vector3.up * height),
            Time.deltaTime * dampTrace);

        //ī�޶� Ÿ��(�÷��̾�)�� �ٶ� �� �ְ� ����
        transform.LookAt(targetTransform.position);
    }


    //Update�� �޸� �����ӿ� ������� ���� == �����Ÿ��� ���� ����
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