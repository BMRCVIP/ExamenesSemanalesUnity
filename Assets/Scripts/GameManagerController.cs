using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManagerController : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    //public Text monedasText;


    private int score;
    private int lives;
    //private int monedas;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 0;
        //monedas = 0;
        PrintInScreenScore();
        PrintInScreenLives();
        LoadGame();
    }
    
    public void SaveGame(){
        var filePath = Application.persistentDataPath + "/save1.dat";
        FileStream file;
        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else
            file = File.Create(filePath);
        GameData data = new GameData();
        data.Puntaje = score;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadGame(){
         var filePath = Application.persistentDataPath + "/save1.dat";
        FileStream file;
        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }else{
            Debug.LogError("No existe el archivo");
            return; 
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();
        score = data.Puntaje;
        PrintInScreenScore();
        }


    public int Score(){
        return score;
    }
    public int Lives(){
        return lives;
    }
    /*public int Monedas(){
        return monedas;
    }*/
    public void GanarPuntos(int puntos)
    {
        score += puntos;
        PrintInScreenScore();
    }
     public void PerderVida()
    {
        lives -= -10;
        PrintInScreenLives();
    }
    /*public void GanarMonedas(int monedas)
    {
        monedas += monedas;
        PrintInScreenMonedas();
    }
    private void PrintInScreenMonedas()
    {
        monedasText.text = "Monedas: " +monedas;
    }*/
        
    private void PrintInScreenScore()
    {
        scoreText.text = "Puntaje Monedas: "+score;
    }
     private void PrintInScreenLives()
    {
        livesText.text = "Puntaje Enemigos: "+lives;
    }
}
