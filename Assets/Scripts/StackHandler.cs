using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] 
    private GameObject CenterColumn;
    [SerializeField] 
    private GameObject PreviousColumn;
    /*[SerializeField] 
    private Camera camera;*/
    [SerializeField] 
    private GameObject LeftCollider;
    [SerializeField] 
    private GameObject RightCollider;
    [SerializeField] 
    private GameObject background;
    [SerializeField] 
    private TMP_Text scoreUI;
    [SerializeField] 
    private GameObject GameOverUI;

    [SerializeField] private GameObject maxHeightLine;

    public static float multiplier = 1;
    private GameObject originalPreviousSquare;

    private void Start()
    {
        maxHeightLine.SetActive(true);
        maxHeightLine.transform.position = new Vector3(maxHeightLine.transform.position.x,
            maxHeightLine.transform.position.y + PlayerPrefs.GetInt("highScore"), 0);
        originalPreviousSquare = PreviousColumn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (CenterColumn == null)
            {
                CenterColumn = GameManager.userSquare;
            }

            if (PreviousColumn == null)
            {
                PreviousColumn = originalPreviousSquare;
            }
            var currentColumnRight = CenterColumn.transform.position.x + (CenterColumn.transform.localScale.x/2);
            var currentColumnLeft = CenterColumn.transform.position.x - (CenterColumn.transform.localScale.x/2);
            var PreviousColumnRight = PreviousColumn.transform.position.x + (PreviousColumn.transform.localScale.x/2);
            var PreviousColumnLeft = PreviousColumn.transform.position.x - (PreviousColumn.transform.localScale.x/2);

            if (currentColumnLeft > PreviousColumnRight || currentColumnRight < PreviousColumnLeft)
            {
                multiplier = 1;
                GameManager.userSquare = CenterColumn;
                LeftCollider.SetActive(false);
                RightCollider.SetActive(false);
                GameOverUI.SetActive(true);
            }
            else
            {

                GameObject dup = GameObject.Instantiate(CenterColumn);
                LeftCollider.GetComponent<LeftCollider>().centerColumn = dup;
                RightCollider.GetComponent<RightCollider>().centerColumn = dup;
                
                dup.transform.position =
                    new Vector3(CenterColumn.transform.position.x, CenterColumn.transform.position.y + 1);
                if (currentColumnRight > PreviousColumnRight)
                {
                    
                    dup.transform.localScale = new Vector3(Math.Abs(currentColumnLeft - PreviousColumnRight), 1, 1);
                } else if (currentColumnLeft < PreviousColumnLeft)
                {
                    dup.transform.localScale = new Vector3(currentColumnRight - PreviousColumnLeft, 1, 1);
                }

                LeftCollider.transform.Translate(0, 1f, 0);
                RightCollider.transform.Translate(0, 1f, 0);
                PreviousColumn = CenterColumn;
                CenterColumn = dup;
                scoreUI.text = (Int32.Parse(scoreUI.text) + 1).ToString();
                multiplier += 0.25f;
                if (Camera.main.transform.position.y < CenterColumn.transform.position.y)
                {
                    StartCoroutine(updateBackgroundPosition(new Vector3(background.transform.position.x, background.transform.position.y + 0.5f)));
                    StartCoroutine(updateCameraPosition(new Vector3(Camera.main.transform.position.x, CenterColumn.transform.position.y)));
                }
            }
        }
    }

    IEnumerator updateBackgroundPosition(Vector3 targetPosition)
    {
        while (background.transform.position.y <targetPosition.y)
        {
            background.transform.Translate(0, 0.012f, 0);
            yield return new WaitForSeconds(0.025f);
        }
    }
    
    IEnumerator updateCameraPosition(Vector3 targetPosition)
    {
        while (Camera.main.transform.position.y <targetPosition.y)
        {
            Camera.main.transform.Translate(0, 0.025f, 0);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
