using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : GenericEnemy
{
    float followtime = 1.5f;
    float waitTime = -1;
    float shootingtime = 0;
    bool patroling = false;
    bool movingLeft = true;
    int patrolsDone = 0;
    bool shooting = true;

    [SerializeField]
    GameObject bullet;

    public float movementSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpotted)
        {
            if(followtime <= 0)
            {
                Attack();
            }
            else
            {
                Follow();
            }
        }
        else 
        {
            PatrolOrIdle();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.CompareTag("Player"))
        {
            enemySpotted = true;
            target = GO;
            patroling = true;
            CheckFacing();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.CompareTag("Player"))
        {
            enemySpotted = false;
            target = null;
            CheckFacing();
        }
    }

    public override void Attack()
    {
        if (shootingtime < 1.5f)
        {
            shootingtime += Time.deltaTime;
            if (shootingtime >1 && shooting)
            {
                shooting = false;
                Invoke("shoot", 0.1f);
                Invoke("shoot", 0.3f);
                Invoke("shoot", 0.5f);
            }
        }
        else
        {
            followtime = 3;
            shootingtime = 0;
            shooting = true;

        }
    }
    public override void Follow()
    {
        CheckFacing();
        RaycastHit2D leftHitGround = Physics2D.Raycast(transform.position + new Vector3(-0.15f, -0.31f, 0), Vector3.down, 0.2f);
        RaycastHit2D rightHitGround = Physics2D.Raycast(transform.position + new Vector3(0.15f, -0.31f, 0), Vector3.down, 0.2f);

        if (leftHitGround != false
        &&  Physics2D.BoxCastAll(transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), 0f, Vector3.zero).Length <= 2 
        &&  transform.position.x > target.transform.position.x 
        &&  (target.transform.position.x - transform.position.x) < -1.5f)
        {
            transform.Translate(-transform.right * movementSpeed * Time.deltaTime, Space.Self);

        }
        else if (rightHitGround != false
        &&       Physics2D.BoxCastAll(transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.55f, 0), 0f, Vector3.zero).Length <= 2
        &&       transform.position.x < target.transform.position.x 
        &&       (target.transform.position.x - transform.position.x) > 1.5f)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            Attack();
        }
        
        followtime -= Time.deltaTime;
    }

    public override void PatrolOrIdle()
    {
        if (patroling && waitTime < 0)
        {
            RaycastHit2D leftHitGround = Physics2D.Raycast(transform.position + new Vector3(-0.15f, -0.31f, 0), Vector3.down, 0.2f);
            RaycastHit2D rightHitGround = Physics2D.Raycast(transform.position + new Vector3(0.15f, -0.31f, 0), Vector3.down, 0.2f);

            if (!movingLeft && rightHitGround != false && Physics2D.BoxCastAll(transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.55f, 0), 0f, Vector3.zero).Length <=2)
            {
                if (rightHitGround.transform.gameObject.CompareTag("Barrier"))
                {
                    transform.Translate(transform.right * movementSpeed * Time.deltaTime, Space.Self);
                }
            }
            else if(!movingLeft && (rightHitGround == false || Physics2D.BoxCastAll(transform.position + new Vector3(0.18f, 0, 0), new Vector3(0.05f, 0.55f, 0), 0f, Vector3.zero).Length > 2))
            {
                print("turning to go left");
                transform.rotation = Quaternion.Euler(0, 0, 0);
                movingLeft = true;
                patrolsDone ++;
            }

            if (movingLeft && leftHitGround != false && Physics2D.BoxCastAll(transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), 0f, Vector3.zero).Length <= 2 )
            {
                if (leftHitGround.transform.gameObject.CompareTag("Barrier"))
                {
                    transform.Translate(-transform.right * movementSpeed* Time.deltaTime, Space.Self);
                }
            }
            else if(movingLeft && (leftHitGround == false || Physics2D.BoxCastAll(transform.position + new Vector3(-0.18f, 0, 0), new Vector3(0.05f, 0.6f, 0), 0f, Vector3.zero).Length > 2))
            {
                print("turning to go right");
                transform.rotation = Quaternion.Euler(0, 180, 0);
                movingLeft = false;
                patrolsDone ++;
            }

            if(patrolsDone == 2)
            {
                patrolsDone ++;
                Invoke("PatrollingOver", Random.Range(2f, 4.5f ));
            }

        }
        else if (waitTime <= 0 )
        {
            waitTime = Random.Range(4f, 10f);
        }
        else
        {
            waitTime -= Time.deltaTime;
            if(waitTime < 0)
            {
                patroling = true;
            }

        }

    }


    void CheckFacing()
    {
        if(target != null)
        {
            if(target.transform.position.x - transform.position.x > 0)
            {
                //target right
                transform.rotation = Quaternion.Euler(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                //target left
                transform.rotation = Quaternion.Euler(0, 0, 0);
                movingLeft = true;
            }
        }
    }

    void PatrollingOver()
    {
        print("starting wait");
            patroling = false;
            patrolsDone = 0;
    }

    void shoot()
    {
        Instantiate(bullet, (transform.position - transform.right * 0.15f), Quaternion.identity);

    }

}
