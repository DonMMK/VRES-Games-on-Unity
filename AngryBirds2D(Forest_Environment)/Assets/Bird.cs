using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition; // This is a private variable // Only public need to be declared
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;



    // what happens when 
    private void Awake()
    {
        _initialPosition = transform.position; //saves the initial position of the bird when the game start
    }

    // Gets called once per frame
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        
        if ( _birdWasLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 ) 
        {
            _timeSittingAround += Time.deltaTime; // Time updated since the last frame // Calc = 1/frame rate
        }


        if (transform.position.y > 15  ||
            transform.position.y < -15 ||
            transform.position.x > 15  ||
            transform.position.x < -15 ||
            _timeSittingAround > 1.8)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName); // Learning to use the scene manager
        }
    }
    // What happens when the mouse is "clicked" down
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    // What happens when the mouse is "let go" up
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower); // vector2 * float
        GetComponent<Rigidbody2D>().gravityScale = 1; // Calling get component is slow. For now it's alright
        //When the bird is launched
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    // What happens when the mouse is dragged
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
