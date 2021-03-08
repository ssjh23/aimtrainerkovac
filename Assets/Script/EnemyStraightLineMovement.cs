using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightLineMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;   
    }
}
