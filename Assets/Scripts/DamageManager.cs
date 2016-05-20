using UnityEngine;
using BehaviorDesigner.Runtime;
public class DamageManager : MonoBehaviour
{

    public GameObject[] deadbody;
    public AudioClip[] hitsound;
    public int hp = 100;
    public int Score = 10;
    private float distancedamage;
    private bool isDied = false;
    public bool isEnemy = true;

    public float tipsTime = 0.5f;

    public float tipsSpeed = 100f;

    public float hight = 2;

    public Texture2D hpSliderBg;

    public Texture2D hpSlider;
    float tipStartTime = 0f;

    bool showHitTips = false;
    public BehaviorTree behavior;
    public int maxHp = 0;
    HitPosition hpos;
    public int depth = 0;


    float hpSliderDisplayBeginTime = 0;

    void Start()
    {
        if (behavior == null)
        {
            behavior = GetComponent<BehaviorTree>();
        }

        //if (animal == null)
        //{
        //    animal = GetComponent<Animal>();
        //}
        maxHp = hp;
    }

    void Update()
    {
        if (hp <= 0 && !isDied)
        {
            Dead(Random.Range(0, deadbody.Length));
            isDied = true;
            showHitTips = true;
            tipStartTime = Time.time;
        }
        if (showHitTips)
        {
            if (tipStartTime + tipsTime <= Time.time)
                showHitTips = false;
        }
    }

    public void ApplyDamage(int damage, Vector3 velosity, float distance)
    {
        if (hp <= 0)
        {
            return;
        }
        distancedamage = distance;
        hp -= damage;
        //Debug.Log(damage);
    }

    public void ApplyDamage(int damage, Vector3 velosity, float distance, int suffix)
    {
        if (hp <= 0)
        {
            return;
        }
        distancedamage = distance;
        hp -= damage;
        if (hp <= 0)
        {
            Dead(suffix);
        }

    }

    public void ApplyDamage(int damage, Vector3 velosity, float distance, int suffix, HitPosition hitPos)
    {
        //   Debug.Log(Vector3.Dot(velosity.normalized, transform.forward));
        // Debug.Log(Vector3.Cross(transform.forward, velosity.normalized).magnitude);
        hpos = hitPos;
        if (hp <= 0)
        {
            return;
        }
        distancedamage = distance;
        hp -= damage;
        hpSliderDisplayBeginTime = Time.fixedTime;
        if (hp <= 0)
        {
            behavior.SetVariableValue("IsDead", true);
            // Vector3.Cross(transform.forward,velosity.normalized)
            //if(Vector3.Dot(velosity.normalized,transform.forward) > 0)
            if (Vector3.Cross(transform.forward, velosity.normalized).y > 0)
            {
                //animation.CrossFade("Death-Right", 0.1f, PlayMode.StopAll);
                behavior.SetVariableValue("deathAnimation", "Death-Right");
            }
            else
            {
                //animation.CrossFade("Death-Left", 0.1f, PlayMode.StopAll);
                // behavior.SendEvent<object>("Dead", 2);
                behavior.SetVariableValue("deathAnimation", "Death-Left");
            }
        }

    }

    public void Dead(int suffix, HitPosition hitPos)
    {
        // throw new NotImplementedException();
        if (isEnemy)
        {
            if (deadbody.Length > 0 && suffix >= 0 && suffix < deadbody.Length)
            {
                // this Object has removed by Dead and replaced with Ragdoll. the ObjectLookAt will null and ActionCamera will stop following and looking.
                // so we have to update ObjectLookAt to this Ragdoll replacement. then ActionCamera to continue fucusing on it.
                GameObject deadReplace = (GameObject)Instantiate(deadbody[suffix], this.transform.position, this.transform.rotation);
                // copy all of transforms to dead object replaced
                CopyTransformsRecurse(this.transform, deadReplace);
                // destroy dead object replaced after 5 sec
                Destroy(deadReplace, 5);
                // destry this game object.
                Destroy(this.gameObject, 1);
                this.gameObject.SetActive(false);

            }
            AfterDead(suffix);
        }
        else
        {
            LeanTween.rotateZ(transform.root.gameObject, 90, 0.5f);
        }
    }

    public void AfterDead(int suffix)
    {

        EnemyDeadInfo edi = new EnemyDeadInfo();
        edi.score = Score;
        edi.transform = this.transform;
        edi.headShot = suffix == 2;
        edi.hitPos = hpos;
        //  edi.animal = this.GetComponent<Animal>();
        LeanTween.dispatchEvent((int)Events.ENEMYDIE, edi);
    }
    /// <summary>
    /// �Ƿ�����
    /// </summary>
    /// <returns></returns>
    public bool IsInjured()
    {
        if (isDied)
            return false;
        if (hp < maxHp)
            return true;
        return false;
    }

    public bool IsDie()
    {
        return isDied;
    }

    public void OnGUI()
    {
        //Debug.Log(GUI.depth);
        GUI.depth = 3;

        //  Debug.Log(GUI.depth);
        if (isEnemy && showHitTips)
        {
            //Debug.Log(gameObject.name);
            Vector3 v3 = Camera.main.WorldToScreenPoint(transform.position);
            string name = hpos.ToString() + " SHOT";
            Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent(name));
            GUI.color = Color.green;
            float hight = Screen.height - v3.y - (Time.time - tipStartTime) * tipsSpeed;
            GUI.Label(new Rect(v3.x, hight, textSize.x, textSize.y), name);

        }

        if (isEnemy && !isDied)
        {
            //if (hp < maxHp && hpSliderDisplayBeginTime + 5 >= Time.fixedTime) 
            //{
            //    //Ĭ��NPC������ڽŵ��£������������npcHeight��ģ�͵ĸ߶ȼ���
            //    Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + hight, transform.position.z);
            //    //����NPCͷ����3D���껻�������2D��Ļ�е�����
            //    Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
            //    //�õ���ʵNPCͷ����2D����
            //    position = new Vector2(position.x, Screen.height - position.y);

            //    Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(animal.Name));

            //    GUI.Label(new Rect(10, 50, nameSize.x, nameSize.y), animal.Name);

            //    Vector2 bloodSize = GUI.skin.horizontalSlider.CalcSize(new GUIContent(hpSlider));
            //    Debug.Log(bloodSize);
            //    //ͨ��Ѫֵ�����ɫѪ����ʾ����
            //    int blood_width = hpSlider.width * hp / maxHp;
            //    //�Ȼ��ƺ�ɫѪ��
            //    GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, bloodSize.x, bloodSize.y), hpSliderBg);
            //    //�ڻ��ƺ�ɫѪ��
            //    GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y, blood_width, bloodSize.y), hpSlider);

            //}
        }
    }

    public void Dead(int suffix)
    {
        if (isEnemy)
        {
            if (deadbody.Length > 0 && suffix >= 0 && suffix < deadbody.Length)
            {
                // this Object has removed by Dead and replaced with Ragdoll. the ObjectLookAt will null and ActionCamera will stop following and looking.
                // so we have to update ObjectLookAt to this Ragdoll replacement. then ActionCamera to continue fucusing on it.
                GameObject deadReplace = (GameObject)Instantiate(deadbody[suffix], this.transform.position, this.transform.rotation);
                // copy all of transforms to dead object replaced
                CopyTransformsRecurse(this.transform, deadReplace);
                // destroy dead object replaced after 5 sec
                Destroy(deadReplace, 5);
                // destry this game object.
                Destroy(this.gameObject, 1);
                this.gameObject.SetActive(false);

            }
            AfterDead(suffix);
        }
        else
        {
            LeanTween.rotateZ(transform.root.gameObject, 90, 0.5f);
        }
    }

    // Copy all transforms to Ragdoll object
    public void CopyTransformsRecurse(Transform src, GameObject dst)
    {
        dst.transform.position = src.position;
        dst.transform.rotation = src.rotation;
        foreach (Transform child in dst.transform)
        {
            var curSrc = src.Find(child.name);
            if (curSrc)
            {
                CopyTransformsRecurse(curSrc, child.gameObject);
            }
        }
    }

}
