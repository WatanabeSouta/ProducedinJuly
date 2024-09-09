using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening; // DOTween ���g�����߂̖��O���
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f; // �v���C���[�̍ő�HP
    private float currentHealth;   // ���݂�HP
    public string gameOverScene;   // �Q�[���I�[�o�[���Ɉړ�����V�[����
    public Color hitColor = Color.red; // �Փˎ��̐F�i�ԁj
    public float hitColorDuration = 0.1f; // �Փˎ��̐F�ύX�̎��ԁi0.1�b�j

    public Slider healthSlider;    // HP�o�[��UI�X���C�_�[
    private SpriteRenderer spriteRenderer; // �v���C���[�̃X�v���C�g�̐F��ύX���邽�߂̃R���|�[�l���g

    void Start()
    {
        // �Q�[���J�n����HP���ő�ɐݒ�
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>(); // �X�v���C�g�̃R���|�[�l���g���擾

        // �X�v���C�g��������Ȃ��ꍇ�̓G���[���b�Z�[�W��\��
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the player object.");
        }

        // HP�o�[�̏����ݒ�
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // �X���C�_�[�̍ő�l��ݒ�
            healthSlider.value = currentHealth; // �X���C�_�[�̌��ݒl��ݒ�
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[�������X�^�[�ɏՓ˂����Ƃ�
        if (collision.gameObject.CompareTag("Monster"))
        {
            StartCoroutine(FlashRed()); // �v���C���[��Ԃ��t���b�V��������
        }
    }

    // �v���C���[���_���[�W���󂯂��Ƃ��̏���
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // �_���[�W��HP�������
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // HP���͈͊O�ɂȂ�Ȃ��悤�ɐ���

        // HP�o�[�̃A�j���[�V������ݒ�
        if (healthSlider != null)
        {
            healthSlider.DOKill(); // �����̃A�j���[�V�������L�����Z��
            healthSlider.DOValue(currentHealth, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                // HP�o�[�̃A�j���[�V�������I��������Ɏ��S����
                if (currentHealth <= 0)
                {
                    StartCoroutine(HandleGameOver()); // �Q�[���I�[�o�[�������R���[�`���Ŏ��s
                }
            });
        }
        else
        {
            // HP�o�[���Ȃ��ꍇ�͑����Ɏ��S����
            if (currentHealth <= 0)
            {
                StartCoroutine(HandleGameOver());
            }
        }
    }
    // �Q�[���I�[�o�[���̏���
    private IEnumerator HandleGameOver()
    {
        // �Q�[���̎��Ԃ��~
        Time.timeScale = 0f;

        // 1�b�ҋ@
        yield return new WaitForSecondsRealtime(0.1f);

        // �V�[���J�ڂ̏��������s
        ChangeScene();

        // �Q�[���̎��Ԃ����ɖ߂��i�V�[���J�ڌ�ɃQ�[�����ĊJ�����悤�Ɂj
        Time.timeScale = 1f;
    }


    // �V�[����ύX���鏈��
    void ChangeScene()
    {
        SceneManager.LoadScene(gameOverScene); // �w�肳�ꂽ�V�[���Ɉړ�����
    }

    // �v���C���[��Ԃ��t���b�V�������鏈��
    private IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            Color originalColor = spriteRenderer.color; // ���̐F��ۑ�
            spriteRenderer.color = hitColor; // �v���C���[��Ԃ�����
            yield return new WaitForSeconds(hitColorDuration); // �w�肳�ꂽ���ԑҋ@
            spriteRenderer.color = originalColor; // �F�����ɖ߂�
        }
    }
}
