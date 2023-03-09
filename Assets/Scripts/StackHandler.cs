using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject GameOverUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var currentColumnRight = CenterColumn.transform.position.x + CenterColumn.transform.localScale.x;
            var currentColumnLeft = CenterColumn.transform.position.x - CenterColumn.transform.localScale.x;
            var PreviousColumnRight = PreviousColumn.transform.position.x + PreviousColumn.transform.localScale.x;
            var PreviousColumnLeft = PreviousColumn.transform.position.x - PreviousColumn.transform.localScale.x;
            
            if (currentColumnLeft > PreviousColumnRight || currentColumnRight < PreviousColumnLeft)
            {
                Debug.Log("Game Over");
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
                    dup.transform.localScale = new Vector3(PreviousColumnRight - CenterColumn.transform.position.x, 1, 1);
                } else if (currentColumnLeft < PreviousColumnLeft)
                {
                    dup.transform.localScale = new Vector3(PreviousColumnLeft + CenterColumn.transform.position.x, 1, 1);
                }

                LeftCollider.transform.Translate(0, 1f, 0);
                RightCollider.transform.Translate(0, 1f, 0);
                PreviousColumn = CenterColumn;
                CenterColumn = dup;
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
