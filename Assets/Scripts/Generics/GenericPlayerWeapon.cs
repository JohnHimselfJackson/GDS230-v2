using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerWeapon : MonoBehaviour
{
    public string weaponType;
    public float fireRate = 1;
    public float damage;
    public float projectileSpeed;
    public float projectileSizeMulti;
    public float ammoPerShot;
    public GameObject projectile;

    public Transform firePosition;

    public GameObject playerLaser;

    float timeToFire = 0;

    private void Start()
    {
        
    }
    private void Update()
    {
        timeToFire -= Time.deltaTime;
    }
    // Update is called once per frame
    public void CallToShoot()
    {
        if(weaponType == "laser")
        {
            
            RaycastHit2D laserCast = Physics2D.Raycast(firePosition.position, firePosition.right);
            if (laserCast && playerLaser != null)
            {
                Vector3 hitPoint = laserCast.point;
                Vector3 laserVector = hitPoint - firePosition.position;
                float laserLength = Vector3.Distance(firePosition.position, hitPoint);
                Vector3 laserMidPoint = (hitPoint + firePosition.position) / 2;
                playerLaser.SetActive(true);
                playerLaser.GetComponent<ActualPlayerLaser>().trackingNumber = 1;
                playerLaser.GetComponent<SpriteRenderer>().size = new Vector2(0.3f, laserLength);
                playerLaser.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Tiled;
                playerLaser.GetComponent<LaserScript>().laserDimensions = new Vector2(0.3f, laserLength);
                playerLaser.transform.localScale = new Vector3(1, 1, 1);

            }
            else if (playerLaser = null)
            {
                print("playerLaser laser failed to instantiate");
            }
            else
            {
                print("laser raycast did not hit a wall");
            }
        }
        else
        {
            //Fire rate
            if (timeToFire < 0)
            {
                timeToFire = (1 / fireRate);
                Shoot();
                print("test 1");
            }
        }
    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, firePosition.position, firePosition.rotation);
        newProjectile.GetComponent<PlayerBullet>().SetBulletValues((int)damage, projectileSpeed, projectileSizeMulti);
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
        //Player.Ammo - ammoPerShot;
    }
    public virtual void GenerateRandomWeaponStats(float qualityDecimal)
    {

    }
    
    public void AssignFromSavedData(PlayerWeaponSaveData data)
    {
        weaponType = data.weaponType;
        fireRate = data.fireRate;
        damage = data.damage;
        projectileSpeed = data.projectileSpeed;
        projectileSizeMulti = data.projectileSizeMulti;
        ammoPerShot = data.ammoPerShot;
    }
}
