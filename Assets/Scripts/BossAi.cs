using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public enum bossStages
    {
        Intro, idle, Sun, Laser, Homing
    }
    bossStages state = bossStages.Intro;

    public float speed;
    public Transform startSpot;
    float waitTime;
    public float startWait;
    public GameObject[] moveSpots;
    int randomSpot;
    float spotWait = 3;
    float stagetime = 15;

    void Start()
    {
        waitTime = startWait;
        moveSpots = GameObject.FindGameObjectsWithTag("MoveSpot");
        randomSpot = Random.Range(0, moveSpots.Length);

    }

 
    void Update()
    {
        switch (state)
        {
            case bossStages.Intro:
                StartCoroutine("IntroState");

                break;

            case bossStages.idle:
                IdleState();
                break;

            case bossStages.Laser:
                StartCoroutine("LaserState");
                break;

            case bossStages.Sun:
                StartCoroutine("SunState");
                break;
        }


    }
    IEnumerator IntroState()
    {
        transform.position = Vector2.MoveTowards(transform.position, startSpot.position, speed * Time.deltaTime);

        yield return new WaitForSeconds(waitTime);
        state = bossStages.idle;
    }

    void IdleState()
    {
        
        

        if (stagetime <= 0)
        {
            int stageSelect = Random.Range(0, 2);

            if (stageSelect == 0)
            {
                stagetime = 15;
                state = bossStages.Sun;
            }
            else if (stageSelect == 1)
            {
                stagetime = 15;
                state = bossStages.Laser;
            }

        }
        else
        {

           
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].transform.position) <= .02f)
            {

                if (spotWait <= 0)
                {
                    
                    randomSpot++;
                    if (randomSpot > moveSpots.Length+1)
                    {
                        Debug.Log(randomSpot);
                        randomSpot = 0;
                    }
                    
                    spotWait = 1;
                }
                else
                {
                    
                    spotWait -= Time.deltaTime;

                }

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].transform.position, speed * Time.deltaTime);

            }
            stagetime -= Time.deltaTime;
        }

    }

    IEnumerator SunState()
    {
        Debug.Log("sunAttack");
            yield return new WaitForSeconds(20);
        state = bossStages.idle;
    }

    IEnumerator LaserState()
    {
        Debug.Log("LaserAttack");
        yield return new WaitForSeconds(20);
        state = bossStages.idle;
    }
}
