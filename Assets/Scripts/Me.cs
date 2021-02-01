using UnityEngine;
using UnityEngine.UI;

public class Me : MonoBehaviour
{
    private Rigidbody2D     _rigidBody;
    private SpriteRenderer  _sprControl;

    private Vector2         _startPos;
    private Vector2         _pos;
    [SerializeField]
    [Range(10, 50)]
    private float           _edgePos;
    [SerializeField]
    [Range(50, 100)]
    private float           _speed;
    private bool            _isControl;

    private Log             _log;
    public Vector2 Pos { get { return _pos; } }
    public float EdgePos { get { return _edgePos; } }

    void Start()
    {
        transform.localScale = new Vector2(40, 40);
        _isControl  = true;
        _edgePos    = 30f;
        _speed      = 90f;
        _startPos   = Vector2.zero;
        _pos        = Vector2.zero;
        _log        = FindObjectOfType<Text>().GetComponent<Log>();
        _rigidBody  = GetComponent<Rigidbody2D>();
        _sprControl = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Control();
    }
    private void Control()
    {
        PCMove();
        SensoreMove();
    }
    private void SensoreMove()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                _startPos = touch.position;
                DrawControl();
                break;
                case TouchPhase.Moved:
                Move(touch);
                break;
                case TouchPhase.Ended:
                StopMove();
                break;
            }
        }
        _log.Control(this);
    }
    private void Move(Touch touch)
    {
        Vector2 fullPos = _startPos - touch.position;
        if (-_edgePos <= fullPos.x && fullPos.x <= _edgePos)
        {
            _pos.x = fullPos.x / -_edgePos;
        }
        else
        {
            _pos.x = -fullPos.x / Mathf.Abs(fullPos.x);
        }
        if (-_edgePos <= fullPos.y && fullPos.y <= _edgePos)
        {
            _pos.y = fullPos.y / -_edgePos;
        }
        else
        {
            _pos.y = -fullPos.y / Mathf.Abs(fullPos.y);
        }
        _rigidBody.velocity = new Vector2(_speed * _pos.x, _speed * _pos.y);
    }
    private void StopMove()
    {
        _pos = Vector2.zero;
        _rigidBody.velocity = new Vector2(_speed * _pos.x, _speed * _pos.y);
        _sprControl.enabled = false;
    }
    private void DrawControl()
    {
        _sprControl.transform.position = _startPos;
        _sprControl.transform.localScale = new Vector3(_edgePos / 100, _edgePos / 100, 0);
        _sprControl.enabled = true;
    }
    private void PCMove()
    {
        if(_isControl)
        {
            _rigidBody.velocity
                = new Vector2(_speed * Input.GetAxis("Horizontal"),
                              _speed * Input.GetAxis("Vertical"));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _isControl = false;
        _rigidBody.velocity = Vector2.zero;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        transform.position 
            = Vector2.MoveTowards(transform.position, other.transform.position, _speed * Time.deltaTime);
        if(transform.position == other.transform.position)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _isControl = true;
    }
}