using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public int life = 2;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0, 0);
    }

    public void LostLife()
    {
        life--;

        if (life <= 0)
            Destroy(gameObject); 

        if (life == 2)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0.6f, 0, 0);
        }

        if (life == 1)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0.9f, 0, 0);
        }
    }

}
