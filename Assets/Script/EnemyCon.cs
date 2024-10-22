using UnityEngine;

public class EnemyCon : MonoBehaviour
{

    // �v���C���[�I�u�W�F�N�g���擾
    [SerializeField] GameObject playerObj;

    // �G�l�~�[�̒Ǐ]�X�s�[�h
    [SerializeField] float speed = 2.0f;

    // Rigidbody2D�ւ̎Q��
    private Rigidbody2D rb;

    private void Start()
    {
        // �v���C���[�I�u�W�F�N�g��T��
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }

        // Rigidbody2D���擾
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �v���C���[�̈ʒu���擾
        Vector2 playerPosition = playerObj.transform.position;

        // ���݂̃G�l�~�[�̈ʒu
        Vector2 enemyPosition = rb.position;

        // �v���C���[�ƃG�l�~�[�̈ʒu�̍����v�Z
        Vector2 direction = playerPosition - enemyPosition;

        // �X���[�Y�ɒǏ]����悤��Lerp���g�p�i������������Ԃ���j
        Vector2 newPosition = Vector2.Lerp(enemyPosition, playerPosition, speed * Time.deltaTime);

        // Rigidbody2D���g���ăG�l�~�[�̈ʒu���X�V
        rb.MovePosition(newPosition);
    }
}
