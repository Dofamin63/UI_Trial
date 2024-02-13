using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private GameManager manager;
    private AudioController _audioController;

    private void Awake()
    {
        _audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // _audioController.PlaySound();
            manager.Exit();
        }
    }
}
