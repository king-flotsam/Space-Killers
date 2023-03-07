using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int wave = 8;
    public int waveMulti = 0;
    public int killCount = 0;

    [SerializeField]
    private GameObject[] enemyPrefabs;
    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Victory");
        spawnLocation.position = new Vector3(11f, 36f, -2.25f);
    }

    // Update is called once per frame  
    void Update()
    {
        
        if (transform.childCount == 0)
        {
            
            FindObjectOfType<AudioManager>().Play("Victory");
            StartCoroutine(Waves());
        }
    }

    public IEnumerator Waves()
    {
        Debug.Log(waveMulti);
        waveMulti++;
        Debug.Log("waves = " + wave);
        for (int i = 0; i < wave * waveMulti; i++)
        {
            Instantiate(enemyPrefabs[waveMulti - 1], spawnLocation);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("i = " + i);
        }
        StopCoroutine(Waves());
    }
}
