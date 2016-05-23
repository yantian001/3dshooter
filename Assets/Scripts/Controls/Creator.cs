using UnityEngine;
using System.Collections.Generic;
using GameDataEditor;
using System.Collections;

public class EnemyToCreat
{
    public GDEWaveItemData item;
    public int itemCreate = 0;
    public EnemyToCreat(GDEWaveItemData _item)
    {
        item = _item;
    }

    /// <summary>
    /// 是否已经创建完成
    /// </summary>
    /// <returns></returns>
    public bool IsFinish()
    {
        return item == null || item.EnemyCount <= itemCreate;
    }
}

public class Creator : MonoBehaviour
{
    TargetPosition[] positions;

    /// <summary>
    /// 上一次产生敌人波数的时间
    /// </summary>
     float lastWaveCreateTime = -1;
    /// <summary>
    /// 当前敌人的波数
    /// </summary>
     int currentWaveIndex = -1;

     float createInterval = 0;

    GDETaskData task;

    private List<EnemyToCreat> enemyNeedCreates = new List<EnemyToCreat>();

    public void Start()
    {
        positions = FindObjectsOfType<TargetPosition>();
        if (positions.Length <= 0)
        {
            Debug.LogError("don't have spwan position");
        }
        if (GameValue.taskData != null)
        {
            task = GameValue.taskData;
        }

        StartCoroutine(StepToCreateEnemy());
    }

    public void Update()
    {
        if (GameValue.staus == GameStatu.InGame)
        {
            //判断游戏是否已经结束
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length <= 0 && currentWaveIndex > task.Info.Waves.Count - 1 && enemyNeedCreates.Count < 1)
            {
                LeanTween.dispatchEvent((int)Events.ENEMYCLEARED);
                Debug.Log("Enemy Cleared");
                return;
            }
            
            //创建一波敌人
            if (lastWaveCreateTime == -1 || lastWaveCreateTime + task.Info.WaveInterval < Time.time || enemys.Length <= 0)
            {
                CreateEnemy(currentWaveIndex + 1);
            }
        }
    }
    /// <summary>
    /// 创建一波敌人
    /// </summary>
    /// <param name="index"></param>
    public void CreateEnemy(int index)
    {
        currentWaveIndex = index;
        lastWaveCreateTime = Time.time;
        if (task.Info.Waves.Count > index)
        {
            GDEWaveData wave = task.Info.Waves[currentWaveIndex];
            if (wave != null)
            {
                for (int i = 0; i < wave.WaveItems.Count; i++)
                {
                    enemyNeedCreates.Add(new EnemyToCreat(wave.WaveItems[i]));
                }
            }
        }
    }

    IEnumerator StepToCreateEnemy()
    {
        while(true)
        {
            if (GameValue.staus == GameStatu.InGame)
            {
                if(enemyNeedCreates.Count > 0)
                {
                    int i = 0;
                    while(i<enemyNeedCreates.Count)
                    {
                        EnemyToCreat etc = enemyNeedCreates[i];
                        bool canCreate = true;
                        if(etc.item.CheckPoint)
                        {
                            canCreate = WaypointManager.Instance.IsHaveEmptyPoint();
                        }
                        if(canCreate)
                        {
                            Spwan(etc.item);
                            etc.itemCreate += 1;
                            if(etc.IsFinish())
                            {
                                enemyNeedCreates.Remove(etc);
                            }
                            break;
                        }
                        i++;
                    }
                }
            }
            yield return new WaitForSeconds(Random.Range(.5f, 1f));
        }
        
    }

    void Spwan(GDEWaveItemData item)
    {
        
        GameObject obj = Resources.Load("Prefabs/Humans/Enemy/"+item.EnemyName) as GameObject;
        if(obj)
        {
            //Debug.Log("create");
            GameObject o= (GameObject)GameObject.Instantiate(obj, positions[Random.Range(0, positions.Length)].transform.position, Quaternion.identity);
            var e =o.GetComponent<EmenyAttr>();
            e.level = item.EnemyLevel;
        }
    }
}
