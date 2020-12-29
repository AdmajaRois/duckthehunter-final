using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;

    private IEnumerator introJingle() {
        yield return new WaitForSeconds(1);
        playSound(0);
        StartCoroutine(bunyiBurung());
    }

    private IEnumerator bunyiBurung() {
        yield return new WaitForSeconds(1);
        playSound(1);
        StartCoroutine(anjingMenyalak());
    }

    private IEnumerator anjingMenyalak() {
        yield return new WaitForSeconds(1);
        playSound(2);
        StartCoroutine(tembakJingle());
    }

    private IEnumerator tembakJingle() {
        yield return new WaitForSeconds(1);
        playSound(3);
    }

    public void playSound(int sound) {
        audioSource.clip = clips[sound];
        audioSource.Play();
    }

    public void pindahGame() {
        SceneManager.LoadScene("Praktikum");
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(introJingle());
    }

    void Update()
    {
        
    }
}
