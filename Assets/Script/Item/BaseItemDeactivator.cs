using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemDeactivator : MonoBehaviour
{
    BaseItem _baseItem;
    [SerializeField] GameObject _walls;
    // Start is called before the first frame update
    void Start()
    {
        _baseItem = GetComponent<BaseItem>();
        if (_baseItem == null) {
            Debug.LogError("No BaseItem found!");
        } 
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (!_baseItem.HasItem()) {
            if (!_walls.activeSelf) {
                _walls.SetActive(true); 
            }
        }
        else if (_walls.activeSelf) {
            _walls.SetActive(false);
        }
        
    }
}
