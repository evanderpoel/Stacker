using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject userSquare;
    [SerializeField] private GameObject centerColumn;
    [SerializeField] private GameObject leftCollider;
    [SerializeField] private GameObject rightCollider;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject stackHandler;
    [SerializeField] private GameObject background;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private GameObject inGameUI;

    private Vector3 userSquarePosition;
    private Vector3 userSquareScale;
    private Vector3 leftColliderPosition;
    private Vector3 rightColliderPosition;
    private Vector3 mainCameraPosition;
    private Vector3 backgroundPosition;

    public static List<GameObject> centerColumns = new List<GameObject>();
    
    void Start()
    {
        userSquare = centerColumn;
        userSquarePosition = userSquare.transform.position;
        userSquareScale = userSquare.transform.localScale;
        leftColliderPosition = leftCollider.transform.position;
        rightColliderPosition = rightCollider.transform.position;
        mainCameraPosition = mainCamera.transform.position;
        backgroundPosition = background.transform.position;
    }

    public void restGame()
    {
        resetGameState();
        //inGameUI.SetActive(true);
    }

    public void gameOverToMainMenu()
    {
        resetGameState();
        stackHandler.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    private void resetGameState()
    {
        userSquare.transform.position = userSquarePosition;
        userSquare.transform.localScale = userSquareScale;
        leftCollider.transform.position = leftColliderPosition;
        leftCollider.SetActive(true);
        rightCollider.transform.position = rightColliderPosition;
        mainCamera.transform.position = mainCameraPosition;
        gameOverUI.SetActive(false);
        background.transform.position = backgroundPosition;
        scoreUI.text = "0";
        foreach (var column in centerColumns)
        {
            Destroy(column);   
        }
    }

}
