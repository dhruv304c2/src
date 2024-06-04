using QuickWeb.ObjectPool;
using UnityEngine;
using TMPro; 

public class ColumnText : MonoPoolableObject<ColumnText> {
    [SerializeField] private TextMeshProUGUI columnText;

    public override void OnDespawn(){
    }

    public override void OnSpawn(){
    }

    public void SetText(string text){
        columnText.text = text;
    }
}
