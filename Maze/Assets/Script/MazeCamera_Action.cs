using System.Collections.Generic;
using UnityEngine;

public class MazeCamera_Action : MonoBehaviour
{

    private Transform m_currentTarget = null;
    private float m_distance = 25.0f;
    private float m_height = 15.0f;
    private float m_lookAtAroundAngle = 0;
    
    //내가 수정한 부분
    public Transform targetTransform;
    public float dampTrace = 5.0f; //부드러운 추적위한 변수,,?
    private Transform transform;  //카메라 자시의 transform 컴포넌트


    [SerializeField] private List<Transform> m_targets = null;
    private int m_currentIndex = 0;

    private void Start()
    {
        if (m_targets.Count > 0)
        {
            m_currentIndex = 0;
            m_currentTarget = m_targets[m_currentIndex];

            transform = GetComponent<Transform>();
        }
    }

    private void SwitchTarget(int step)
    {
        if (m_targets.Count == 0) { return; }
        m_currentIndex += step;
        if (m_currentIndex > m_targets.Count - 1) { m_currentIndex = 0; }
        if (m_currentIndex < 0) { m_currentIndex = m_targets.Count - 1; }
        m_currentTarget = m_targets[m_currentIndex];
    }

    public void NextTarget() { SwitchTarget(1); }
    public void PreviousTarget() { SwitchTarget(-1); }

    private void Update()
    {
        if (m_targets.Count == 0) { return; }
    }

    private void LateUpdate()
    {
        if (m_currentTarget == null) { return; }

        float targetHeight = m_currentTarget.position.y + m_height;
        float currentRotationAngle = m_lookAtAroundAngle;

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        Vector3 position = m_currentTarget.position;
        position -= currentRotation * Vector3.forward * m_distance;
        position.y = targetHeight;

        //transform.position = position;
        //transform.LookAt(m_currentTarget.position + new Vector3(0, m_height, 0));

        transform.position = Vector3.Lerp(transform.position, targetTransform.position - (targetTransform.forward * m_distance) + (Vector3.up * m_height),
            Time.deltaTime * dampTrace);
        transform.LookAt(targetTransform.position);
    }
    
}
