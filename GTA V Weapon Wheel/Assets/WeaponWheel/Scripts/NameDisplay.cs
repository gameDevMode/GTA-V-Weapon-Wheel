using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GTAWeaponWheel.Scripts
{
    public class NameDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        
    
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            if(_text == null || WeaponSwitcher.instance == null || WeaponSwitcher.instance.CurrentWeapon == null)
                    return;

            _text.text = WeaponSwitcher.instance.CurrentWeapon.Name;

        }
    }
}

