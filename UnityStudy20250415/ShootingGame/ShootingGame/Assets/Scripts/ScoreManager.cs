using UnityEngine;
// 유니티 UI를 사용하기 위한 네임스페이스
using UnityEngine.UI;
    
public class ScoreManager : MonoBehaviour
{
    // 싱글턴 객체
    public static ScoreManager Instance = null;

    // 현재 점수 UI
    public Text currentScoreUI;
    // 현재 점수
    private int currentScore;

    // 최고 점수 UI
    public Text bestScoreUI;
    // 최고 점수
    private int bestScore;

    // 싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 목표: 최고 점수를 불러와 bestScore 변수에 할당하고 화면에 표시한다.
        // 순서: 1. 최고 점수를 불러와 bestScore에 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        // 2. 최고 점수를 화면에 표시하기
        bestScoreUI.text = "최고 점수: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Score
    {
        // currentScore 값 가져오기
        get
        {
            return currentScore;
        }
        // currentScore에 값을 넣고 화면에 표시하기
        set
        {
            // 3. ScoreManager 클래스의 속성에 값을 할당한다.
            currentScore = value;
            // 4. 화면에 현재 점수 표시하기
            currentScoreUI.text = "현재 점수: " + currentScore;

            // 목표: 최고 점수를 표시하고 싶다.
            // 1. 현재 점수가 최고 점수보다 크니까
            // -> 만약 현재 점수가 최고 점수를 초과했다면
            if (currentScore > bestScore) {
                // 2. 최고 점수를 갱신시칸다.
                bestScore = currentScore;
                // 3. 최고 점수 UI에 표시
                bestScoreUI.text = "최고 점수: " + bestScore;
                // 목표: 최고 점수를 저장하고 싶다.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
