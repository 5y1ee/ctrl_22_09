using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� �ܺ����� �޼���� �̰����� �����մϴ�.
// ��������Ʈ�� ���Ͽ� ��� Ŭ�������� ��� �� ������ �����մϴ�.
public partial class HYJ_ScriptBridge
{
    //////////  Getter & Setter //////////

    //////////  Method          //////////

    //////////  Default Method  //////////
    public HYJ_ScriptBridge()
    {
        HYJ_Event_Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        HYJ_Static_Start();

        HYJ_Event_Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// �̱���
partial class HYJ_ScriptBridge
{
    static HYJ_ScriptBridge Static_instance;

    //////////  Getter & Setter //////////
    public static HYJ_ScriptBridge HYJ_Static_instance
    {
        get
        {
            if (Static_instance == null)
            {
                Static_instance = new HYJ_ScriptBridge();
            }
            return Static_instance;
        }
    }

    //////////  Method          //////////

    //////////  Default Method  //////////
    void HYJ_Static_Start()
    {
        Static_instance = this;
    }

}

// ��ɾ� ����
public enum HYJ_ScriptBridge_EVENT_TYPE
{
    MAP___CHEAPTER__SELECT_RESET,
    MAP___CHEAPTER__MOVE_CENTER,
    MAP___ACTIVE__ACTIVE_ON,

    //
    BASE_CAMP___ACTIVE__ACTIVE_ON,

    //
    EVENT___ACTIVE__ACTIVE_ON,

    //
    SHOP___ACTIVE__ACTIVE_ON,
    SHOP___RELIC__BUY,
    SHOP___ITEM__BUY,
    SHOP___POTION__BUY,

    //
    BATTLE___BASIC__GET_PHASE,
    BATTLE___ACTIVE__ACTIVE_ON,

    BATTLE___FIELD__GET_FIELD_X,
    BATTLE___FIELD__GET_FIELD_Y,
    BATTLE___FIELD__GET_TILE,
    BATTLE___FIELD__GET_TILE_FROM_CHARACTER,
    BATTLE___FIELD__GET_CHARACTER,
    BATTLE___FIELD__GET_TILES_COUNT,
    BATTLE___FIELD__GET_TILES_GET_COUNT,
    BATTLE___FIELD__GET_XY_FROM_CHARACTER,

    //
    PLAYER___BASIC__GOLD_PLUS,
    PLAYER___BASIC__GOLD_MINUS,
    PLAYER___BASIC__GOLD_IS_ENOUGHT,

    PLAYER___UNIT__INSERT,

    PLAYER___ITEM__INSERT,

    PLAYER___BUFF__SETTING,

    PLAYER___BUFF__GET_BUFF_FROM_COUNT,
    PLAYER___BUFF__GET_BUFF_COUNT,

    PLAYER___BUFF__GET_DEBUFF_FROM_COUNT,
    PLAYER___BUFF__GET_DEBUFF_COUNT,

    //
    DATABASE___BASIC__GET_IS_INITIALIZE,
    DATABASE___RELIC__GET_DATA_COUNT,
    DATABASE___RELIC__GET_DATA_NAME,

    //
    DATABASE___POTION__GET_DATA_FROM_NAME,

    //
    TOPBAR___GOLD__VIEW_GOLD,
    TOPBAR___BATTLE__VIEW_POWER,
    TOPBAR___BUFF__VIEW,
}

public delegate object HYJ_ScriptBridge_Event(params object[] _args);

partial class HYJ_ScriptBridge
{

    Dictionary<HYJ_ScriptBridge_EVENT_TYPE, HYJ_ScriptBridge_Event> Event_events;

    //////////  Getter & Setter //////////

    // ��ϵ� �޼��带 ������ �� ���
    public object HYJ_Event_Get(HYJ_ScriptBridge_EVENT_TYPE _type, params object[] _args)
    {
        object res = null;

        if (Event_events.ContainsKey(_type))
        {
            res = Event_events[_type].Invoke(_args);
        }

        return res;
    }

    // �޼��带 ����� �� ���
    public void HYJ_Event_Set(HYJ_ScriptBridge_EVENT_TYPE _type, HYJ_ScriptBridge_Event _event)
    {
        if(Event_events.ContainsKey(_type))
        {
            Event_events[_type] = _event;
        }
        else
        {
            Event_events.Add(_type, _event);
        }
    }

    //////////  Method          //////////

    //////////  Default Method  //////////
    void HYJ_Event_Start()
    {
        Event_events = new Dictionary<HYJ_ScriptBridge_EVENT_TYPE, HYJ_ScriptBridge_Event>();
    }

}