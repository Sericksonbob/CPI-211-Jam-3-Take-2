using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartyFace : MonoBehaviour
{
    public GameObject eye, nose, nosemesh, mouth, eyebrow, glasses, moustache, hair, beard;
    public SkinnedMeshRenderer[] skin;
    public int skincolor, haircolor, beardcolor;
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
    public List<Material> skincolors;
    public List<Material> haircolors;
    public List<Material> beardcolors;
    public bool sad = false;

    public float eyesize, eyerot, eyeposx, eyeposy;
    public float nosesize, noseposy;
    public float mouthsize, mouthposy, mouththickness;
    public float eyebrowsize, eyebrowrot, eyebrowposx, eyebrowposy;
    public float glassessize, glassesposy;
    public float moustachesize, moustacheposy;
    public string miiname;

    private void Awake()
    {
        UpdateFace();
    }
    public void UpdateFace()
    {
        Debug.Log("Updating " + gameObject.name + "'s face.");
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
        foreach (SkinnedMeshRenderer bodypart in skin)
        {
            bodypart.material = skincolors[skincolor];
        }
    }
    public void UpdateFace(Mii mii)
    {
        Debug.Log("Updating " + gameObject.name + "'s face from Mii.");
        pickednose = mii.nose;
        pickedeye = mii.eye;
        pickedmouth = mii.mouth;
        pickedeyebrow = mii.eyebrow;
        pickedglasses = mii.glasses;
        pickedmoustache = mii.moustache;
        pickedhair = mii.hair;
        pickedBeard = mii.beard;
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
    public void LoadFace(string name)
    {
        Debug.Log("Loading " + name + "'s face");
        Mii newMii = PartySaveSystem.LoadMii(name);
        UpdateFace(newMii);
    }

    public IEnumerator SadFace()
    {
        sad = true;
        Debug.Log("WAH");
        mouth.GetComponent<SkinnedMeshRenderer>().material = mouths[19].mat;
        eye.GetComponent<SkinnedMeshRenderer>().material = eyes[6].mat;
        yield return new WaitForSeconds(2f);
        UpdateFace();
        sad = false;
    }
}
