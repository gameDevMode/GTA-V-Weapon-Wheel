using TMPro;
using UnityEngine;

namespace GTAWeaponWheel.Scripts
{
    public class AmmoDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        public bool displayCurrentWeaponAmmo = false; // If true, then displays current weapon ammo

        [SerializeField] private Weapon m_Weapon;
    
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            if (displayCurrentWeaponAmmo)
            {
                if(_text == null || WeaponSwitcher.instance == null || WeaponSwitcher.instance.CurrentWeapon == null)
                    return;

                _text.text = WeaponSwitcher.instance.CurrentWeapon.AmmoInUse + "/" +
                             WeaponSwitcher.instance.CurrentWeapon.Ammo;
            }
            else
            {
                if(_text == null || m_Weapon == null)
                    return;

                _text.text = m_Weapon.AmmoInUse + "/" +
                             m_Weapon.Ammo;
            }
        }
    }
}
