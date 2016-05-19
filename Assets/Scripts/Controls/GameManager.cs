using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    #region variable
    public GameStatu statu = GameStatu.Init;
    public GameRecords record = new GameRecords();
    public int currentCombo = 0;
    public bool isCombo = false;
    //连击有效时间
    public float comboInterval = 5.0f;

    private float curRemainComboInterval = 0.0f;
    #endregion

    #region MonoBehaviour
    public void OnEnable()
    {
        LeanTween.addListener((int)Events.TIMEUP, OnTimeUp);
        LeanTween.addListener((int)Events.ENEMYCLEARED, OnEnemyCleared);
        LeanTween.addListener((int)Events.ENEMYDIE, OnEnemyDie);
        LeanTween.addListener((int)Events.PLAYERDIE, OnPlayerDie);
    }

    public void Start()
    {
        ChangeGameStatu(GameStatu.InGame);
    }

    public void OnDisable()
    {
        LeanTween.removeListener((int)Events.TIMEUP, OnTimeUp);
        LeanTween.removeListener((int)Events.ENEMYCLEARED, OnEnemyCleared);
        LeanTween.addListener((int)Events.ENEMYDIE, OnEnemyDie);
        LeanTween.addListener((int)Events.PLAYERDIE, OnPlayerDie);
    }

    public void Update()
    {
        UpdateCombo();
    }


    #endregion

    #region custom method

    void OnEnemyDie(LTEvent evt)
    {
        if (evt.data != null)
        {
            var edi = evt.data as EnemyDeadInfo;
            if (edi.headShot)
            {
                record.HeadShotCount += 1;
            }
            isCombo = true;
            currentCombo += 1;
            curRemainComboInterval = comboInterval;
            record.MaxCombos = currentCombo;
        }
    }

    void UpdateCombo()
    {
        if (isCombo)
        {
            curRemainComboInterval -= Time.deltaTime;
            if (curRemainComboInterval <= 0.0f)
            {
                isCombo = false;
                currentCombo = 0;
            }

        }
    }

    /// <summary>
    /// 获取当前连击剩余有效时间
    /// </summary>
    /// <returns></returns>
    public float GetComboRemainPrectage()
    {
        return curRemainComboInterval / comboInterval;
    }

    void OnTimeUp(LTEvent evt)
    {
        record.FinishType = GameFinishType.Failed;
        ChangeGameStatu(GameStatu.Failed);

    }

    void OnEnemyCleared(LTEvent evt)
    {
        record.FinishType = GameFinishType.Completed;
        ChangeGameStatu(GameStatu.Completed);
    }

    private void OnPlayerDie(LTEvent obj)
    {
        // throw new NotImplementedException();
        record.FinishType = GameFinishType.Failed;
        ChangeGameStatu(GameStatu.Failed);
    }

    /// <summary>
    /// 更改游戏状态
    /// </summary>
    /// <param name="s"></param>
    void ChangeGameStatu(GameStatu s)
    {
        if (s != statu)
        {
            statu = s;
            GameValue.staus = statu;
            if (statu == GameStatu.Failed || statu == GameStatu.Completed)
            {
                Invoke("DelayDispatchFinish", 2f);
            }
        }
    }

    void DelayDispatchFinish()
    {
        LeanTween.dispatchEvent((int)Events.GAMEFINISH, record);
    }
    #endregion
}
