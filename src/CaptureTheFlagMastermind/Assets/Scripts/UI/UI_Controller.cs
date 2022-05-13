using System.Collections;
using UnityEngine;
using TMPro;


public class UI_Controller : MonoBehaviour
{

    //variables for the diferent spaceships
    public GameObject soldierSpaceship, hunterSpaceship;
    public Transform parentSoldierSpaceship, parentHunterSpaceship;

    //variables of the diferent values
    public float timeValue = 300;
    public float reputationValue = 150;
    private bool stopIncreasingReputation;

    //variables for the timer and reputation text
    public TMP_Text timerText;
    public TMP_Text reputationCounterText;

    //reference to the gameobjects
    public GameObject endGameScreen;
    public GameObject playerUI;
    public GameObject unitSelectionSystem;

    //reference to the audiosource
    public AudioSource gameoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        stopIncreasingReputation = true;
        StartCoroutine(ReputationCounterIncreasing());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }




    public void BuildHunterSpaceship()
    {
        if (reputationValue >= 50)
        {
            reputationValue -= 50;
            Instantiate(soldierSpaceship, parentSoldierSpaceship.position, Quaternion.identity);
        }
    }


    public void BuildSoldierSpaceship()
    {
        if (reputationValue >= 100)
        {
            reputationValue -= 100;
            Instantiate(hunterSpaceship, parentHunterSpaceship.position, Quaternion.identity);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {

            timeToDisplay = 0;
            Time.timeScale = 0f;
            stopIncreasingReputation = false;
            endGameScreen.SetActive(true);
            playerUI.SetActive(false);
            unitSelectionSystem.SetActive(false);
            gameoverAudio.Play();



        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        reputationCounterText.text = reputationValue.ToString();

    }


    private IEnumerator ReputationCounterIncreasing()
    {
        while (stopIncreasingReputation)
        {
            yield return new WaitForSeconds(1);
            reputationValue += 2;
        }
    }
}