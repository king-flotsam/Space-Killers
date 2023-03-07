using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 maxBound = new Vector3(12, 0, 0);
    public Vector3 minBound = new Vector3(-12, 0, 0);
    public float speed;
    public bool movementDir = false;

    private GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (transform.position.x < maxBound.x && movementDir == false)
        {
            MoveLeft();
        }
        if (transform.position.x <= minBound.x)
        {
            movementDir = true;
            transform.position += Vector3.down * 2;
            speed *= 1.1f;
            MoveRight();
        }

        if (transform.position.x > minBound.x && movementDir == true)
        {
            MoveRight();
        }

        if (transform.position.x >= maxBound.x)
        {
            movementDir = false;
            transform.position += Vector3.down * 2;
            speed *= 1.1f;
            MoveLeft();
        }
        if (transform.position.y <= 0)
        {
            speed = 0;
        }
    }
    void MoveLeft()
    {
        transform.Translate(new Vector3(1 * Time.deltaTime * speed, 0, 0));
    }
    void MoveRight()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Enemy Death");
            Debug.Log("Hit by a bullet!");
            manager.killCount++;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Player Death");
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
    }
}
