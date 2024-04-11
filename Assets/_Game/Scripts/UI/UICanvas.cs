using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    //Open canvas
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    //Close canvas directly
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
