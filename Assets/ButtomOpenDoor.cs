using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomOpenDoor : MonoBehaviour
{
    
    public GameObject doorToOpen;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenSelectedDoor();
        }
    }

    public void OpenSelectedDoor()
    {
        if (gm.hasOrangeKey)
        {
            
            Destroy(doorToOpen.gameObject);
        }
        

    }  
}

