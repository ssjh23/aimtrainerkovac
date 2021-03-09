using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorhide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }
}
