using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private GameObject player;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Cannon");
        player = GameObject.Find("Player");
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime,0);
        if(transform.position.y >= 45f)
        {
            Destroy(this.gameObject);
        }
    }
}
