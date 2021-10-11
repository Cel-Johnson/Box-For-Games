using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour
{
    private float itsJustZeroPointOne = 0.05f;

    [Range(0.1f, 10f)] [SerializeField] float gamespeed = 1f;
   

    [SerializeField] float pointsPerBlockDestroyed = 10f;


    [SerializeField] float currentScore= 0f;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] float timeTilReset = 3f;

    [SerializeField] float scoremulti = 1f;

    public float timer = 0;

     [SerializeField] bool isAutoPlayEnabled = false;

    [SerializeField] bool godMode = false;

    void Update()
    {
        Time.timeScale = gamespeed;

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0f;
            //time to fight god himself because speeding up time is a bad idea

            if (godMode == true)
            {
                gamespeed = gamespeed + 0.05f;
            }
            else
            {
                gamespeed = gamespeed + 0.005f;
            }


            if (timeTilReset > 0f)
            timeTilReset = timeTilReset - 1f;
           
        }
        if (timeTilReset <= 0)
        {
            scoremulti = 1f;
        }
    }

    private void Start()
    {
        Score();
        if (godMode == true)
        {
            gamespeed = 2f;
        }
        else
        {
            gamespeed = 1f;
        }
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void AddToScore()
    {

        currentScore += pointsPerBlockDestroyed;

        float multiplyer = pointsPerBlockDestroyed * scoremulti;
        pointsPerBlockDestroyed = multiplyer;

        scoremulti = scoremulti + itsJustZeroPointOne;

        timeTilReset = 3f;

        Score();
    }

    private void Score()
    {
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
