using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;
using UnityEngine.UI;

public class uiTest : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform prefab;
    public  TMP_InputField  CountText;
    public RectTransform Content; 

    public void updateItems()
    {
        int modelCount =0;
        int.TryParse(CountText.text, out modelCount );
        StartCoroutine(GetItem(modelCount, results=>OnReceivedModels(results)));

    }
    void OnReceivedModels(TestItemModel[] models)
    {
        foreach(Transform child in Content)
        {
            Destroy(child.gameObject);
        }
        foreach(var model in models)
        {
            var instance= GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(Content, false);
            InitializeItemvie(instance,model);
        }
    } 

    void  InitializeItemvie(GameObject viewGameoject,TestItemModel model)
    {
        TestItemView view  = new TestItemView(viewGameoject.transform);
        view.Titletext.text=model.Title;
       // view.

    }   
     IEnumerator GetItem (int count,System.Action<TestItemModel[]> Callbak)
     {
        yield return new WaitForSeconds(1f);
        var  results= new TestItemModel[count];
        for (int i=0 ;i<count; i++)
        {
            results[i]= new TestItemModel();
            results[i].Title="Item"+i;
            results[i].BottonText="Botton"+i;
        }     
        Callbak(results);   
     } 
     public class TestItemView
    {
        public TMP_Text Titletext; 
        public DropdownSample dropdownSample;
        public TestItemView(Transform rootVeiw)
        {
            Titletext = rootVeiw.Find("Titletext").GetComponent<TMP_Text>();
            dropdownSample = rootVeiw.Find("dropdownSample").GetComponent<DropdownSample>();
        }
        
    }
    public class TestItemModel
    {
        public string Title, BottonText;
        
    }
}
