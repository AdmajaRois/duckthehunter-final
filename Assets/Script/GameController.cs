using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    
    public GameObject startPanel;
    public int playerScore = 0;
    public Text hitungTeks;
    public Text hitungNyawa;
    public int ronde = 1;
    public GameObject rondeTeks;
    public Text teksJmlRonde;
    public Text targetTeks;
    public int tembakPerRonde = 3;
    public int nyawa = 2;
    public Text skorGameOverTeks;
    public GameObject[] peluru;

    public GameObject GUITeksScore;
    public GameObject GUITeksNyawa;
    public GameObject GUITargetBidikan;
    public GameObject GUITembak;
    public GameObject GUIAnjing;
    public GameObject GUITeksRonde;
    public GameObject GUIGameOverPanel;
    public GameObject GUIStartPanel;
    public GameObject Terrain;
    public GameObject GUIGun;
    public GameObject GUIAmmos;

    AudioSource audioSource;
    public AudioClip[] clips;

    public int roundTargetScore= 3;
    public int roundScore = 0;
    public int scoreIncrement = 2;
    public bool playerStarted = false;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    void Start() {
        playerScore = int.Parse(hitungTeks.text);
        showStartPanel();
        audioSource = GetComponent<AudioSource>();
        hitungNyawa.text = nyawa.ToString();
    }

    public void showStartPanel(){
        startPanel.SetActive(true);
    }

    public void hideStartPanel(){
        startPanel.SetActive(false);
    }

    void Update() {
        if(DefaultTrackableEventHandler.trueFalse == true) {
            hideStartPanel();
            showItems();

            if(playerStarted == false) {
                StartCoroutine(playRound());
                GUITeksRonde.SetActive(true);
                playFX(0);
            }
            playerStarted = true;
            
        }
        else {
            showStartPanel();
            hideItems();
        }

        if(roundScore == roundTargetScore) {
            playFX(0);
            StartCoroutine(rondeBaru());
            roundScore = 0;
            roundTargetScore += scoreIncrement;
        }

        if(tembakPerRonde == 0) {
            peluru[0].SetActive(false);
            StartCoroutine(hilangNyawa());
            tembakPerRonde = 3;
        }
        hitungTeks.text = playerScore.ToString();
    }

    private IEnumerator rondeBaru() {
        yield return new WaitForSeconds(1);
        ronde++;
        GUITeksRonde.SetActive(true);
        targetTeks.text = "Tembak " + roundTargetScore + " burung";
        teksJmlRonde.text = ronde.ToString();
        StartCoroutine(hideTeksRonde());
    }

    private IEnumerator hilangNyawa() {
        nyawa--;
        if(nyawa == 0) {
            GUITembak.SetActive(false);
            hideItems();
            playFX(1);
            GUIGameOverPanel.SetActive(true);
            skorGameOverTeks.text = playerScore.ToString();
            nyawa = 0;
        }
        else {
            tembakPerRonde = 3;
            GUITembak.SetActive(false);
            playFX(2);
            GUIAnjing.SetActive(true);
            yield return new WaitForSeconds(3);
            GUIAnjing.SetActive(false);
            GUITembak.SetActive(true);
        }
        hitungNyawa.text = nyawa.ToString();
    }

    public IEnumerator playRound()
    {
        yield return new WaitForSeconds(2f);
        targetTeks.text = "Tembak " + tembakPerRonde + " burung";
        StartCoroutine(hideTeksRonde());
    }

    private void playFX(int sound) {
        audioSource.clip = clips[sound];
        audioSource.Play();
    }

    private IEnumerator hideTeksRonde() {
        yield return new WaitForSeconds(3);
        GUITeksRonde.SetActive(false);
    }

    public void tampilPeluru() {
        if(tembakPerRonde == 3) {
            peluru[0].SetActive(true);
            peluru[1].SetActive(true);
            peluru[2].SetActive(true);
        }
        else if(tembakPerRonde == 2) {
            peluru[0].SetActive(true);
            peluru[1].SetActive(true);
            peluru[2].SetActive(false);
        }
        else if(tembakPerRonde == 1) {
            peluru[0].SetActive(true);
            peluru[1].SetActive(false);
            peluru[2].SetActive(false);
    }
}

    public void showItems() {
        GUITeksScore.SetActive(true);
        GUITeksNyawa.SetActive(true);
        GUITargetBidikan.SetActive(true);
        GUITembak.SetActive(true);
        Terrain.SetActive(true);
        GUIAmmos.SetActive(true);
        GUIGun.SetActive(true);
        tampilPeluru();
    }

    public void hideItems() {
        GUITeksScore.SetActive(false);
        GUITeksNyawa.SetActive(false);
        GUITargetBidikan.SetActive(false);
        GUITembak.SetActive(false);
        Terrain.SetActive(false);
        GUIAmmos.SetActive(false);
        GUIGun.SetActive(false);
    }

    public void restart() {
        hideItems();
        nyawa = 2;
        hitungNyawa.text = nyawa.ToString();
        playerScore = 0;
        hitungTeks.text = playerScore.ToString();
        roundTargetScore = 3;
        skorGameOverTeks.text = "0";
        ronde = 1;
        teksJmlRonde.text = ronde.ToString();
        GUIGameOverPanel.SetActive(false);
        StartCoroutine(playRound());
        RaycastController.instance.incr.text = "0";
        RaycastController.instance.tembak = 0;
    }

    public void quit() {
        SceneManager.LoadScene("Intro");
    }
}