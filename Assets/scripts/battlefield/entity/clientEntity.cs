using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientEntity : MonoBehaviour {

    public string att = "0";

    public string cost = "0";

    public string cardID = "0";

    public string armor = "0";

    public string frozen = "0";

    public string HP = "0";

    public string immune = "0";

    public string isAbled = "0";

    public string isDivineShield = "0";

    public string isRush = "0";

    public string isStealth = "0";

    public string isTaunt = "0";

    public string isWindfury = "0";

    public string maxHP = "0";

    public string playerID = "0";

    public string pos = "N";

    public string useSum = "0";

    public bool onUse = false;
    public bool changed = false;

    public void set_pos(object value)
    {
        string data = value.ToString();
        pos = data; changed = true;
    }
    public void set_att(object value)
    {
        string data = value.ToString();
        att = data; changed = true;
    }
    public void set_playerID(object value)
    {
        string data = value.ToString();
        playerID = data; changed = true;
    }
    public void set_armor(object value)
    {
        string data = value.ToString();
        armor = data; changed = true;
    }
    public void set_cardID(object value)
    {
        string data = value.ToString();
        cardID = data; changed = true;
    }
    public void set_cost(object value)
    {
        string data = value.ToString();
        cost = data; changed = true;
    }

    public void set_useSum(object value)
    {
        string data = value.ToString();
        useSum = data; changed = true;
    }
    public void set_frozen(object value)
    {
        string data = value.ToString();
        frozen = data; changed = true;
    }
    public void set_HP(object value)
    {
        string data = value.ToString();
        HP = data; changed = true;
    }
    public void set_immune(object value)
    {
        string data = value.ToString();
        immune = data; changed = true;
    }
    public void set_isAbled(object value)
    {
        string data = value.ToString();
        isAbled = data; changed = true;
    }
    public void set_isDivineShield(object value)
    {
        string data = value.ToString();
        isDivineShield = data; changed = true;
    }
    public void set_isRush(object value)
    {
        string data = value.ToString();
        isRush = data; changed = true;
    }
    public void set_isStealth(object value)
    {
        string data = value.ToString();
        isStealth = data; changed = true;
    }
    public void set_isTaunt(object value)
    {
        string data = value.ToString();
        isTaunt = data; changed = true;
    }
    public void set_isWindfury(object value)
    {
        string data = value.ToString();
        isWindfury = data; changed = true;
    }
    public void set_maxHP(object value)
    {
        string data = value.ToString();
        maxHP = data; changed = true;
    }
    private void OnGUI()
    {
        if (changed)
        {
            updateDisplay();
            changed = false;
        }
    }
    public virtual void updateDisplay()
    {

    }
}
