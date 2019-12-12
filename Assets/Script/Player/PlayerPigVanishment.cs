using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPigVanishment : MonoBehaviour
{
    PlayerGrabSystem _grabSystem;
    [SerializeField] GameObject _pig;
    // Start is called before the first frame update
    void Start()
    {
        _grabSystem = FindObjectOfType<PlayerGrabSystem>().GetComponent<PlayerGrabSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabSystem.IsGrabbing()) {
            if (!_pig.activeSelf) {
                _pig.SetActive(true);
            }
        } else if (_pig.activeSelf) {
            _pig.SetActive(false);
        }
    }
}
