using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;

    public void Awake()
    {
        _initialPosition = transform.position;
    }
    private void Update()
    {
        if(transform.position.y > 10)
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
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 600);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y); // z is 0!! 2d game
    }


}
