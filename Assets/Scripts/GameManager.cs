using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    public bool hasOrangeKey = false;
    public float yKillZone = -7;
    public Transform playerReference;
    public Transform currentCheckPoint;
    private Vector3 playerStartPosition;
    private BrokenFloor[] brokenFloors;
    public TMP_Text textPoints;
    public Image imageOrangeKey;
    public int coloredBoxes = 0;
    public TMP_Text textColoredBoxes;

    [SerializeField] private GameObject[] maxColoredBoxes;

    void Awake()
    {
        playerStartPosition = playerReference.position;
        brokenFloors = FindObjectsOfType<BrokenFloor>();
        imageOrangeKey.enabled = false;
        maxColoredBoxes = GameObject.FindGameObjectsWithTag("CubeChangeColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReference.position.y < yKillZone)
            ResetPlayerPosition();

        textPoints.text = "Collectibles: " + points.ToString() + "/4" ;
        textColoredBoxes.text = "Colored Boxes: " + coloredBoxes.ToString() + "/" + maxColoredBoxes.Length;

        if (hasOrangeKey)
        {
            imageOrangeKey.enabled = true;
        }
    }

    public void ChangeCheckPoint(Transform cp)
    {
        currentCheckPoint = cp;
    }

    public void ResetPlayerPosition()
    {
        playerReference.position = currentCheckPoint != null ? currentCheckPoint.position + new Vector3(0,1,0) : playerStartPosition;
        foreach (BrokenFloor b in brokenFloors)
        {
            b.gameObject.SetActive(true);
            b.ResetFloor();
        }
           
    }
    public void EndGame()
    {
        if (coloredBoxes >= maxColoredBoxes.Length && points == 4)
            SceneManager.LoadScene("WinGame");
    }
}

