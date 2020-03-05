using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyWeapon : MonoBehaviour
{
    protected int numberOfShots;
    protected float shotArc;
    protected float timeBetweenShots;
    protected float bulletSpeed;
    protected Vector3 startDisplacement;
    public string gunName;


    public void StartShoot()
    {
        for(int ss = 0; ss < numberOfShots; ss++)
        {
            Invoke("CreateBullet", timeBetweenShots*ss);
        }
    }
    void CreateBullet()
    {
        // determine rotation of bullet and the direction
        GameObject bullet = Instantiate(gameObject.GetComponent<GenericEnemy>().projectile, (gameObject.transform.position + startDisplacement), gameObject.transform.rotation * Quaternion.Euler(new Vector3(0,0, Random.Range(-shotArc/2,shotArc/2))));
        bullet.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.right * bulletSpeed);
    }
}
