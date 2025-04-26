using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    GameObject[] enemyObjectPool;
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

    // 1. 태어날 때
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);

        // 2. 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다.
        enemyObjectPool = new GameObject[poolSize];
        // 3. 오브젝트 풀에 넣을 에너미 개수만큼 반복해
        for (int i = 0; i < poolSize; i++) {
            // 4. 에너미 공장에서 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. 에너미를 오브젝트 풀에 넣고 싶다.
            enemyObjectPool[i] = enemy;
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
            // 3. 에너미풀 안에 있는 에너미들 중에서
            for (int i = 0; i < poolSize; i++) {
                // 4. 비활성화 된 에너미를
                // - 만약 에너미가 비활성화 되었다면
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false) {
                    // 에너미 위치시키기
                    enemy.transform.position = transform.position;
                    // 5. 에너미를 활성화하고 싶다.
                    enemy.SetActive(true);

                    // 랜덤으로 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);
                    // 에너미를 위치시키기
                    enemy.transform.position = spawnPoints[index].position;

                    // 에너미를 활성화 하였기 때문에 검색 중단
                    break;
                }
            }

            // 적을 생성한 후 적의 생성 시간을 다시 설정하고 싶다.
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
