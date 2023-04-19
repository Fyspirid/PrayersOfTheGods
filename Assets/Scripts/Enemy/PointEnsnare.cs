using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnsnare : MonoBehaviour
{
    public Monster monster;
    private bool isRunning = false;
    [SerializeField] private AudioClip roar;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRunning = true;
            audioSource.PlayOneShot(roar);
            Invoke("Destroyed", 3f);
        }
    }
    private void Update()
    {
        if (isRunning) 
        {
            monster.RunMonster();
        }
    }
    private void Destroyed()
    {
        Destroy(gameObject);
    }
}
