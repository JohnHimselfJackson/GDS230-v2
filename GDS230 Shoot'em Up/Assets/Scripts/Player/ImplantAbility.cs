﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplantAbility : MonoBehaviour
{
    private CharacterController2D cC;
    public Rigidbody2D rb;
    public enum Implant { BioticDash };
    public Implant implant;

    public GameObject muzzle;

    //public GameObject dashDes;
    public bool dashing;
    public float speed;
    public float range;
    private bool bDash;
    public bool refreshImplant;
    private Vector2 dashEnd, hitpoint;
    public LayerMask breakable;
    public LayerMask unbreakable;

    void Awake()
    {
        cC = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        implant = Implant.BioticDash;
    }

    void Update()
    {
        ImplantSelect();

        if (dashing)
        {
            Dash();
        }
    }

    void ImplantSelect()
    {
        switch (implant)
        {
            case (Implant.BioticDash):
                bDash = true;
                //Debug.Log("BioticDash");
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

    void Dash()
    {
        if (dashing)
        {
            //Dash forward
            transform.position = Vector2.Lerp(transform.position, hitpoint, speed * Time.deltaTime);
            Debug.Log("Dash started");
            cC.m_AirControl = false;
            rb.gravityScale = 0f;
            refreshImplant = false;

            //Instantiate(dashDes, hitpoint, Quaternion.identity);
            Invoke("StopAbility", 0.2f);
        }

        float distance = Vector2.Distance(muzzle.transform.position, hitpoint);
        Debug.Log(distance);

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
            rb.gravityScale = 3f;
            cC.m_AirControl = true;
            //Destroy(dashDes);
            //Stop dashing
            dashing = false;
            Debug.Log("Dash ended");
        }
    }

    void StopAbility()
    {
        dashing = false;
        rb.gravityScale = 3f;
        cC.m_AirControl = true;
    }
}
