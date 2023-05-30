using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private LevelGenerator levelGenerator;

    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;

    private float fillAmountStep;

    protected override void Awake()
    {
        base.Awake();
        levelGenerator.OnLevelWasGenerated.AddListener(UpdateAmountSteps);
        currentLevelText.text = PlayerPrefs.GetInt("LevelProgress:currentLevel", levelProgress.CurrentLevel).ToString();
        nextLevelText.text = (PlayerPrefs.GetInt("LevelProgress:currentLevel", levelProgress.CurrentLevel) + 1).ToString();
        Debug.Log(currentLevelText.text);
        progressBar.fillAmount = 0;
    }

    private void UpdateAmountSteps()
    {
        fillAmountStep = 1 / levelGenerator.FloorAmount;
    }

    protected override void OnBallColissionSegment(SegmentType type)
    {
        if(type == SegmentType.Empty || type == SegmentType.Finish)
        {
            progressBar.fillAmount += fillAmountStep;
        }
    }

}
