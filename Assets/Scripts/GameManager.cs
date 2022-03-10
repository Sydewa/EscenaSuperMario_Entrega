using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    private SFXManager sfxManager;
    private BGMManager bgmManager;
    private int coins;
    public Text coinsText;
    private int goombasKilled;
    public Text goombasText;

    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
    }
    public void MonedaSound()
    {
        sfxManager.MonedaSound();
        coins++;
        coinsText.text = "Coins: " + coins;
        
    }
    public void BanderaSound()
    {
        sfxManager.BanderaSound();
        bgmManager.StopBGM();
        SceneManager.LoadScene(2);

    }

    public void DeathGoomba(GameObject goomba)
    {
        goombasKilled++;
        goombasText.text = "Goombas: " + goombasKilled;

        Animator goombaAnimator;
        Enemy goombaScript;
        BoxCollider2D goombaCollider;
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();
        goombaAnimator.SetBool("GoombaDeath", true);
        goombaScript.isAlive = false;

       /* goombaCollider.size = new Vector2 (1.01f, 0.5f);
        goombaCollider.offset = new Vector2 (0.0f, 0.3f);*/

        goombaCollider.enabled = false;
        Destroy(goomba, 0.3f);

        sfxManager.GoombaSound();
    }
}
