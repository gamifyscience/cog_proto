using UnityEngine;
using System.Collections;

public class Display7Seg : MonoBehaviour {

	public Color onColor = Color.red;
	public Color offColor = Color.black;

	public bool aFlag = false;
	public bool bFlag = false;
	public bool cFlag = false;
	public bool dFlag = false;
	public bool eFlag = false;
	public bool fFlag = false;
	public bool gFlag = false;
	public bool pFlag = false;

	private GameObject a = null;
	private GameObject b = null;
	private GameObject c = null;
	private GameObject d = null;
	private GameObject e = null;
	private GameObject f = null;
	private GameObject g = null;
	private GameObject p = null;

	void Start()
	{
		a = transform.Find("a").gameObject;
		b = transform.Find("b").gameObject;
		c = transform.Find("c").gameObject;
		d = transform.Find("d").gameObject;
		e = transform.Find("e").gameObject;
		f = transform.Find("f").gameObject;
		g = transform.Find("g").gameObject;
		p = transform.Find("p").gameObject;		
	}

	void Update()
	{
		UpdateDisplay ();
	}

	void UpdateDisplay ()
	{
		if(aFlag) a.GetComponent<Renderer>().material.color = onColor;
		else a.GetComponent<Renderer>().material.color = offColor;

		if(bFlag) b.GetComponent<Renderer>().material.color = onColor;
		else b.GetComponent<Renderer>().material.color = offColor;

		if(cFlag) c.GetComponent<Renderer>().material.color = onColor;
		else c.GetComponent<Renderer>().material.color = offColor;

		if(dFlag) d.GetComponent<Renderer>().material.color = onColor;
		else d.GetComponent<Renderer>().material.color = offColor;

		if(eFlag) e.GetComponent<Renderer>().material.color = onColor;
		else e.GetComponent<Renderer>().material.color = offColor;

		if(fFlag) f.GetComponent<Renderer>().material.color = onColor;
		else f.GetComponent<Renderer>().material.color = offColor;

		if(gFlag) g.GetComponent<Renderer>().material.color = onColor;
		else g.GetComponent<Renderer>().material.color = offColor;

		if(pFlag) p.GetComponent<Renderer>().material.color = onColor;
		else p.GetComponent<Renderer>().material.color = offColor;
	}

	public void setChar(char ch, bool pointState = false)
	{
		//39

		switch(ch)
		{
		case ' ':
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = false;
			fFlag = false;
			gFlag = false;
			break;

		case '-':
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = false;
			fFlag = false;
			gFlag = true;
			break;

		case 'a':
		case 'A':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'b':
		case 'B':
			aFlag = false;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'c':
		case 'C':
			aFlag = true;
			bFlag = false;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case 'd':
		case 'D':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case 'e':
		case 'E':
			aFlag = true;
			bFlag = false;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'f':
		case 'F':
			aFlag = true;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'g':
		case 'G':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case 'h':
		case 'H':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'i':
		case 'I':
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case 'j':
		case 'J':			
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = false;
			break;

		case 'k':
		case 'K':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'l':
		case 'L':
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case 'm':
		case 'M':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case 'n':
		case 'N':
			aFlag = false;
			bFlag = false;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case 'o':
		case 'O':		
			aFlag = false;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case 'p':
		case 'P':		
			aFlag = true;
			bFlag = true;
			cFlag = false;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'q':
		case 'Q':		
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case 'r':
		case 'R':		
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case 's':
		case 'S':
			aFlag = true;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case 't':
		case 'T':
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'u':
		case 'U':			
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case 'v':
		case 'V':		
			aFlag = false;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = false;
			break;

		case 'w':
		case 'W':		
			aFlag = false;
			bFlag = true;
			cFlag = false;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = false;
			break;

		case 'x':
		case 'X':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case 'y':
		case 'Y':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case 'z':
		case 'Z':		
			aFlag = true;
			bFlag = true;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case '0':			
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = false;
			break;

		case '1':			
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = false;
			fFlag = false;
			gFlag = false;
			break;

		case '2':		
			aFlag = true;
			bFlag = true;
			cFlag = false;
			dFlag = true;
			eFlag = true;
			fFlag = false;
			gFlag = true;
			break;

		case '3':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = false;
			gFlag = true;
			break;

		case '4':
			aFlag = false;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case '5':
			aFlag = true;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		case '6':
			aFlag = true;
			bFlag = false;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case '7':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = false;
			eFlag = false;
			fFlag = false;
			gFlag = false;
			break;

		case '8':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = true;
			fFlag = true;
			gFlag = true;
			break;

		case '9':
			aFlag = true;
			bFlag = true;
			cFlag = true;
			dFlag = true;
			eFlag = false;
			fFlag = true;
			gFlag = true;
			break;

		default:
			aFlag = false;
			bFlag = false;
			cFlag = false;
			dFlag = false;
			eFlag = false;
			fFlag = false;
			gFlag = false;
			break;
		}

		pFlag = pointState;

		UpdateDisplay ();
	}

}
