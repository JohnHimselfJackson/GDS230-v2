using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{ 
    //this is the class which all enemies will inherit from and include all of the basic stats as well as the methods for them to operate once given their more specific script

    #region Variables & shit
    public enum EnemyType { Unassigned, Grunt, SecRobot, GuardDog, SecDrone, Heavy }
    
    public bool enemySpotted;
    public GameObject target;        
    public GameObject projectile;
    public GenericEnemyWeapon myWeapon = null;
    public bool forceKill = false;
    public List<GameObject> drops = new List<GameObject>(); 
    protected int myHealth;
    protected int myArmour;

    protected float mySpeed;
    protected float returnSpeed;

    public EnemyType myType = EnemyType.Unassigned;

    #endregion

    #region Speed Modification
    //  permamently changes the speed of the enemy based on a decimal value
    public void ModifySpeed(float decimalChange, bool isInfite)
    {
        if (isInfite)
        {
            returnSpeed *= decimalChange;
            mySpeed *= decimalChange;
        }
    }
    //  temporaily changes the speed of the enemy temporaily
    public void ModifySpeed(float decimalChange, float modificationDuration)
    {
        returnSpeed = mySpeed;
        mySpeed *= decimalChange;
        Invoke("BacktoSpeed", modificationDuration);
    }
    //  Used for reseting the speed after a modification runs out. is not used outside of script
    private void BacktoSpeed()
    {
        mySpeed = returnSpeed;
    }
    #endregion

    #region Health Modification
    //  Used to alter the health of the enemy **note** do not use to kill enemy, instead used the kill function for an instant kill
    public void SetHealth(int healthToSet)
    {
        myHealth = healthToSet;
    }
    //  Used to damage an enemy Unit, simply make the imput the amount of damage you want to deal as this method takes armour into account and checks if the enemy still has health afterwards  **note** use this instead of directly altering armour
    public void DealDamage(int damage)
    {

        int modifiedDamage = damage * (1-(myArmour/100));
        //do damage animation
        myHealth -= modifiedDamage;
        if (myHealth <= 0)
        {
            Kill();
        }
    }
    // kills the enemy
    public void Kill()
    {
        DropLoot();
        Destroy(gameObject);
    }

    public void ForceKill()
    {
        if (forceKill)
        {
            Kill();
        }
    }



    #endregion

    #region Basic Functions
    //these are the generic functions that all enemies will have a variation of in some form but are left as empty virtuals here. They will be overrided in the with specific details in derived scipts.
    public virtual void PatrolOrIdle()
    {
        //doin a stand or walk
    }
    public virtual void Follow()
    {
        //i dont have legs
    }
    public virtual void Attack()
    {
        //pew pew
    }
    #endregion

    #region Other Functions

    /* ----------------------------------------------------------------------------------- *\
        while these functions are here dont use them as they are currently not functional
    \* ----------------------------------------------------------------------------------- */ 

    //  allows the assigning of weapons
    protected virtual void AssignWeapon(GenericEnemyWeapon newWeapon)
    {
        myWeapon = newWeapon;
    }
    //  mostly useless, makes the enemy weapon null
    protected virtual void DropWeapon()
    {
        myWeapon = null;
    }

    public void DropLoot()
    {
        GameObject drop = Instantiate<GameObject>(drops[Random.Range(0, 2)],transform.position + Vector3.up *0.5f, Quaternion.identity);
        drop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * 2f, ForceMode2D.Impulse);
    }
    #endregion

}
