using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] float damageEnemy = 20f;
    [SerializeField] Camera cam; 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray=cam.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                TargetHealth target = hit.collider.gameObject.GetComponent<TargetHealth>();
                if(target != null)
                {   
                    
                    TargetHealth enemyHealthScript = hit.transform.GetComponent<TargetHealth>();
                    enemyHealthScript.Damage(damageEnemy);
                }
            }
        }
    }
}
