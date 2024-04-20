using TopDos.PlayerSpace;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TopDos.UI
{
    public class HealthBarPresenter : MonoBehaviour
    {
        private PlayerHealth _healthController;
        private Slider _healthBarView;

        [Inject]
        private void Construct(PlayerHealth health)
        {
            _healthController = health;
            _healthController.OnModifyHealth += UpdateHealthBar;
        }
        private void Awake()
        {
            _healthBarView ??= GetComponent<Slider>();
            CompareSliderHealth();
        }

        private void CompareSliderHealth()
        {
            _healthBarView.maxValue = _healthController.MaxHealth;
            _healthBarView.value = _healthController.CurrentHealth;
        }

        private void UpdateHealthBar()
        {
            _healthBarView.value = _healthController.CurrentHealth;
        }
        private void OnDisable()
        {
            _healthController.OnModifyHealth -= UpdateHealthBar;
        }
    }
}
