using UnityEngine;
using UnityEngine.UI;

public class HpSliderLookCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Slider _hpBar;

    private void LateUpdate()
    {
        Vector3 direction = transform.position - _mainCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void ReceiveHealthData(float updatedHP)
    {
        _hpBar.value = updatedHP;
    }
}
