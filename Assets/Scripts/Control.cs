using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    private Rigidbody2D     _rigidBody;
    private SpriteRenderer  _sprControl;
    private Collider2D      _colider;

    private Vector2         _startPos;
    private Vector2         _pos;
    [SerializeField]
    [Range(10, 50)]
    private float           _edgePos;
    [SerializeField]
    [Range(1, 10)]
    private float           _speed;

    private Log             _log;
    public Vector2 Pos { get { return _pos; } }
    public float EdgePos { get { return _edgePos; } }

    void Start()
    {
        _edgePos    = 30f;
        _speed      = 3.3f;
        _startPos   = Vector2.zero;
        _pos        = Vector2.zero;
        _log        = FindObjectOfType<Text>().GetComponent<Log>();
        _rigidBody  = GetComponent<Rigidbody2D>();
        _sprControl = GetComponentInChildren<SpriteRenderer>();
        _colider    = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
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
    private void FixedUpdate()
    {
        PCMove();
        //CheckScreenBoundaries();
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
        _rigidBody.velocity
            = new Vector2(_speed * Input.GetAxis("Horizontal"), _speed * Input.GetAxis("Vertical"));
    }
    private void CheckScreenBoundaries()
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x + _colider.bounds.size.x/2 > max.x || transform.position.x - _colider.bounds.size.x/2 < min.x)
        {
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }
        if (transform.position.y > max.y || transform.position.y < min.y)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        }
    }
}