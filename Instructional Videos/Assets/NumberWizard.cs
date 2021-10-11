using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
 [SerializeField] int min = 1;
    [SerializeField] int max = 1000;
    int guess = 500;
    [SerializeField] TextMeshProUGUI GuessText;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        NextGuess();
    }
    public void OnPressHigher()
    {
        min = guess +1;
        NextGuess();
    }
    public void OnPressLower()
    {
        max = guess -1;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max +1);
        GuessText.text = guess.ToString();
    }
}
