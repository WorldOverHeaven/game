using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int scoreGame = 0;

    public void AddScore()
    {
        scoreGame += 1;
    }

    void OnGUI()
    {
        GUIStyle styleTime = new GUIStyle();

        styleTime.fontSize = 70;

        GUI.Box(new Rect(90, 10, 400, 200), "Score " + scoreGame.ToString(), styleTime);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
