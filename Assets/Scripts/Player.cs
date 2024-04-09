using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    { 
        get { return _isRunning; } 
        set {  _isRunning = value; } 
    }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {

        OnRun();
    }

    private void FixedUpdate()
    {
        OnInput();

        OnMove();
    }

    #region Movement

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    #endregion
}
