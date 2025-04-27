using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 싱글턴 객체
    public static EnemyManager Instance = null;

    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    public List<GameObject> enemyObjectPool;
    // SpawnPoint들
    public Transform[] spawnPoints;

    // 생성할 최소 시간
    public float minTime = 0.5f;

    // 생성할 최대 시간
    public float maxTime = 1.5f;

    // 현재 시간
    float currentTime;

    // 일정 시간
    public float createTime = 1;

    // 적 공장
    public GameObject enemyFactory;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // 1. 태어날 때
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);

        // 2. 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다.
        enemyObjectPool = new List<GameObject>();
        // 3. 오브젝트 풀에 넣을 에너미 개수만큼 반복해
        for (int i = 0; i < poolSize; i++) {
            // 4. 에너미 공장에서 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. 에너미를 오브젝트 풀에 넣고 싶다.
            enemyObjectPool.Add(enemy);
            // 비활성화시키자.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 2. 생성 시간이 되었으니까
        if (currentTime > createTime) {
            // 3. 오브젝트풀에 에너미가 있다면
            if (enemyObjectPool.Count > 0) {
                // 오브젝트풀에서 enemy를 가져다 사용하도록 한다.
                GameObject enemy = enemyObjectPool[0];
                // 오브젝트풀에서 에너미 제거
                enemyObjectPool.Remove(enemy);
                // 랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);
                // 에너미 위치시키기
                enemy.transform.position = spawnPoints[index].position;
                // 에너미를 활성화하고 싶다.
                enemy.SetActive(true);
            }

            // 적을 생성한 후 적의 생성 시간을 다시 설정하고 싶다.
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
