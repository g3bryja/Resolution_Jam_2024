using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager instance;
    
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    float punchForce = 1.2f;
    
    [SerializeField]
    float punchDuration = 0.3f;
    

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Player scoring
    private int score;
    public int Score { get { return score; } }

    public void AddScore(int value) {
        score += value;
        UpdateScore();
    }

    public void SubtractScore(int value) {
        score -= value;
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = score.ToString();
        if (DOTween.IsTweening(scoreText.transform)) {
            DOTween.Kill(true, transform);
        }
        scoreText.transform.DOPunchScale(Vector3.one * punchForce, punchDuration, 1, 0);
    }
}
