using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lifecounter : MonoBehaviour
{
    GameObject health;
    float hp = 1;
    public float deathTime;
    public float iTime;
    int nomliv;
    public int liv = 1;
    GameObject die;
    bool isHurt;
    public SpriteRenderer sR;
    public SpriteRenderer sR2;
    Transform sp;
    public GameObject shootp;
    AudioSource audi;
    public AudioClip death;
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        health = GameObject.Find("Lives");
        nomliv = liv;
        die = GameObject.Find("Dead");
        die.SetActive(false);
        sp = GameObject.Find("Start point").transform;
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        health.GetComponent<Text>().text = nomliv + " X";

    }

    public void hurt()
    {
        hp--;
     StartCoroutine("Hurt");
    }

    public void heal()
    {
        nomliv++;
    }

    IEnumerator Death()
    {
        gameManager.GetComponent<GameManager>().SaveScore();
        GetComponent<Player>().enabled = false;
        die.SetActive(true);

        BoxCollider2D bC = GetComponent<BoxCollider2D>();

        if(!audi.isPlaying)
        audi.PlayOneShot(death);
        sR.enabled = false;
        sR2.enabled = false;
        bC.enabled = false;
        shootp.SetActive(false);
        yield return new WaitForSeconds(death.length);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Hurt()
    {
        hp--;
        isHurt = true;
        
        BoxCollider2D bC = GetComponent<BoxCollider2D>();

        audi.PlayOneShot(death);
        sR.enabled = false;
        sR2.enabled = false;
        bC.enabled = false;
        shootp.SetActive(false);


        yield return new WaitForSeconds(deathTime);

        transform.position = sp.position;
        isHurt = false;
        hp = 1;
        sR.enabled = false;
        sR2.enabled = false;
        shootp.SetActive(true);

        nomliv -= 1;
        if (nomliv <= 0)
        {
            StartCoroutine("Death");
        }
        else
        {
        int flash = 0;
        int flashcount = 7;

        while (flash < flashcount)
        {

            flash++;
            yield return new WaitForSeconds(iTime);
            sR.enabled = flash % 2 == 1;
            sR2.enabled = flash % 2 == 1;
            hp = 1;

        }
        if (flash == flashcount)
        {
            bC.enabled = true;
        }
        }
    }


}
