using UnityEngine;

public class SpawnerType5 : SpawnerBase
{
    protected override void Start()
    {
        // ����̓G�̃v���n�u��ݒ�
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType5");

        base.Start();
    }
}