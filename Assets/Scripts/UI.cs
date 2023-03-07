using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text wave;
    public Text killCount;

    private GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        wave.text = "Wave #" + (manager.waveMulti);
        killCount.text = "You've killed " + manager.killCount +" aliens";
    }
}
