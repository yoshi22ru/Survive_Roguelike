using UnityEngine;

public class SpawnerType1 : SpawnerBase
{
    protected override void Start()
    {
        // ����̓G�̃v���n�u��ݒ�
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyType1");
        base.Start();
    }
}
