using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool _CanRun;
    public bool _CanJump;
    public int _NextLvl;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void _EndLvl()
    {
        SceneManager.LoadScene(string.Format("Plvl{0}",_NextLvl ));
    }
    public void _QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void _Retry()
    {
        Debug.Log("Yes");
        SceneManager.LoadScene(string.Format("Plvl{0}", (_NextLvl - 1)));
        ;

    }
    public void _JumpUI()
    {
       
        GameObject.Find("CowBoy").GetComponent<CowBoyCtrl>()._Jump();
    }
    }
