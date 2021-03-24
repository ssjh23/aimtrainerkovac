using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player takes damage when melee range)
public class PlayerDmg : MonoBehaviour
{
    public float playerdamage1 = 20f;
    

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerHealth>().Damage(playerdamage1);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("20 dmg");
        }
       
    }
}
