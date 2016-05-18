using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour
{

    public Waypoint[] wayPoints;

    private static WaypointManager _instance = null;

    public static WaypointManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public void Awake()
    {
        if(_instance)
        {
            GameObject.Destroy(_instance);
        }
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        if(wayPoints == null || wayPoints.Length <= 0)
        {
            wayPoints = transform.GetComponentsInChildren<Waypoint>();
        }
    }

    /// <summary>
    /// 是否有空的可以移动的点
    /// </summary>
    /// <param name="childCount">每个点最大的敌人数,默认为1</param>
    /// <returns></returns>
    public bool IsHaveEmptyPoint(int childCount = 1)
    {
        for(int i=0;i<wayPoints.Length;i++)
        {
            if(wayPoints[i].transform.childCount < childCount)
            {
                return true;
            }
        }
        return false;
    }
}
