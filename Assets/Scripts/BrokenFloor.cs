using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public int life = 3;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void LostLife()
    {
        life--;

        if (life <= 0)
            gameObject.SetActive(false); 

        if (life == 2)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0.75f, 0.75f, 0.75f);
        }

        if (life == 1)
        {
            GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }
    }
    public void ResetFloor()
    {
        life = 3;
        GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
