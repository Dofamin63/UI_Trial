using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private AudioController _audioController;
    private GameManager manager;

    private void Awake()
    {
        _audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           _audioController.PlaySound(_audioController.sound[1], destroyed: true);
            manager.AddStar();
            Destroy(gameObject);
        }
    }
  
}
