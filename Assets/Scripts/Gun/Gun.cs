using UnityEngine;
using GameDataEditor;

[RequireComponent(typeof(AudioSource))]


public class Gun : MonoBehaviour
{
    public int id = 0;
    public bool Active = true;
    public GameObject Bullets; // Bullet prefeb
    public float LifeTimeBullet = 5;
    public GameObject Shell; // Shell prefeb
    public Transform ShellSpawn; // shell spawing position
    public Camera NormalCamera;// FPS camera
    public float FireRate = 0.2f;
    public float CooldownTime = 0.8f;
    public float BoltTime = 0.35f;
    public Texture2D CrosshairImg, CrosshairZoom;
    public bool HideGunWhileZooming = true;
    public AudioClip SoundGunFire;
    public AudioClip SoundBoltEnd;
    public AudioClip SoundBoltStart;
    public AudioClip SoundReloadStart;
    public AudioClip SoundReloadEnd;
    public AudioClip SoundEmpty;

    float Power = 0;
    public bool SemiAuto;
    public bool InfinityAmmo = true;
    public int BulletNum = 1;
    public float Spread = 0;
    public int Clip = 30;
    public int ClipSize = 30;
    public int AmmoIn = 1;
    public int AmmoPack = 90;
    public int AmmoPackMax = 90;

    private float timefire = 0;
    private int gunState = 0;
    private AudioSource audiosource;
    [HideInInspector]

    private float cooldowntime = 0;

    public Transform muzzleTransform;
    public GameObject muzzleFlash;

    void Start()
    {
        //if (GetComponent<Animation>())
        //    GetComponent<Animation>().cullingType = AnimationCullingType.AlwaysAnimate;
        // FPSmotor = transform.root.GetComponentInChildren<FPSController>();

      
        if (GetComponent<AudioSource>())
        {
            audiosource = GetComponent<AudioSource>();
        }

       
        if (!this.InfinityAmmo)
        {
            //AmmoPack = Player.CurrentUser.GetMaterialCount(id);
        }

        if (AmmoIn > 1)
            AmmoIn = 1;
    }

    void Awake()
    {
      

        //GDEWeaponData wd = WeaponManager.Instance.GetWeaponById(id);
        //if (wd != null)
        //{
        //    Power = wd.GetAttributeCurrentVal(0);
        //    MaxZoom = wd.GetAttributeCurrentVal(1);
        //    MouseStability = wd.GetAttributeCurrentVal(2);
        //    ClipSize = ConvertUtil.ToInt32(wd.GetAttributeCurrentVal(3));
        //    Infrared = wd.GetAttributeCurrentVal(4);
        //}
    }

    public void SetActive(bool active)
    {
        Active = active;
        this.gameObject.SetActive(active);
        
    }

    void Update()
    {
        //if (HideGunWhileZooming && FPSmotor && NormalCamera.GetComponent<Camera>().enabled)
        //{
        //    FPSmotor.HideGun(!Zooming);
        //}

        //if (!GetComponent<Animation>() || !Active)
        //    return;
        if (!Active)
        {
            return;
        }

        switch (gunState)
        {
            case 0:
                // Start Bolt
                if (AmmoIn <= 0)
                {
                    // Check Ammo in clip
                    if (Clip > 0)
                    {
                        
                        gunState = 2;
                     
                        if (SoundBoltStart && audiosource != null)
                        {
                            audiosource.PlayOneShot(SoundBoltStart);
                        }
                        Clip -= 1;
                    }
                    else
                    {
                        gunState = 3;
                    }
                }
                break;
            case 1:
                // Countdown to idle state
                if (Time.time >= cooldowntime + CooldownTime)
                {

                    gunState = 0;
                }
                break;
            case 2:
               
                if (Shell && ShellSpawn)
                {
                  
                        GameObject shell = (GameObject)Instantiate(Shell, ShellSpawn.position, ShellSpawn.rotation);
                        shell.GetComponent<Rigidbody>().AddForce(ShellSpawn.transform.right * 2);
                        shell.GetComponent<Rigidbody>().AddTorque(Random.rotation.eulerAngles * 10);
                        GameObject.Destroy(shell, 5);
                }

              
                gunState = 0;
                AmmoIn = 1;
            
                if (SoundBoltEnd && audiosource != null)
                {
                    audiosource.PlayOneShot(SoundBoltEnd);
                }

            
                break;
            case 3:
             
                if (AmmoPack > 0 || InfinityAmmo)
                {
                  
                    gunState = 4;
                    if (SoundReloadStart && audiosource != null)
                    {
                        audiosource.PlayOneShot(SoundReloadStart);
                    }
                }
                else
                {
                    gunState = 5;
                }
                break;
            case 4:

                if (true)
                {
                    if (true)
                    {
                        gunState = 0;

                        if (InfinityAmmo)
                        {
                            Clip = ClipSize;
                        }
                        else
                        {
                            if (AmmoPack >= ClipSize)
                            {
                                Clip = ClipSize;
                                AmmoPack -= ClipSize;
                            }
                            else
                            {
                                if (AmmoPack > 0)
                                {
                                    Clip = AmmoPack;
                                    AmmoPack = 0;
                                }

                            }
                        }

                        if (Clip > 0)
                        {
                            // GetComponent<Animation>().CrossFade(IdlePose);
                            if (SoundReloadEnd && audiosource != null)
                            {
                                audiosource.PlayOneShot(SoundReloadEnd);
                            }
                        }
                    }
                }
                //else
                //{
                //    gunState = 0;
                //}
                break;
        }

        //if (FPSmotor)
        //{
        //    if (Zooming)
        //    {
        //        FPSmotor.sensitivityXMult = MouseSensitiveZoom;
        //        FPSmotor.sensitivityYMult = MouseSensitiveZoom;
        //        FPSmotor.stability = MouseStability / 100;
        //        FPSmotor.Noise = true;
        //    }
        //    else
        //    {
        //        FPSmotor.sensitivityXMult = MouseSensitive;
        //        FPSmotor.sensitivityYMult = MouseSensitive;
        //        FPSmotor.stability = MouseStability / 100;
        //        FPSmotor.Noise = false;
        //    }
        //}
        if (audiosource != null)
        {
            audiosource.pitch = Time.timeScale;
            if (audiosource.pitch < 0.5f)
            {
                audiosource.pitch = 0.5f;
            }
        }

    }

   

    public void Reload()
    {
        if (gunState == 0)
        {
            AmmoIn = 0;
            Clip = 0;
            gunState = 3;
        }
    }

   
  
    public void Shoot()
    {
        if (!Active)
            return;

        if (timefire + FireRate < Time.time)
        {
            if (gunState == 0)
            {
                if (AmmoIn > 0)
                {
                    //if (FPSmotor)
                    //    FPSmotor.Stun(KickPower);
                    if (SoundGunFire && audiosource != null)
                    {
                        audiosource.PlayOneShot(SoundGunFire);
                    }

                    for (int i = 0; i < BulletNum; i++)
                    {
                        if (Bullets)
                        {
                            Vector3 point = NormalCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

                            //GameObject bullet = (GameObject)Instantiate(Bullets, muzzleTransform.position, Quaternion.LookRotation(NormalCamera.transform.forward));
                            GameObject bullet = (GameObject)Instantiate(Bullets, point, Quaternion.LookRotation(NormalCamera.transform.forward));
                            var asBuulet = bullet.GetComponent<AS_Bullet>();
                            if (asBuulet)
                            {
                                asBuulet.Damage = ConvertUtil.ToInt32(Power);
                            }
                            bullet.transform.forward = NormalCamera.transform.forward + new Vector3(Random.Range(-Spread / 1000, Spread / 1000), Random.Range(-Spread / 1000, Spread / 1000), Random.Range(-Spread / 1000, Spread / 1000));

                            //bullet.transform.forward = NormalCamera.transform.forward;
                            Destroy(bullet, LifeTimeBullet);
                        }
                    }
                    ShowFlash();
                    // GetComponent<Animation>().Stop();
                    //GetComponent<Animation>().Play(ShootPose, PlayMode.StopAll);
                    timefire = Time.time;
                    cooldowntime = Time.time;
                    if (!InfinityAmmo)
                    {
                        // Player.CurrentUser.BuyGunAmmo(id, -1);
                    }
                    AmmoIn -= 1;
                    if (!SemiAuto)
                    {
                        gunState = 1;

                    }
                    else
                    {

                        if (Shell && ShellSpawn)
                        {
                            GameObject shell = (GameObject)Instantiate(Shell, ShellSpawn.position, ShellSpawn.rotation);
                            shell.GetComponent<Rigidbody>().AddForce(ShellSpawn.transform.right * 2);
                            shell.GetComponent<Rigidbody>().AddTorque(Random.rotation.eulerAngles * 10);
                            GameObject.Destroy(shell, 5);
                        }

                        if (Clip > 0)
                        {
                            AmmoIn = 1;
                            Clip -= 1;
                        }
                        else
                        {
                            gunState = 3;
                        }
                    }
                }

                if (Clip <= 0 && AmmoIn <= 0)
                {
                    gunState = 3;
                }

            }
            else if (gunState == 5)
            {
                audiosource.PlayOneShot(SoundEmpty);
            }
        }
    }
    
    public void ShowFlash()
    {
        if(muzzleFlash && muzzleTransform)
        {
            muzzleFlash.transform.position = muzzleTransform.transform.position;
            muzzleFlash.transform.rotation = muzzleTransform.transform.rotation;
        }
        muzzleFlash.SendMessage("Shoot", SendMessageOptions.DontRequireReceiver);
    }
}
