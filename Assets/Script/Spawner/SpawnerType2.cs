using UnityEngine;

public class SpawnerType2 : SpawnerBase
{
    protected override void Start()
    {
        // ����̓G�̃v���n�u��ݒ�
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType2");
        base.Start();
    }
}