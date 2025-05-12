using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject _joyStick;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void _StartGame()
    {
        SceneManager.LoadScene("Plvl0");
    }
    public void _Pause()
    {
        GameObject.Find("CowBoy").GetComponent<CowBoyCtrl>()._CanRun = false;
        GameObject.Find("CowBoy").GetComponent<CowBoyCtrl>()._isGrounded = false;


    }

    public void _Resum()
    {
        GameObject.Find("CowBoy").GetComponent<CowBoyCtrl>()._CanRun = true;
        GameObject.Find("CowBoy").GetComponent<CowBoyCtrl>()._isGrounded = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void _DesertScene()
    {
        SceneManager.LoadScene("Desert");
    }
    public void _FarestScene()
    {
        SceneManager.LoadScene("Farest");
    }
    public void _SnowScene()
    {
        SceneManager.LoadScene("Snow");
    }
    public void _GraveScene()
    {
        SceneManager.LoadScene("Grave");
    }
    public void _lvlMenu()
    {
        SceneManager.LoadScene("lvlManager");
    }
}
