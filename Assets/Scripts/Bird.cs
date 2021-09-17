using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool birdWasLaunched;
    private float timeSittingAround;

    [SerializeField] private float _launchPower = 60;

    public void Awake()
    {
        _initialPosition = transform.position;
    }
    private void Update()
    {

        if( birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            timeSittingAround += Time.deltaTime;
        }

        if(transform.position.y > 10 || transform.position.y <-10 || transform.position.x > 10 || transform.position.x < -10 || timeSittingAround >3)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
     
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position; // the difference between initial and current position
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdWasLaunched = true;
       
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y); // z is 0!! 2d game
    }


}
