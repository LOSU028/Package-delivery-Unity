using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class Referee : MonoBehaviour
{
    [SerializeField] public int packagesLeft;
    [SerializeField] private Text wintext;   
    [SerializeField] private Text losetext;  
    private float timeLeft;
    OnCollision delivery;
    Timer timer;
    [SerializeField] private GameObject deliver;
    [SerializeField] private GameObject aux_timer;

    // Start is called before the first frame update
    void Awake() {
        delivery  = deliver.GetComponent<OnCollision>();
        timer = aux_timer.GetComponent<Timer>(); 
        timeLeft = timer.totalTime;
        packagesLeft = delivery.packagesLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timer.timer;
        packagesLeft = delivery.packagesLeft;
        if(timeLeft == 0){
            Debug.Log("You ran out of time!");
            losetext.enabled = true;
            Time.timeScale = 0;
        }
        if (packagesLeft == 0){
            Debug.Log("Congrats, you delivered all the packages!");
            wintext.enabled = true;
            Time.timeScale = 0;
        }
    }
}
