using System;
using System.Collections.Generic;
using UnityEngine;


//ĳ���� �ִϸ����� ��Ʈ�ѷ� �ڵ�
public class CharacterMainController : MonoBehaviour
{
    /***********************************************************************
    *                               Definitions
    ***********************************************************************/
    #region .
    public enum CameraType { FpCamera, TpCamera };

    [Serializable]
    public class Components
    {
        public Camera tpCamera;
        public Camera fpCamera;

        [HideInInspector] public Transform tpRig;
        [HideInInspector] public Transform fpRoot;
        [HideInInspector] public Transform fpRig;

        [HideInInspector] public GameObject tpCamObject;
        [HideInInspector] public GameObject fpCamObject;

        [HideInInspector] public Rigidbody rBody;
        [HideInInspector] public Animator anim;
    }
    [Serializable]
    public class KeyOption
    {
        public KeyCode moveForward = KeyCode.W;
        public KeyCode moveBackward = KeyCode.S;
        public KeyCode moveLeft = KeyCode.A;
        public KeyCode moveRight = KeyCode.D;
        public KeyCode run = KeyCode.LeftShift;
        public KeyCode jump = KeyCode.Space;
        public KeyCode switchCamera = KeyCode.Tab;
        public KeyCode showCursor = KeyCode.LeftAlt;
    }
    [Serializable]
    public class MovementOption
    {
        [Range(1f, 10f), Tooltip("�̵��ӵ�")]
        public float speed = 3f;
        [Range(1f, 3f), Tooltip("�޸��� �̵��ӵ� ���� ���")]
        public float runningCoef = 1.5f;
        [Range(1f, 10f), Tooltip("���� ����")]
        public float jumpForce = 5.5f;
    }
    [Serializable]
    public class CameraOption
    {
        [Tooltip("���� ���� �� ī�޶�")]
        public CameraType initialCamera;
        [Range(1f, 10f), Tooltip("ī�޶� �����¿� ȸ�� �ӵ�")]
        public float rotationSpeed = 2f;
        [Range(-90f, 0f), Tooltip("�÷��ٺ��� ���� ����")]
        public float lookUpDegree = -60f;
        [Range(0f, 75f), Tooltip("�����ٺ��� ���� ����")]
        public float lookDownDegree = 75f;
    }
    [Serializable]
    public class AnimatorOption
    {
        public string paramMoveX = "Move X";
        public string paramMoveY = "Move Y";
        public string paramMoveZ = "Move Z";
    }
    [Serializable]
    public class CharacterState
    {
        public bool isCurrentFp;
        public bool isMoving;
        public bool isRunning;
        public bool isGrounded;
    }

    #endregion
    /***********************************************************************
    *                               Fields, Properties
    ***********************************************************************/
    #region .
    public Components Com => _components;
    public KeyOption Key => _keyOption;
    public MovementOption MoveOption => _movementOption;
    public CameraOption CamOption => _cameraOption;
    public AnimatorOption AnimOption => _animatorOption;
    public CharacterState State => _state;

    [SerializeField] private Components _components = new Components();
    [Space]
    [SerializeField] private KeyOption _keyOption = new KeyOption();
    [Space]
    [SerializeField] private MovementOption _movementOption = new MovementOption();
    [Space]
    [SerializeField] private CameraOption _cameraOption = new CameraOption();
    [Space]
    [SerializeField] private AnimatorOption _animatorOption = new AnimatorOption();
    [Space]
    [SerializeField] private CharacterState _state = new CharacterState();

    private Vector3 _moveDir;
    private Vector3 _worldMove;
    private Vector2 _rotation;

    #endregion

    /***********************************************************************
    *                               Unity Events
    ***********************************************************************/
    #region .
    private void Awake()
    {
        InitComponents();
        InitSettings();
    }

    #endregion
    /***********************************************************************
    *                               Init Methods
    ***********************************************************************/
    #region .
    private void InitComponents()
    {
        LogNotInitializedComponentError(Com.tpCamera, "TP Camera");
        LogNotInitializedComponentError(Com.fpCamera, "FP Camera");
        TryGetComponent(out Com.rBody);
        Com.anim = GetComponentInChildren<Animator>();

        Com.tpCamObject = Com.tpCamera.gameObject;
        Com.tpRig = Com.tpCamera.transform.parent;
        Com.fpCamObject = Com.fpCamera.gameObject;
        Com.fpRig = Com.fpCamera.transform.parent;
        Com.fpRoot = Com.fpRig.parent;
    }

    private void InitSettings()
    {
        // Rigidbody
        if (Com.rBody)
        {
            // ȸ���� Ʈ�������� ���� ���� ������ ���̱� ������ ������ٵ� ȸ���� ����
            Com.rBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        // Camera
        var allCams = FindObjectsOfType<Camera>();
        foreach (var cam in allCams)
        {
            cam.gameObject.SetActive(false);
        }
        // ������ ī�޶� �ϳ��� Ȱ��ȭ
        State.isCurrentFp = (CamOption.initialCamera == CameraType.FpCamera);
        Com.fpCamObject.SetActive(State.isCurrentFp);
        Com.tpCamObject.SetActive(!State.isCurrentFp);
    }

    #endregion
    /***********************************************************************
    *                               Checker Methods
    ***********************************************************************/
    #region .
    private void LogNotInitializedComponentError<T>(T component, string componentName) where T : Component
    {
        if (component == null)
            Debug.LogError($"{componentName} ������Ʈ�� �ν����Ϳ� �־��ּ���");
    }

    #endregion
    /***********************************************************************
    *                               Methods
    ***********************************************************************/
    #region .

    #endregion
}
