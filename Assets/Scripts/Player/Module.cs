using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    private Player _player;

    public IUpperParts _upperParts;
    public ILowerParts _lowerParts;

    public GameObject _upper; // Weapon
    public GameObject _lower; // Leg

    public Transform _upperPivot; // parent
    public Transform _lowerPivot; // parent

    private void Awake()
    {
        _player = GetComponent<Player>();
        if (_player == null) // �����ֱ�� ���̱� ������ �ƹ��͵� ���� ����.
            return;
    }

    // ��ü ����
    public void ChangeUpperParts<T>(T upperParts) where T : IUpperParts
    {
        _upperParts = upperParts;

        string partsName = typeof(T).Name;
        ChangeParts(_upper, _upperPivot, $"Parts/Weapon/{partsName}");
    }

    // ��ü ����
    public void ChangeLowerParts<T>(T lowerParts) where T : ILowerParts
    {
        _lowerParts = lowerParts;

        string partsName = typeof(T).Name;
        ChangeParts(_lower, _lowerPivot, $"Parts/Leg/{partsName}");
    }

    // �������
    private void ChangeParts(GameObject parts, Transform parent, string path)
    {
        Destroy(parts);

        Managers.RM.Instantiate(path, parent);
    }
}
