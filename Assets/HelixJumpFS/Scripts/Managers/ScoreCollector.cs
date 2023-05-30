using UnityEngine;
using UnityEngine.UI;

public class ScoreCollector : BallEvents
{
    [SerializeField] LevelProgress levelProgress;

    [SerializeField] private Text bonusText;
    [SerializeField] private int scores;
    public int Scores => scores;

    [SerializeField] private int maxScore = 0;
    public int MaxScore => maxScore;

    protected override void Awake()
    {
        Load("ScoreCollector:scores", 0);

        base.Awake();

    }

    protected override void OnBallColissionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            scores += levelProgress.CurrentLevel;
            int bonus = ballController.CountEmptySegment;
            if (bonus > 1) // ballCOntroller наследуется из BallEvents ([SerializeField] protected BallController ballController;)
            {
                scores += bonus;
                bonusText.text = "+" + bonus.ToString();
                bonusText.enabled = true;

                Invoke("BonusText", 1f);
            }
        }
        if(type == SegmentType.Finish)
        {
            if (scores > maxScore)
            {
                Debug.Log("MAXSAVE!");
                maxScore = scores;
                Save("ScoreCollector:scores", maxScore);
            }
        }
    }

    private void BonusText()
    {
        bonusText.text = "";
        bonusText.enabled = false;
    }

    private void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    private void Load(string key, int value)
    {
        maxScore = PlayerPrefs.GetInt(key, value);
    }
}
