﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BagView : View
{
    public Text MoneyText;
    public Transform UnEquipmentRoot;
    public Transform EquipmentRoot;
    public Text TipText;
    public GameObject SelectGameObject = null;
    List<Item> itemlist = new List<Item>();
     List<Item> Equipmentitemlist = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }
    public override void OnCloseClick()
    {

        base.OnCloseClick();
        UIManager._instance.GetView<TeachView>().NextEquipTeach();
    }
    public new void OnOpenClick()
    {
        base.OnOpenClick();
 
        UIManager._instance.GetView<TeachView>().NextEquipTeach();
    }
    public void Equip()
    {
        if(SelectGameObject!=null)
        {
            Equipmentitemlist.Add(SelectGameObject.GetComponent<ItemUI>().item);
            SelectGameObject.GetComponent<ItemUI>().Equip();
            UIManager._instance.GetView<TeachView>().NextEquipTeach();
        }
    }
   
    public void SetItemTip(Item item)
    {
        TipText.DOKill();
        TipText.text = "";
        TipText.DOText("<color=#FF0000>" + item.name + "</color>" + ":" + item.des, 0.5f).SetEase(Ease.Linear);
    }
    
    private void OnEnable()
    {
        InitBag();
    }
    public void InitBag()
    {
        foreach (var item in PlayerInfoController._instance.pi.BagItemDic)
        {
 
            Item _item= ConfigManager.item_config.items.Find((a) => { return a.ID == item; });

            if (itemlist.Contains(_item))
                continue;

            if(_item!=null)
            {
                itemlist.Add(_item);
                GameObject itemui=   Instantiate(   Resources.Load<GameObject>("Prefab/ItemUI"), UnEquipmentRoot);
               
                itemui.GetComponent<ItemUI>().Init(_item);
            }
        }


        foreach (var item in PlayerInfoController._instance.pi.EquipItemDic)
        {

            Item _item = ConfigManager.item_config.items.Find((a) => { return a.ID == item; });
          
            if (Equipmentitemlist.Contains(_item))
                continue;

            if (_item != null)
            {
                Equipmentitemlist.Add(_item);
                GameObject itemui = Instantiate(Resources.Load<GameObject>("Prefab/ItemUI"), EquipmentRoot);

                itemui.GetComponent<ItemUI>().Init(_item);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        MoneyText.text = PlayerInfoController._instance.pi.Money.ToString();


    }
}
