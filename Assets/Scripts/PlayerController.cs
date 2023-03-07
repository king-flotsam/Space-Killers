using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public float clamping = 12f;
    public Vector3 bounds = new Vector3(12, 0, 0);
    public float speed;
    private float delay;
    private bool spawned = false;

    private void Update()
    {
        Movement();
        ShootCannon();
        Reset();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && player.transform.position.x < bounds.x)
        {
            player.transform.Translate(new Vector3(horizontal * Time.deltaTime * speed, 0, 0));
        }
        if (horizontal < 0 && player.transform.position.x > -bounds.x)
        {
            player.transform.Translate(new Vector3(horizontal * Time.deltaTime * speed, 0, 0));
        }
    }
    private void ShootCannon()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spawned)
        {
            delay = .5f;
            Instantiate(prefab);
            spawned = true;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !spawned)
        {
            delay = .5f;
            Instantiate(prefab);
            spawned = true;
        }
    }
    private void Reset()
    {
        if (spawned && delay > 0)
        {
            delay -= Time.deltaTime;
        }
        if (delay < 0)
        {
            delay = 0;
            spawned = false;
        }
    }
}
