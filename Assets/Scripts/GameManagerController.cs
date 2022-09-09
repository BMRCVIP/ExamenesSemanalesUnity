using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    private int score;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
        PrintInScreenScore();
        PrintInScreenLives();
    }
    public int Score(){
        return score;
    }
    public int Lives(){
        return lives;
    }
    public void GanarPuntos(int puntos)
    {
        score += puntos;
        PrintInScreenScore();
    }
     public void PerderVida()
    {
        lives -= 1;
        PrintInScreenLives();
    }
    private void PrintInScreenScore()
    {
        scoreText.text = "Balas: "+score;
    }
     private void PrintInScreenLives()
    {
        livesText.text = "Vida: "+lives;
    }
}
