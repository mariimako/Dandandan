using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//when called, first gamemanager finds in the scene
    private void Awake()
    {
        if(GameManager.instance != null)
        {
           Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;//will fire this function once event is fired
        DontDestroyOnLoad(gameObject);
    }
    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    //references
    public player player;
    public FloatingTextManager floatingTextManager;
    //public weapon weapon...   
    
    //Logic
    public int pesos;
    public int experience; 

    //floating text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {//any obejct can now use it
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    //saving
    public void SaveState()
    {
        string s ="";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //eg we have "0|15|2|10"--> turns into string array

        //change player skin...
        //pesos
        pesos = int.Parse(data[1]); //caste into int from string
        experience = int.Parse(data[2]); //caste into int from string

        Debug.Log("LoadState");

    }
}
