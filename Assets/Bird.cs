using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    //define private variable using underscore
    private Vector3 _initialPosition;
    private bool _birdWaslaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        

        if (_birdWaslaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 || 
            transform.position.y < -10 || 
            transform.position.x > 50 ||
            transform.position.x < -50 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToIntialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToIntialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWaslaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newposition.x, newposition.y);
    }

}
