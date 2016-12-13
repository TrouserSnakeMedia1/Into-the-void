using UnityEngine;
using System.Collections;
using System.Text;

public class NoteSystem : MonoBehaviour {

    //public GameObject AllNotes;
    public bool noteRange1 = false;
    public bool noteRange2 = false;
    public bool noteRange3 = false;
    public bool noteRange4 = false;
    public bool noteRange5 = false;
    public bool noteRange6 = false;
    public bool noteRange7 = false;
    public bool noteRange8 = false;
    public bool noteRange9 = false;
    public bool noteRange10 = false;
    public bool readTheNote = false;
    public string noteText1 = "";
    public string noteText2 = "";
    public string noteText3 = "";
    public string noteText4 = "";
    public string noteText5 = "";
    public string noteText6 = "";
    public string noteText7 = "";
    public string noteText8 = "";
    public string noteText9 = "";
    public string noteText10 = "";
    public Font font;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            readTheNote = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Note#1")
        {
            noteRange1 = true;
        }
        if (other.tag == "Note#2")
        {
            noteRange2 = true;
        }
        if (other.tag == "Note#3")
        {
            noteRange3 = true;
        }
        if (other.tag == "Note#4")
        {
            noteRange4 = true;
        }
        if (other.tag == "Note#5")
        {
            noteRange5 = true;
        }
        if (other.tag == "Note#6")
        {
            noteRange6 = true;
        }
        if (other.tag == "Note#7")
        {
            noteRange7 = true;
        }
        if (other.tag == "Note#8")
        {
            noteRange8 = true;
        }
        if (other.tag == "Note#9")
        {
            noteRange9 = true;
        }
        if (other.tag == "Note#10")
        {
            noteRange10 = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        readTheNote = false;
        if (other.tag == "Note#1")
        {
            noteRange1 = false;
        }
        if (other.tag == "Note#2")
        {
            noteRange2 = false;
        }
        if (other.tag == "Note#3")
        {
            noteRange3 = false;
        }
        if (other.tag == "Note#4")
        {
            noteRange4 = false;
        }
        if (other.tag == "Note#5")
        {
            noteRange5 = false;
        }
        if (other.tag == "Note#6")
        {
            noteRange6 = false;
        }
        if (other.tag == "Note#7")
        {
            noteRange7 = false;
        }
        if (other.tag == "Note#8")
        {
            noteRange8 = false;
        }
        if (other.tag == "Note#9")
        {
            noteRange9 = false;
        }
        if (other.tag == "Note#10")
        {
            noteRange10 = false;
        }
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle.fontSize = 20;
        myStyle.normal.textColor = Color.yellow;
        if(noteRange1 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText1, myStyle);
        }
        if (noteRange2 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText2, myStyle);
        }
        if (noteRange3 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText3, myStyle);
        }
        if (noteRange4 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText4, myStyle);
        }
        if (noteRange5 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText5, myStyle);
        }
        if (noteRange6 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText6, myStyle);
        }
        if (noteRange7 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText7, myStyle);
        }
        if (noteRange8 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText8, myStyle);
        }
        if (noteRange9 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText9, myStyle);
        }
        if (noteRange10 == true && readTheNote == true)
        {
            GUI.Label(new Rect(10, 25, 1000, 300), noteText10, myStyle);
        }
    }
    

}
