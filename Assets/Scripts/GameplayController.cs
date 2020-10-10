using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private GameObject score;

    public BoxSpawner box_Spawner;

    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    public Text scoreText;
    public int currentScore = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();

        score = GameObject.FindWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((Input.mousePosition.y <= 1600) && (ScreenSwitcher.GameIsPaused == false))
            {
                currentBox.DropBox();
            }
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 0f);
    }

    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera2()
    {
        Invoke("MoveCamera", 0.7f);
    }
    public void MoveCamera()
    {
        cameraScript.targetPos.y += 1f;

        score.GetComponent<Score>().AddScore();
        currentScore++;
        //scoreText.text = currentScore.ToString();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
