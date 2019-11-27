using QF;
using QF.Extensions;
using System;
using UniRx;
using UnityEngine;

[Serializable]
public class TestNoMono
{
    public IntReactiveProperty Life = new IntReactiveProperty(0);
    //Json  ���л�(д��)
    public  void Save()
    {
        PlayerPrefs.SetString("TestNoMono", this.ToJson());
    }
    // Json �����л�����ȡ��
    public  TestNoMono Load()
    {
        var jsonContent = PlayerPrefs.GetString("TestNoMono", string.Empty);
        if (jsonContent.IsNullOrEmpty())
        {
           return new TestNoMono();
        }
        else
        {
            Debug.Log(jsonContent.FromJson<TestNoMono>().Life.ToString());
            return jsonContent.FromJson<TestNoMono>(); 
        }
    }
}
