using UnityEngine;

public class SpawnerType4 : SpawnerBase
{
    protected override void Start()
    {
        // ����̓G�̃v���n�u��ݒ�
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType4");

        base.Start();
    }
}