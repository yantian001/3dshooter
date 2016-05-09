using UnityEngine;
using CnControls;

public class TPSInput : MonoBehaviour
{

    public bool IsAim;

    public bool IsFirePressed;

    private bool _isMoveLeftPressed = false;
    /// <summary>
    /// 向左移动
    /// </summary>
    public bool IsMoveLeftPressed
    {
        get
        {
            return _isMoveLeftPressed;
        }
        private set
        {
            _isMoveLeftPressed = value;
            SetMoveState(_isMoveLeftPressed);
        }
    }


    private bool _isMoveRightPressed = false;
    /// <summary>
    /// 向右移动
    /// </summary>
    public bool IsMoveRightPressed
    {
        get
        {
            return _isMoveRightPressed;
        }
        private set
        {
            _isMoveRightPressed = value;
            SetMoveState(_isMoveRightPressed);
        }
    }
    /// <summary>
    /// 设置移动时的相关状态
    /// 1.不能瞄准
    /// 2.不能开枪
    /// </summary>
    /// <param name="b"></param>
    void SetMoveState(bool b)
    {
        if (b)
        {
            IsFirePressed = false;
            IsAim = false;
        }
    }

    public bool IsMoveing = false;

    public float horizontal = 0;
    public float vertical = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = CnInputManager.GetAxis("Horizontal");
        vertical = CnInputManager.GetAxis("Vertical");
        if (CnInputManager.GetButtonDown("Cover"))
        {
            IsAim = !IsAim;
        }
        IsFirePressed = CnInputManager.GetButton("F");
        if (IsFirePressed)
        {
            IsAim = true;
        }
        IsMoveLeftPressed = CnInputManager.GetButtonDown("Left");
        IsMoveRightPressed = CnInputManager.GetButtonDown("Right");
        //Debug.Log("Left: " + IsMoveLeftPressed + " R :" + IsMoveRightPressed);
    }


}
