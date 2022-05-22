using UnityEngine;
using System.Collections;

public class MazeCamera_Action : MonoBehaviour
{

    //������ ���
    public Transform target;
    //ī�޶���� �Ÿ�   
    public float dist = 10f;

    //ī�޶� ȸ�� �ӵ�
    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;

    //ī�޶� �ʱ� ��ġ
    private float x = 15.0f;
    private float y = 15.0f;

    //y�� ����
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    //�ޱ��� �ּ�,�ִ� ����
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    // Use this for initialization
    void Start()
    {
        //Ŀ�� �����
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

    //Update is called once per frame
    void Update()
    {
        if (target)
        {
            //���콺 ��ũ�Ѱ��� �Ÿ����
            dist -= 1 * Input.mouseScrollDelta.y;

            //���콺 ��ũ��������� ī�޶� �Ÿ��� Min��Max
            if (dist < 0.5)
            {
                dist = 1;

            }

            if (dist >= 9)
            {
                dist = 9;
            }

            //ī�޶� ȸ���ӵ� ���
            x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

            //�ޱ۰� ���ϱ�
            //y���� Min�� MaX ���ָ� y���� 360�� ��� ��
            //x���� ��� ���� y���� ����
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //ī�޶� ��ġ ��ȭ ���
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0.0f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

            transform.rotation = rotation;
            transform.position = position;
            
            transform.LookAt(target.position);
        }

    }

    void LateUpdate()
    {

    }


}