using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject _Player;
   public float _YU = 1;
    //public float _xAxis = 1;
    //public float _zAxis = 1;


    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindWithTag(a.PlayerTag);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_Player.transform.position.x, _Player.transform.position.y , _Player.transform.position.z - _YU);
    }
}
