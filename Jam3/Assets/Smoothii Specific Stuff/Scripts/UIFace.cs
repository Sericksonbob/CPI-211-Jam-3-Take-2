using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFace : MonoBehaviour
{
    public Image head, eye, nose, mouth, eyebrow, glasses, moustache, hair, beard;
    public Text nameText;
    Image eye2, eyebrow2;
    public int skincolor, haircolor, beardcolor;
    public int pickednose;
    public int pickedeyebrow;
    public int pickedmouth;
    public int pickedeye;
    public int pickedglasses;
    public int pickedmoustache;
    public int pickedhair;
    public int pickedBeard;
    public List<Sprite> eyes;
    public List<Sprite> noses;
    public List<Sprite> mouths;
    public List<Sprite> eyebrows;
    public List<Sprite> allglasses;
    public List<Sprite> moustaches;
    public List<Sprite> hairs;
    public List<Sprite> beards;
    public List<Material> skincolors;
    public List<Material> haircolors;
    public List<Material> beardcolors;
    Animator anim;
    int frameCounter;
    float eyesize, eyerot, eyeposx, eyeposy;
    float nosesize, noseposy;
    float mouthsize, mouthposy, mouththickness;
    float eyebrowsize, eyebrowrot, eyebrowposx, eyebrowposy;
    float glassessize, glassesposy;
    float moustachesize, moustacheposy;
    public string miiname = null;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        if (miiname != null){
            LoadFace(miiname);
        }
    }
    private void Update()
    {
        if (eye2 == null && frameCounter > 0)
        {
            eye2 = Instantiate(eye, eye.transform.parent);
            Debug.Log(eye.rectTransform.localPosition);
            eye2.rectTransform.anchoredPosition = new Vector3(0 - eye.rectTransform.anchoredPosition.x, eye.rectTransform.anchoredPosition.y, 0);
            eye2.rectTransform.localScale = new Vector3(0 - eye.rectTransform.localScale.x, eye.rectTransform.localScale.y, eye.rectTransform.localScale.z);
            eye2.rectTransform.localRotation = Quaternion.Euler(new Vector3(eye.rectTransform.localRotation.eulerAngles.x, eye.rectTransform.localRotation.eulerAngles.y, 0 - eye.rectTransform.localRotation.eulerAngles.z));
            eyebrow2 = Instantiate(eyebrow, eyebrow.transform.parent);
            Debug.Log(eyebrow.rectTransform.localRotation.eulerAngles);
            eyebrow2.rectTransform.anchoredPosition = new Vector3(0 - eyebrow.rectTransform.anchoredPosition.x, eyebrow.rectTransform.anchoredPosition.y, 0);
            eyebrow2.rectTransform.localScale = new Vector3(0 - eyebrow.rectTransform.localScale.x, eyebrow.rectTransform.localScale.y, eyebrow.rectTransform.localScale.z);
            eyebrow2.rectTransform.localRotation = Quaternion.Euler(new Vector3(eyebrow.rectTransform.localRotation.eulerAngles.x, eyebrow.rectTransform.localRotation.eulerAngles.y, 0 - eyebrow.rectTransform.localRotation.eulerAngles.z));
            Debug.Log("Duplicated Eyes");
        }
        else
        {
            frameCounter++;
        }
    }
    public void UpdateFace()
    {
        frameCounter = 0;
        if (eye2 != null)
        {
            Destroy(eye2.gameObject);
            Destroy(eyebrow2.gameObject);
        }
        nose.sprite = noses[pickednose];
        mouth.sprite = mouths[pickedmouth];
        eye.sprite = eyes[pickedeye];
        eyebrow.sprite = eyebrows[pickedeyebrow];
        glasses.sprite = allglasses[pickedglasses];
        moustache.sprite = moustaches[pickedmoustache];
        hair.sprite = hairs[pickedhair];
        hair.color = haircolors[haircolor].color;
        beard.sprite = beards[pickedBeard];
        beard.color = beardcolors[beardcolor].color;
        head.color = skincolors[skincolor].color;
        nose.color = skincolors[skincolor].color;
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
        skincolor = mii.skin;
        haircolor = mii.haircolor;
        beardcolor = mii.beardcolor;
        miiname = mii.miiname;

        anim.SetFloat("eyeposx", mii.eyeposx);
        anim.SetFloat("eyeposy", mii.eyeposy);
        anim.SetFloat("eyesize", mii.eyesize);
        anim.SetFloat("eyerot", mii.eyerot);

        anim.SetFloat("eyebrowposx", mii.eyebrowposx);
        anim.SetFloat("eyebrowposy", mii.eyebrowposy);
        anim.SetFloat("eyebrowsize", mii.eyebrowsize);
        anim.SetFloat("eyebrowrot", mii.eyebrowrot);

        anim.SetFloat("noseposy", mii.noseposy);
        anim.SetFloat("nosesize", mii.nosesize);

        anim.SetFloat("mouthposy", mii.mouthposy);
        anim.SetFloat("mouthsize", mii.mouthsize);
        anim.SetFloat("mouththickness", mii.mouththickness);

        anim.SetFloat("glassesposy", mii.glassesposy);
        anim.SetFloat("glassessize", mii.glassessize);

        anim.SetFloat("moustacheposy", mii.moustacheposy);
        anim.SetFloat("moustachesize", mii.moustachesize);
        Debug.Log("Done transforming");
        if (nameText != null)
        {
            nameText.text = miiname;
        }
        UpdateFace();
    }
    public void LoadFace(string name)
    {
        if (PartySaveSystem.LoadMii(name) != null)
        {
            Mii newMii = PartySaveSystem.LoadMii(name);
            UpdateFace(newMii);
        }
    }
}
