using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 15.0f;
    public bool isGrounded;
    Rigidbody rb;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 moveDirection = new(hMove, 0, vMove);

        rb.AddForce(moveDirection * speed);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //otherObject e a referencia para o objeto na qual eu colidi

        GameObject otherObject = collision.gameObject;

        //ao colidir com otherObject ele verifica se tem a tag desejada e entao pinta o objeto
        if (otherObject.CompareTag("CubeChangeColor"))
        {
            otherObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        // para criar um sistema de mola no jogo (nesse codigo, quem controla a forca do impulso e a propria mola e nao o personagem)
        if (otherObject.GetComponent<Spring>() != null)
        {
            float jumpForce = otherObject.GetComponent<Spring>().jumpForceSpring;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (otherObject.GetComponent<ButtomOpenDoor>() != null)
        {
            otherObject.GetComponent<ButtomOpenDoor>().OpenSelectedDoor();
        }
    }


    
    private void OnCollisionStay(Collision collision)
    //para detectar se o pivo do objeto com que eu colidi está mais baixo que o player (se e chao) e se o objeto
    //tem a tag de chao(usado para pular, pra nao ficar pulando no ar)
    {
        if (transform.position.y > collision.transform.position.y && collision.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    
    private void OnCollisionExit(Collision collision)
    //para sair da colisao e poder pular (por isso muda pra false), verifica se esta no chao e se a tag e chao
    {
        GameObject otherObject = collision.gameObject;

        if (isGrounded == true && collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        //cria um chao que quebra, apos passar por cima dele
        if (otherObject.GetComponents<BrokenFloor>() != null)
        {
            BrokenFloor brokenFloor;//cria variavel local
            brokenFloor = otherObject.GetComponent<BrokenFloor>();//acessa o componente (script) do objeto em que houve colisao e recebe o valor
            brokenFloor.LostLife(); //dentro do script acessa a funcao LostLife
        }

    }

    private void OnTriggerEnter(Collider other)
        //para fazer um coletavel, uso a tag, destruo o objeto com a qual eu colidi e acumulo pontos
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
            gm.points++;
        }

        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            GameObject.FindAnyObjectByType<GameManager>().hasOrangeKey = true;
        }

    }


    
}
