using System.Collections;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{

    [Header("Spaceship variables")]
    public GameObject soldierSpaceship;
    public GameObject hunterSpaceship;
    public Transform parentSoldierSpaceship;
    public Transform parentHunterSpaceship;

    [Header("Player UI")]
    public float timeValue = 300;
    public float reputationValue = 150;
    [SerializeField] bool stopIncreasingReputation;

    [Header("Reference variables")]
    public TMP_Text timerText;
    public TMP_Text reputationCounterText;



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
            stopIncreasingReputation = false;
            AudioManager.instance.StopMainMenuSound();
            AudioManager.instance.GameOverSound();
            GetComponent<GameOverMenu>().enabled = true;

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