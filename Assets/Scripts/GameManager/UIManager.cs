using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager :SingletonMono<UIManager>
{
   private static UIManager _uiManager;
   
   	[SerializeField] private BaseUI startUI;
   
   	[SerializeField] private BaseUI[] uiList;
   
   	private BaseUI _currentUI;
   
   	private readonly Stack<BaseUI> _historyList = new Stack<BaseUI>();
   
   	public static T GetUI<T>() where T : BaseUI
   	{
   		for (int i = 0; i < _uiManager.uiList.Length; i++)
   		{
   			if (_uiManager.uiList[i] is T tView)
   			{
   				return tView;
   			}
   		}
   
   		return null;
   	}
   
   	public static void Show<T>(bool remember = true) where T : BaseUI
   	{
   		for (int i = 0; i < _uiManager.uiList.Length; i++)
   		{
   			if (_uiManager.uiList[i] is T)
   			{
   				if (_uiManager._currentUI != null)
   				{
   					if (remember)
   					{
   						_uiManager._historyList.Push(_uiManager._currentUI);
   					}
   
   					_uiManager._currentUI.Hide();
   				}
   
   				_uiManager.uiList[i].Show();
   
   				_uiManager._currentUI = _uiManager.uiList[i];
   			}
   		}
   	}
   
   	public static void Show(BaseUI UI, bool remember = true)
   	{
   		if (_uiManager._currentUI != null)
   		{
   			if (remember)
   			{
   				_uiManager._historyList.Push(_uiManager._currentUI);
   			}
   
   			_uiManager._currentUI.Hide();
   		}
   
   		UI.Show();
   
   		_uiManager._currentUI = UI;
   	}
   
   	public static void ShowLast()
   	{
   		if (_uiManager._historyList.Count != 0)
   		{
   			Show(_uiManager._historyList.Pop(), false);
   		}
   	}
   
   	private void Awake()
    {
	    _uiManager = this;
    } 
   
   	private void Start()
   	{
   		for (int i = 0; i < uiList.Length; i++)
   		{
	        uiList[i].Initialize();
   
   			uiList[i].Hide();
   		}
   
   		if (startUI != null)
   		{
   			Show(startUI, true);
   		}
   	}
    
}
