using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public enum CowBowStat { Idle,Run,Jump,Die,Slide};
public class CowBoyCtrl : MonoBehaviour
{

    #region
    public Rigidbody2D _Rb;
    public float _Speed = 5;
    public float _CBJumpPower = 10;
    public float _CBSlidePower = 100;
    
    public bool _isGrounded = false;
    public bool _CanJump = true;
    public bool _CanRun = true;
    public GameObject _Pausemenu;


    public GameObject _Die;


    [SerializeField]
    private CowBowStat _MyStat;
    public Animator _CBAnimCtrl;


    public AudioSource _AudioSource;
    public AudioClip _jumpSound;
    public AudioClip _WaterSound;
    public AudioClip _FallSound;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //_CBAnimCtrl.SetBool("isRunning", false); 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
        if (collision.collider.CompareTag(a.DieTag))
        {
            _AudioSource.PlayOneShot(_FallSound);
            _Pausemenu.SetActive(true);
            _CanRun = false;
            
            Destroy(this.gameObject);
            Instantiate(_Die, transform.position, Quaternion.identity);
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(a.RiverTag))
        {
            _AudioSource.PlayOneShot(_WaterSound);
            _Pausemenu.SetActive(true);
            _CanRun = false;
            _CBAnimCtrl.SetTrigger("Die");
            
        }
           
        if (collision.tag.Equals(a.EndSingTag))
        {
            GameObject.Find("TitleManager").GetComponent<TitleManager>()._lvlMenu();
        }
            
    }

    private void Update()
    {
        // _slide();
        _Movement();

        //_Jump();
       
    }
    //IEnumerator _JumpCD()
    //{
    //    yield return new WaitForSeconds(0.001f);
    //    _CanJump = true;
    //}
    //private void _slide()
    //{
    //    if (Input.GetKey(KeyCode.R) && _isGrounded)
    //    {
    //        _CBAnimCtrl.SetTrigger("Slide");
    //        _Rb.AddForce(new Vector2(_CBSlidePower, 0));
    //    } 
    //}
    private void _Movement()
    {


        if (_CanRun) { 
            float XAxis = CrossPlatformInputManager.GetAxis("Horizontal");
           
            Vector2 CurrentSpeed = new Vector2(XAxis * _Speed, _Rb.velocity.y);
            _Rb.velocity = CurrentSpeed;

            if (_Rb.velocity.x != 0)
            {
                _CBAnimCtrl.SetBool("isRunning", true);
            }
            else
            {
                _CBAnimCtrl.SetBool("isRunning", false);
            }
            if (_Rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                if (_Rb.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
          } 
          } 
    public void _Jump()
    {
            
                if (  _isGrounded)
                {
            _AudioSource.PlayOneShot(_jumpSound);
                //StartCoroutine(_JumpCD());
                _CBAnimCtrl.SetTrigger("Jump");
                _Rb.AddForce(Vector2.up*_CBJumpPower,ForceMode2D.Impulse);
                //_CanJump = false;
                
            
        }
    }
}
