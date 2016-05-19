using UnityEngine;
using CnControls;

public class TPSInput : MonoBehaviour
{

    public bool IsAim;

    public bool IsFirePressed;

    private bool _canFire;

    public bool InputEable = false;
    /// <summary>
    /// 是否可以开枪
    /// </summary>
    public bool CanFire
    {
        get
        {
            return _canFire;
        }
        set
        {
            _canFire = value;
            if (!_canFire)
            {
                IsFirePressed = false;
            }
        }
    }

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
        set
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
        set
        {
            _isMoveRightPressed = value;
            SetMoveState(_isMoveRightPressed);
        }
    }

    private bool _reload = false;
    /// <summary>
    /// 换子弹
    /// </summary>
    public bool Reload
    {
        get
        {
            return _reload;
        }
        set
        {
            _reload = value;
            if (_reload)
            {
                IsAim = false;
                CanFire = false;
            }
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
            CanFire = false;
            IsFirePressed = false;
            IsAim = false;
        }
    }

    public bool IsMoveing = false;

    public float horizontal = 0;
    public float vertical = 0;

    // Update is called once per frame
    void Update()
    {
        if(GameValue.staus != GameStatu.InGame || !gameObject.activeInHierarchy)
        {
            InputEable = false;
        }
        if (InputEable)
        {
            horizontal = CnInputManager.GetAxis("Horizontal");
            vertical = CnInputManager.GetAxis("Vertical");
            if (CnInputManager.GetButtonDown("Cover"))
            {
                IsAim = !IsAim;
            }
            if (CnInputManager.GetButtonDown("Reload"))
            {
                Reload = true;
            }
            if (CanFire)
            {
                IsFirePressed = CnInputManager.GetButton("F");
                if (IsFirePressed)
                {
                    IsAim = true;
                }
            }
            //判读移动
            if (CnInputManager.GetButtonDown("Left"))
            {
                IsMoveLeftPressed = true;
            }
            else if (CnInputManager.GetButtonDown("Right"))
            {
                IsMoveRightPressed = true;
            }
        }
        else
        {
            IsAim = false;
            IsFirePressed = false;
            IsMoveLeftPressed = false;
            IsMoveRightPressed = false;

        }
    }
   
}
