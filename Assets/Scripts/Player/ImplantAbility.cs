using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplantAbility : MonoBehaviour
{
    private CharacterController2D cC;
    private Rigidbody2D rb;
    private Animator animator;
    public Animator shieldAnimator;

    public enum Implant { BioticDash, Shield };
    public Implant implant;

    public GameObject muzzle;

    #region Biotic Dash Variables
    [HideInInspector]
    //public GameObject dashDes;
    public bool dashing;
    public float speed;
    public float range;
    private bool bDash;
    public bool refreshImplant;
    private Vector2 dashEnd, hitpoint;
    public LayerMask breakable;
    public LayerMask unbreakable;
    #endregion

    #region Shield Variables
    public GameObject shieldObj;
    public bool shieldActive;
    public bool shieldOn;
    public float maxShieldHealth = 25f;
    public float curShieldHealth;
    #endregion

    void Awake()
    {
        cC = FindObjectOfType<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        #region Shield Start Conditions
        shieldObj.SetActive(false);
        curShieldHealth = maxShieldHealth;
        #endregion
        CheckPrefs();
        //implant = Implant.BioticDash;
    }

    void CheckPrefs()
    {
        PlayerPrefs.GetInt("Dash");
        PlayerPrefs.GetInt("Shield");

        if (SetImplant.dash == 1)
        {
            implant = Implant.BioticDash;
        }
        else if(SetImplant.shield == 1)
        {
            implant = Implant.Shield;
        }
    }

    void Update()
    {
        ImplantSelect();

        if (dashing)
        {
            Dash();
        }
        //print(shieldOn);
    }

    void ImplantSelect()
    {
        switch (implant)
        {
            case (Implant.BioticDash):
                bDash = true;
                //Debug.Log("BioticDash");
                break;

            case (Implant.Shield):
                shieldActive = true;
                break;
        }
    }

    #region Biotic Dash
    public void BioticDash()
    {
        RaycastHit2D hit;
        if (bDash && refreshImplant == true)
        {
            dashing = true;
            dashEnd = muzzle.transform.right;

            //Raycast to find players position
            hit = Physics2D.Raycast(muzzle.transform.position, transform.right, range, unbreakable);
            hitpoint = hit.point;

            if (hit.collider)
            {
                //dashEnd = hit.point;
                Debug.DrawRay(muzzle.transform.position, transform.right * hit.distance, Color.red, 0.5f);
                Debug.Log("Hit unbreakable");
            }
            else
            {
                hitpoint = muzzle.transform.position + muzzle.transform.right * range;
                Debug.DrawRay(muzzle.transform.position, transform.right * range, Color.red, 0.5f);
                Debug.Log("Did not hit unbreakable");
            }
        }
        else
        {
            return;
        }
    }

    void Dash()
    {
       
        animator.SetBool("IsDashing", true);
        print("animator true");

        //Dash forward
        transform.position = Vector2.Lerp(transform.position, hitpoint, speed * Time.deltaTime);
        Debug.Log("Dash started");
        cC.m_AirControl = false;
        rb.gravityScale = 0f;
        refreshImplant = false;

        //Instantiate(dashDes, hitpoint, Quaternion.identity);
        Invoke("StopAbility", 0.2f);


        float distance = Vector2.Distance(muzzle.transform.position, hitpoint);
        //Debug.Log(distance);

        float threshold;
        if (cC.m_Grounded)
        {
            threshold = 0.1f;
        }
        else
        {
            threshold = 0.5f;
        }

        if (distance <= threshold)
        {
            animator.SetBool("IsDashing", false);
            rb.gravityScale = 3f;                                                                                                                                               
            cC.m_AirControl = true;
            //Destroy(dashDes);
            //Stop dashing
            dashing = false;
            Debug.Log("Dash ended");
        }
    }
    #endregion

    #region Shield
    public void Shield()
    {
        if (shieldActive && shieldOn == false)
        {
            shieldOn = true;
            shieldObj.SetActive(true);
            shieldAnimator.SetTrigger("ShieldUp");
            curShieldHealth = 25f;
            Debug.Log("ShieldStarted");
        }
    }

    public void DamageShield(float shieldDamage)
    {
        curShieldHealth = curShieldHealth - shieldDamage;
        BreakShield();
    }
    
    void BreakShield()
    {
        if (curShieldHealth <= 0)
        {
            shieldObj.SetActive(false);
            shieldOn = false;
            print("ShieldDown");
        }
    }
    #endregion

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.tag == "Breakable Wall" && dashing == true)
        {
            Destroy(other.gameObject);
            Debug.Log("Kapow!");
        }
    }

    void StopAbility()
    {
        dashing = false;
        rb.gravityScale = 3f;
        cC.m_AirControl = true;
        animator.SetBool("IsDashing", false);
    }
}
