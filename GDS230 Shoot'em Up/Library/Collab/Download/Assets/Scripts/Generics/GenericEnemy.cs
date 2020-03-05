using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{ 
    //this is the class which all enemies will inherit from and include all of the basic stats as well as the methods for them to operate once given their more specific script

    #region Variables & shit
    public enum EnemyType { Unassigned, Basic, SecRobot, GuardDog, SecDrone, Grunt }
    public enum EnemyState { Agroed, Passive }

    public bool enemySpotted;
    public GameObject target;

    protected int myHealth;
    protected int myArmour;

    protected float mySpeed;
    protected float returnSpeed;

    protected EnemyType myType = EnemyType.Unassigned;
    protected EnemyState myState = EnemyState.Passive;

    protected GenericEnemyWeapon myWeapon = null;
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
        int modifiedDamage = damage - myArmour;
        if (modifiedDamage < 0)
        {
            modifiedDamage = 0;
            return;
        }
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
        //destroy the bad boi
    }
    #endregion

    #region Basic Functions
    //these are the generic functions that all enemies will have a variation of in some form but are left as empty virtuals here. They will be overrided in the with specific details in derived scipts.
    public virtual void checkEnemy()
    {
        //i am legally blind
    }
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
    #endregion

}
