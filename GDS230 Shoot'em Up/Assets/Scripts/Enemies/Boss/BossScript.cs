using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossScript : MonoBehaviour
{
    public PickUpData holder;

    float[] mortarXs = new float[10];
    public Vector3 bossAreaStart;
    public Vector3 bossAreaPlayerLimit;
    public Vector3 bossAreaEnd;

    public Vector3 laserScanStart;
    public Vector3 laserScanEnd;
    public Vector3 laserStartPoint;
    public GameObject bossLaser = null;

    public GameObject player;
    public GameObject mortarShot;
    public GameObject projectile;
    public GameObject laserInstance;

    public TMP_Text healthTB;

    float playerWidth = 0.6f;


    bool immune = true;
    bool initiating = true;

    bool laserSweepStarted = false;

    bool deathStarted = false;

    int shotArc = 30;
    int numberOfShots = 35;
    float timeBetweenShots = 0.05f;
    float bulletSpeed = 100f;
    public Vector3 startDisplacement;

    float initiatingTime = 4;
    float attackWaitTime = 0;
    int myHealth = 1000;
    int myArmour = 1;
    int stage = 0;
    public List<GameObject> drops = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case 0:
                if (player.transform.position.x > bossAreaStart.x)
                {
                    stage = 1;
                }
                break;
            case 1:
                StageOne();
                break;
            case 2:
                StageTwo();
                break;
            case 3:
                StageThree();
                break;
            case 4:
                StageFour();
                break;
            case 5:
                if (!deathStarted)
                {
                    DeathStage();
                }
                break;
        }
        UpdateHealthText();
    }

    public void DamageBoss(int damage)
    {

        int modifiedDamage = damage - myArmour;
        if (modifiedDamage < 0)
        {
            modifiedDamage = 0;
            return;
        }
        if (!immune)
        {
            myHealth -= modifiedDamage;
        }
        if (myHealth < 0 && stage < 5)
        {
            stage = 5;
            initiating = true;
            immune = true;
        }
        else if(myHealth < 250 && stage < 4)
        {
            //add missile stage here
            stage = 5;
            GetComponent<SpriteRenderer>().color = Color.magenta;
            initiating = true;
            immune = true;
        }
        else if(myHealth < 500 && stage < 3)
        {
            stage = 3;
            GetComponent<SpriteRenderer>().color = Color.red;
            initiating = true;
            immune = true;
        }
        else if(myHealth < 750 && stage < 2)
        {
            stage = 2;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            initiating = true;
            immune = true;
        }
    }

    #region Stages
    void StageOne()
    {
        if (initiating)
        {
            initiatingTime -= Time.deltaTime;
            if(initiatingTime < 0)
            {
                initiating = false;
                immune = false;
                initiatingTime = 4;
            }
        }
        else
        {
            if(attackWaitTime < 0)
            {
                Mortar();
                attackWaitTime = 5;
            }
            else
            {
                attackWaitTime -= Time.deltaTime;
            }
        }
    }
    void StageTwo()
    {
        if (initiating)
        {
            initiatingTime -= Time.deltaTime;
            if (initiatingTime < 0)
            {
                initiating = false;
                immune = false;
                initiatingTime = 5;
            }
        }
        else
        {
            if (attackWaitTime < 0)
            {
                MiniGun();
                attackWaitTime = 6;
            }
            else
            {
                attackWaitTime -= Time.deltaTime;
            }
        }
    }
    void StageThree()
    {
        if (initiating)
        {
            initiatingTime -= Time.deltaTime;
            if (initiatingTime < 0)
            {
                initiating = false;
                immune = false;
                initiatingTime = 1;
            }
        }
        else
        {
            if (attackWaitTime < 0)
            {
                Laser();
                attackWaitTime = 3;
            }
            else
            {
                attackWaitTime -= Time.deltaTime;
            }
        }
    }
    void StageFour()
    {
        if (initiating)
        {
            initiatingTime -= Time.deltaTime;
            if (initiatingTime < 0)
            {
                initiating = false;
                immune = false;
                initiatingTime = 5;
            }
        }
        else
        {
            if (attackWaitTime < 0)
            {
                Missles();
                attackWaitTime = 10;
            }
            else
            {
                attackWaitTime -= Time.deltaTime;
            }
        }
    }
    void DeathStage()
    {
        deathStarted = true;
        print("yeah good");
        GetComponent<SpriteRenderer>().color = Color.blue;
        InvokeRepeating("DropCoin", 0.2f, 0.4f);
        Invoke("DropWeapon", 5f);
        Invoke("DelayCancelCoinInvoke", 8f);
        Invoke("ToPostGameScreen", 15f);
    }
    #endregion

    #region Attacks

    void Mortar()
    {
        //set a safe space for player to be able to go and DEFINETLY not be hit
        float positionRange = bossAreaPlayerLimit.x - bossAreaStart.x - 2 * playerWidth;
        if (positionRange < 0)
        {
            print("Error expected as boss zone is too small");
        }
        float safeZoneX = Random.Range(0f, positionRange);
        for (int mm = 0; mm <= 9; mm++)
        {
            if (mm < 0)
            {
                mm = 0;
            }
            float potentialLandingLocation = Random.Range(bossAreaStart.x, bossAreaPlayerLimit.x);
            if (potentialLandingLocation > safeZoneX - playerWidth && potentialLandingLocation < safeZoneX + playerWidth)
            {
                mm--;
            }
            else
            {

                mortarXs[mm] = potentialLandingLocation;
            }
        }

        for (int mm = 0; mm <= 9; mm++)
        {
            Instantiate<GameObject>(mortarShot, new Vector3(mortarXs[mm], 0, 0), Quaternion.identity);
        }

        //shoot dumby shots
        //put hit area in those areas
        //make true shots fall from the sky
    }

    void MiniGun()
    {
        for (int ss = 0; ss < numberOfShots; ss++)
        {
            Invoke("CreateBullet", timeBetweenShots * ss);
        }
    }
    void Laser()
    {
        bool scanningRight = false;
        Vector3 toStart = laserScanStart - laserStartPoint;
        Vector3 toEnd = laserScanEnd - laserStartPoint;


        float angle = Vector3.Angle(toStart, toEnd);

        float baseAngle = - Vector3.Angle(Vector3.down, toStart);
        float startingAngle = baseAngle - Random.Range(0, angle);

        RaycastHit2D initialHit = Physics2D.Raycast(laserStartPoint, new Vector2(Mathf.Cos(Mathf.Deg2Rad * (startingAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (startingAngle - 90))));
            
        Vector3 hitPoint = initialHit.point;
        Vector3 laserVector = hitPoint - laserStartPoint;
        float laserLength = Vector3.Distance(laserStartPoint, hitPoint);
        Vector3 laserMidPoint = (hitPoint + laserStartPoint) / 2;


        bossLaser = Instantiate(laserInstance, laserMidPoint, Quaternion.Euler(0, 0, startingAngle));
        bossLaser.GetComponent<SpriteRenderer>().size = new Vector2(0.3f , laserLength);
        bossLaser.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Tiled;
        bossLaser.GetComponent<LaserScript>().laserDimensions = new Vector2(0.3f, laserLength);
        bossLaser.transform.localScale = new Vector3(1, 1, 1);


        //shoots a raycast out for laser
        //gets distance and makes lase thing out of parts to the point
        //gradually changes angle giving a scanning laser effect
        //does laser things
    }
    void Missles()
    {
        //does missile things
    }



    #endregion
    
    void CreateBullet()
    {
        // determine rotation of bullet and the direction
        GameObject bullet = Instantiate(projectile, (gameObject.transform.position + startDisplacement), gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-shotArc / 2, shotArc / 2))));
        bullet.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.right * bulletSpeed);
    }

    public void DropCoin()
    {
        GameObject drop = Instantiate<GameObject>(drops[0], transform.position + (Vector3.up * 0.5f) -(Vector3.forward * 3f), Quaternion.identity);
        drop.GetComponent<CoinScript>().dataHolder = holder;
        drop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * 4f, ForceMode2D.Impulse);
    }

    public void DropWeapon()
    {
        GameObject drop = Instantiate<GameObject>(drops[Random.Range(1,3)], transform.position + (Vector3.up * 0.5f) - (Vector3.forward * 3f), Quaternion.identity);
        drop.GetComponent<GenericWeaponPickup>().dataHolder = holder;
        drop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * 2f, ForceMode2D.Impulse);
    }

    void ToPostGameScreen()
    {
        SceneManager.LoadScene(5);
    }
    
    void DelayCancelCoinInvoke()
    {
        CancelInvoke("DropCoin");
    }


    void UpdateHealthText()
    {
        switch (stage)
        {
            case 0:
                healthTB.text = null;
                break;
            case 1:
            case 2:
            case 3:
            case 4:
                healthTB.text = myHealth.ToString() + "/ 1000";
                if (immune)
                {
                    healthTB.color = Color.blue;
                }
                else
                {
                    healthTB.color = Color.white;
                }
                break;
            case 5:
                healthTB.text = "0 / 1000";
                healthTB.color = Color.red;
                break;
        }
    }
}
