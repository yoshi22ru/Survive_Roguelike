using UnityEngine;

public class SpawnerType3 : SpawnerBase
{
    protected override void Start()
    {
        // ����̓G�̃v���n�u��ݒ�
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType3");
        base.Start();
    }
}