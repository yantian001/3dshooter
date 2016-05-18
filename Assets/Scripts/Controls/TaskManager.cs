using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;

public class TaskManager : MonoBehaviour
{

    private List<GDELevelData> levels = new List<GDELevelData>();

    private static TaskManager _instance;

    public static TaskManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TaskManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("TaskManagerHandler");
                    _instance = go.AddComponent<TaskManager>();
                }
            }
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitFromGDE();
            //for test
            GameValue.taskData = GetTask(1, 1);
        }
        else
        {
            Destroy(gameObject);
        }



    }

    /// <summary>
    /// 初始化
    /// </summary>
    void InitFromGDE()
    {

        GDEDataManager.Init("gde_data");
        {
            List<string> lstLevelName;
            GDEDataManager.GetAllDataKeysBySchema("Level", out lstLevelName);
            for (int i = 0; i < lstLevelName.Count; i++)
            {
                GDELevelData level = null;
                if (GDEDataManager.DataDictionary.TryGetCustom(lstLevelName[i], out level))
                {
                    levels.Add(level);
                }
            }
        }
    }

    public GDETaskData GetTask(int level, int task)
    {
        GDETaskData taskReturn = null;
        var l = levels.Find(p => p.LevelNum1 == level);
        if (l != null)
        {
            taskReturn = l.TaskList.Find(p => p.TaskNum == task);
        }
        return taskReturn;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
