using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - objectToFollow.position; //offset é igual distancia entre a posicao inicial da
                                                      //camera - posicao inicial objeto a ser seguido

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.position + offset; //posicao do objeto camera recebe o valor da posicao do objeto que
                                                               //ela esta seguindo(player) + valor do offset (eixos y e z)

        transform.LookAt(objectToFollow);
    }
}
