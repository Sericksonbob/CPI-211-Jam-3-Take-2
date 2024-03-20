using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Face : MonoBehaviour
{
    public GameObject eye, nose, nosemesh, mouth, eyebrow, glasses, moustache, hair, beard;
    public SkinnedMeshRenderer[] outfit;
    public SkinnedMeshRenderer[] skin;
    public int favcolor, skincolor, haircolor, beardcolor;
    public int pickednose;
    public int pickedeyebrow;
    public int pickedmouth;
    public int pickedeye;
    public int pickedglasses;
    public int pickedmoustache;
    public int pickedhair;
    public int pickedBeard;
    public List<Eye> eyes;
    public List<Nose> noses;
    public List<Mouth> mouths;
    public List<Eyebrow> eyebrows;
    public List<Glasses> allglasses;
    public List<Moustache> moustaches;
    public List<Hair> hairs;
    public List<Beard> beards;
    public List<Material> favcolors;
    public List<Material> skincolors;
    public List<Material> haircolors;
    public List<Material> beardcolors;

    public float eyesize, eyerot, eyeposx, eyeposy;
    public float nosesize, noseposy;
    public float mouthsize, mouthposy, mouththickness;
    public float eyebrowsize, eyebrowrot, eyebrowposx, eyebrowposy;
    public float glassessize, glassesposy;
    public float moustachesize, moustacheposy;
    public string miiname;

    private void Start()
    {
        if (miiname != "")
        LoadFace(miiname);
    }
    public void UpdateFace()
    {
        nose.GetComponent<SkinnedMeshRenderer>().material = noses[pickednose].mat;
        nosemesh.GetComponent<SkinnedMeshRenderer>().sharedMesh = noses[pickednose].mesh;
        mouth.GetComponent<SkinnedMeshRenderer>().material = mouths[pickedmouth].mat;
        eye.GetComponent<SkinnedMeshRenderer>().material = eyes[pickedeye].mat;
        eyebrow.GetComponent<SkinnedMeshRenderer>().material = eyebrows[pickedeyebrow].mat;
        glasses.GetComponent<SkinnedMeshRenderer>().material = allglasses[pickedglasses].mat;    
        moustache.GetComponent<SkinnedMeshRenderer>().material = moustaches[pickedmoustache].mat;
        hair.GetComponent<SkinnedMeshRenderer>().sharedMesh = hairs[pickedhair].Hairmesh;
        hair.GetComponent<SkinnedMeshRenderer>().material = haircolors[haircolor];
        beard.GetComponent<SkinnedMeshRenderer>().sharedMesh = beards[pickedBeard].Hairmesh;
        beard.GetComponent<SkinnedMeshRenderer>().material = beardcolors[beardcolor];
        foreach (SkinnedMeshRenderer outfitpart in outfit)
        {
            outfitpart.material = favcolors[favcolor];
        }
        foreach (SkinnedMeshRenderer bodypart in skin)
        {
            bodypart.material = skincolors[skincolor];
        }
    }
    public void UpdateFace(Mii mii)
    {
        pickednose = mii.nose;
        pickedeye = mii.eye;
        pickedmouth = mii.mouth;
        pickedeyebrow = mii.eyebrow;
        pickedglasses = mii.glasses;
        pickedmoustache = mii.moustache;
        pickedhair = mii.hair;
        pickedBeard = mii.beard;
        favcolor = mii.color;
        skincolor = mii.skin;
        haircolor = mii.haircolor;
        beardcolor = mii.beardcolor;
        miiname = mii.miiname;

        eye.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.eyeposx);
        eye.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.eyeposy);
        eye.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2, mii.eyesize);
        eye.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3, mii.eyerot);

        eyebrow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,mii.eyebrowposx);
        eyebrow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.eyebrowposy);
        eyebrow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2, mii.eyebrowsize);
        eyebrow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3, mii.eyebrowrot);

        nose.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.noseposy);
        nose.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.nosesize);
        nosemesh.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.noseposy);
        nosemesh.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.nosesize);

        mouth.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.mouthposy);
        mouth.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.mouthsize);
        mouth.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2, mii.mouththickness);

        glasses.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.glassessize);
        glasses.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.glassesposy);

        moustache.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mii.moustacheposy);
        moustache.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mii.moustachesize);
        UpdateFace();
    }
    public void SaveFace()
    {
        //somehow make an instantiation of a scriptable object
        eyeposx = eye.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        eyeposy = eye.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);
        eyesize = eye.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(2);
        eyerot = eye.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(3);

        eyebrowposx = eyebrow.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        eyebrowposy = eyebrow.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);
        eyebrowsize = eyebrow.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(2);
        eyebrowrot = eyebrow.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(3);

        noseposy = nose.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        nosesize = nose.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);

        mouthposy = mouth.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        mouthsize = mouth.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);
        mouththickness = mouth.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(2);

        glassessize = glasses.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        glassesposy = glasses.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);

        moustacheposy = moustache.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        moustachesize = moustache.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(1);

        SaveSystem.SaveMii(miiname, this);
    }
    public void LoadFace(string name)
    {
        Mii newMii = SaveSystem.LoadMii(name);
        UpdateFace(newMii);
    }
}
