using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mii
{
    public int eye = 0, nose = 0, mouth = 0, eyebrow = 0, glasses = 0, moustache = 0, hair = 0, beard = 0, color = 0, skin = 0, haircolor = 0, beardcolor = 0;
    public float eyesize = 67.5f, eyerot = 0, eyeposx = 50, eyeposy = 50;
    public float nosesize = 25, noseposy = 25;
    public float mouthsize = 60, mouthposy = 12.5f, mouththickness = 37.5f;
    public float eyebrowsize = 67.5f, eyebrowrot = 0, eyebrowposx = 50, eyebrowposy = 50;
    public float glassessize = 68, glassesposy = 29;
    public float moustachesize = 25, moustacheposy = 25;
    public string miiname;

    public Mii(int eye, float esize, float erot, float eposx, float eposy,
                    int nose, float nsize, float nposy,
                    int mouth, float msize, float mposy, float mthickness,
                    int eyebrow, float ebsize, float ebrot, float ebposx, float ebposy,
                    int glasses, float gsize, float gposy,
                    int moustache, float stachesize, float stacheposy,
                    int hair, int hcolor,
                    int beard, int bcolor,
                    int color, int skin, string name)
    {
        this.eye = eye;    eyesize = esize;    eyerot = erot;   eyeposx = eposx;    eyeposy = eposy;
        this.nose = nose;    nosesize = nsize;    noseposy = nposy;
        this.mouth = mouth;    mouthsize = msize;   mouthposy = mposy;  mouththickness = mthickness;
        this.eyebrow = eyebrow;    eyebrowsize = ebsize; eyebrowrot = ebrot; eyebrowposx = ebposx; eyebrowposy = ebposy;
        this.glasses = glasses; glassessize = gsize; glassesposy = gposy;
        this.moustache = moustache; moustachesize = stachesize; moustacheposy = stacheposy;
        this.hair = hair;   haircolor = hcolor;
        this.beard = beard; beardcolor = bcolor;
        this.color = color; this.skin = skin;
        miiname = name; 
    }
}
