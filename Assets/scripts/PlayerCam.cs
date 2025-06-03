using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform Orientation;

    float xRotation;
    float yRotation;
     
    
    
    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {



        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 5)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
          

        }
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
       
        
            yRotation += mouseX;


        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        
        
            //rotate cam an orientation 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);   
        

        
        

    }

}
