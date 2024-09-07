using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public GameObject target; // �v���C���[�ȂǒǏ]����Ώ�
    public float yOffset = -2f; // �v���C���[�̈ʒu����J�����̈ʒu�܂ł̃I�t�Z�b�g

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            // �V�[���J�n���ɃJ�������v���C���[�̈ʒu�Ɉړ�
            Vector3 startCameraPos = target.transform.position;
            startCameraPos.z = -10; // �J������z�ʒu���Œ�
            transform.position = startCameraPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            Debug.LogError("Target���ݒ肳��Ă��܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // �v���C���[�̈ʒu���擾
            Vector3 cameraPos = target.transform.position;

            // �J�����̈ʒu���v���C���[�̈ʒu��艺�ɐݒ�
            cameraPos.z = -10; // �J�����̉��s�����Œ�
            cameraPos.y += yOffset; // �v���C���[�̈ʒu����̃I�t�Z�b�g��K�p
            transform.position = cameraPos;
        }
    }
}