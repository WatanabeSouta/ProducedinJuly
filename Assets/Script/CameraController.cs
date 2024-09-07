using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // �J�������ǂ�������Ώہi�v���C���[�Ȃǁj
    public float yOffset = -2f; // �J�����̏㉺�ʒu�̒���
    public float minX; // �J�����������鍶�[�̈ʒu
    public float maxX; // �J������������E�[�̈ʒu

    // �Q�[�����n�܂�Ƃ��ɌĂ΂��
    void Start()
    {
        if (target != null)
        {
            // �J�����̏����ʒu��ݒ�
            Vector3 startPos = target.transform.position;
            startPos.z = -10; // �J�����̉��s�����Œ�
            startPos.x = Mathf.Clamp(startPos.x, minX, maxX); // �J�����̍��E�̈ʒu�𐧌�
            transform.position = startPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            Debug.LogError("Target���ݒ肳��Ă��܂���");
        }
    }

    // ���t���[�����ƂɌĂ΂��
    void Update()
    {
        if (target != null)
        {
            // �J�����̈ʒu���v���C���[�̈ʒu�ɍ��킹�čX�V
            Vector3 cameraPos = target.transform.position;
            cameraPos.z = -10; // �J�����̉��s�����Œ�
            cameraPos.x = Mathf.Clamp(cameraPos.x, minX, maxX); // ���E�̐�����K�p
            cameraPos.y += yOffset; // �㉺�̈ʒu����
            transform.position = cameraPos;
        }
    }
}
