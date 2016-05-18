using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameStatu statu = GameStatu.Init;
    public void OnEnable()
    {
        LeanTween.addListener((int)Events.TIMEUP, OnTimeUp);
        LeanTween.addListener((int)Events.ENEMYCLEARED, OnEnemyCleared);
    }

    public void OnDisable()
    {
        LeanTween.removeListener((int)Events.TIMEUP, OnTimeUp);
        LeanTween.removeListener((int)Events.ENEMYCLEARED, OnEnemyCleared);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region custom method
    void OnTimeUp(LTEvent evt)
    {

    }

    void OnEnemyCleared(LTEvent evt)
    {
        
    }

    /// <summary>
    /// 更改游戏状态
    /// </summary>
    /// <param name="s"></param>
    void ChangeGameStatu(GameStatu s)
    {
        statu = s;
        GameValue.staus = statu;
        
    }
    #endregion
}
