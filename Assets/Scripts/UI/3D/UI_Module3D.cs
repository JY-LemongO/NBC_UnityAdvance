using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Module3D : UI_3D
{
    enum GameObjects
    {
        Selector,

    }

    enum Buttons
    {
        UpperParts_Btn,
        LowerParts_Btn,
        Back_Btn,

        Previous_Btn,
        Next_Btn,
    }

    enum Texts
    {
        Status_Text,
        PartsName_Text,
        Desc_Text,
    }

    private GameObject _selector;
    public LowerBase _lower;
    public UpperBase _upper;

    protected override void Init()
    {
        base.Init();

        Managers.Module.OnInitModule += InitText;
        Managers.Module.OnChangeLowerParts += UpdateLowerTexts;
        Managers.Module.OnChangeUpperParts += UpdateUpperTexts;

        BindButton(typeof(Buttons));
        BindGameObject(typeof(GameObjects));
        BindText(typeof(Texts));

        _selector = GetGameObject((int)GameObjects.Selector);
        _selector.SetActive(false);

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(BackToMenu);
        GetButton((int)Buttons.LowerParts_Btn).onClick.AddListener(OpenLowerSelector);
        GetButton((int)Buttons.UpperParts_Btn).onClick.AddListener(OpenUpperSelector);
    }

    private void BackToMenu()
    {
        _selector.SetActive(false);
        GoToUI(_cam.StateMachine.mainState);
    }

    private void OpenLowerSelector()
    {
        _selector.SetActive(true);
        GetText((int)Texts.PartsName_Text).text = _lower.lowerSO.displayName;
        GetText((int)Texts.Desc_Text).text = _lower.lowerSO.description;

        ClearEvent();
        GetButton((int)Buttons.Previous_Btn).onClick.AddListener(() => Managers.Module.ChangeLowerParts(-1));
        GetButton((int)Buttons.Next_Btn).onClick.AddListener(() => Managers.Module.ChangeLowerParts(1));
    }

    private void OpenUpperSelector()
    {
        _selector.SetActive(true);
        GetText((int)Texts.PartsName_Text).text = _upper.upperSO.displayName;
        GetText((int)Texts.Desc_Text).text = _upper.upperSO.description;

        ClearEvent();
        GetButton((int)Buttons.Previous_Btn).onClick.AddListener(() => Managers.Module.ChangeUpperParts(-1));
        GetButton((int)Buttons.Next_Btn).onClick.AddListener(() => Managers.Module.ChangeUpperParts(1));
    }

    private void ClearEvent()
    {
        GetButton((int)Buttons.Previous_Btn).onClick.RemoveAllListeners();
        GetButton((int)Buttons.Next_Btn).onClick.RemoveAllListeners();
    }

    private void UpdateLowerTexts(LowerBase lowerBase)
    {
        _lower = lowerBase;

        UpdateTexts(_lower.lowerSO);
    }

    private void UpdateUpperTexts(UpperBase upperBase)
    {
        if (_upper == upperBase)
            return;

        _upper = upperBase;

        UpdateTexts(_upper.upperSO);
    }

    private void UpdateTexts(ModuleSO so = null)
    {
        if (so != null)
        {
            GetText((int)Texts.PartsName_Text).text = so.displayName;
            GetText((int)Texts.Desc_Text).text = so.description;
        }        
        GetText((int)Texts.Status_Text).text = $"" +
            $"WEIGHT : {_lower.lowerSO.weight + _upper.upperSO.weight}\n" +
            $"ARMOR : {_lower.lowerSO.armor + _upper.upperSO.armor}";
    }

    private void InitText(LowerBase lowerBase, UpperBase upperBase)
    {
        _lower = lowerBase;
        _upper = upperBase;

        UpdateTexts();
    }
}
