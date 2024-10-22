using System.Collections;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    // �S�̂ŊǗ�����t�F�[�Y��^�C�~���O
    public static bool isInPurchasePhase = false;
    public static int currentPhase = 1;

    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float initialSpawnTime = 5.0f;
    [SerializeField] protected float minSpawnTime = 0.5f;
     float phaseDuration = 30.0f; // �t�F�[�Y�̒���
    [SerializeField] protected float purchasePhaseDuration = 10.0f; // �w���t�F�[�Y�̒���
    [SerializeField] protected float spawnIncreaseRate = 1.1f;
    [SerializeField] protected float spawnTimeReduction = 0.1f;

    protected float currentSpawnTime;
    private float timeSinceLastSpawn = 0.0f;

    // �t�F�[�Y�Ǘ����s��
    private static float globalPhaseTime = 0.0f;

    protected virtual void Start()
    {
        currentSpawnTime = initialSpawnTime;

        // �t�F�[�Y�Ǘ�����x�����J�n
        if (currentPhase == 1)
        {
            StartCoroutine(PhaseControl());
        }
    }

    protected virtual void Update()
    {
        if (!isInPurchasePhase)
        {
            // �G�̃X�|�[���Ǘ�
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= currentSpawnTime)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0.0f;

                // �X�|�[���Ԋu�̒���
                currentSpawnTime = Mathf.Max(currentSpawnTime * spawnIncreaseRate, minSpawnTime);
            }
        }
    }

    // �G�̃X�|�[��
    protected virtual void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    // �S�X�|�i�[���ʂ̃t�F�[�Y�Ǘ�
    protected virtual IEnumerator PhaseControl()
    {
        while (true)
        {
            // �t�F�[�Y���ԊǗ�
            globalPhaseTime = 0.0f;

            Debug.Log("Phase " + currentPhase + " started.");

            while (globalPhaseTime < phaseDuration)
            {
                globalPhaseTime += Time.deltaTime;
                yield return null;
            }

            // �t�F�[�Y�I����A�w���t�F�[�Y��
            StartPurchasePhase();
            yield return new WaitForSecondsRealtime(purchasePhaseDuration);

            EndPurchasePhase();

            // �t�F�[�Y�X�V
            currentPhase++;
            currentSpawnTime = Mathf.Max(currentSpawnTime - spawnTimeReduction, minSpawnTime);
        }
    }

    // �w���t�F�[�Y���J�n
    protected void StartPurchasePhase()
    {
        isInPurchasePhase = true;
        Time.timeScale = 0; // �Q�[�����~

        Debug.Log("Purchase phase started.");
    }

    // �w���t�F�[�Y���I��
    protected void EndPurchasePhase()
    {
        isInPurchasePhase = false;
        Time.timeScale = 1; // �Q�[���ĊJ

        Debug.Log("Purchase phase finished.");
    }
}
