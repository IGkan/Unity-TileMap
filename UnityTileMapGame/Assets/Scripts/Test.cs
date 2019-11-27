using UnityEngine;

public class Test : MonoBehaviour
{
   public  TestNoMono teset = new TestNoMono ();
    public void Start()
    {
        Debug.Log(teset.Load().Life.Value);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            teset.Load().Life.Value++;
            Debug.Log(teset.Load().Life.Value);
        }
    }
    private void OnDestroy()
    {
        teset.Save();
    }

}

