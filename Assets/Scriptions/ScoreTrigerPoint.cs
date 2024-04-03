 
using TMPro;
using UnityEngine; 

public class ScoreTrigerPoint : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI score;

    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private GameObject gameOver;

    private float seconds = 0;
    private int currentMinutes = 0;

    private int currentScore = 0;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        UpdateTime();   
    }
    public  void IncreaseScore()
    {
        currentScore += 1;
        score.text = "Score: " + currentScore.ToString(); 
    }
    private void UpdateTime()
    {
        seconds += Time.deltaTime;

        if (seconds >= 60)
        {
            currentMinutes += 1;
            seconds -= 60f;
        } 
        time.text = string.Format("{0:00}:{1:00}", currentMinutes, seconds); 
        CheckTimer();
    }
    private void CheckTimer()
    {
        if(currentMinutes >= 3)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
}
