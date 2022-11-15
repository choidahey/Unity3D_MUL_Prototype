using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public Transform target;
    public float targetY;

    public float xRotMax;
    public float rotSpeed;
    public float scrollSpeed;

    public float distance;
    public float minDistance;
    public float maxDistance;

    private float xRot;
    private float yRot;
    private Vector3 targetPos;
    private Vector3 dir;

    private void Update()
    {
        xRot += Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        yRot += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        distance += -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        xRot = Mathf.Clamp(xRot, -xRotMax, xRotMax);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        targetPos = target.position + Vector3.up * targetY;

        dir = Quaternion.Euler(-xRot, yRot, 0f) * Vector3.forward;
        transform.position = targetPos + dir * -distance;
    }

    private void LateUpdate()
    {
        transform.LookAt(targetPos);
    }
}
