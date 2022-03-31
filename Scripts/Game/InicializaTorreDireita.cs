using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InicializaTorreDireita : MonoBehaviour
{
    
    public int level = 3;
    public Material parMaterial;
    public Material imparMaterial;
    public Transform torreD;
    public Transform torreC;
    public Transform torreE;
    public GameObject final;
    public GameObject score;
    public GameObject anyButton;

    private GameObject[] allDiscos;
    private float firstDiscoTam = 5;
    public GameObject discPrefab;
    private Transform discoPlay;        //disco q vai alternar de torre
    private Transform discoBase;        //disco a ser comparado na torre destino

    private float discoPlayNumber;      //numero do disco para a comparacao
    private bool airDisc = false;       //Se tem disco no ar ou nao
    private bool isFinished = false;
    private bool haveDisc = false;
    //public GameObject discoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (haveDisc)
        {
            for (int j = 0; j < level-1; j++)
            {
                Destroy(allDiscos[j]);
            }
        }
        int i =0;
        
        float lastDiscoTam = firstDiscoTam + (level - 1);
        allDiscos = new GameObject[level];
        

        while (i<level)
        {
            GameObject disco = Instantiate(discPrefab) as GameObject;
            disco.transform.parent = torreD;
            disco.transform.localPosition = new Vector3(0, (i*0.10f)-0.94f, 0);
            disco.transform.localScale = new Vector3(lastDiscoTam, 0.05f, lastDiscoTam);
            disco.name = "disco " +(level-i);

            if (i%2 == 0)
            {
                disco.GetComponent<MeshRenderer>().material = parMaterial;
            }
            else {
                disco.GetComponent<MeshRenderer>().material = imparMaterial;
            }

            allDiscos[i] = disco;
            lastDiscoTam -= 1;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isFinished)
        {
            //PRESS Q
            if (Input.GetButtonDown("TorreD"))
            {
                //se tem filho pega o filho[length-1]
                if (!airDisc)
                {
                    if (torreD.childCount > 0)
                    {
                        discoPlay = torreD.GetChild(torreD.childCount - 1);
                        discoPlayNumber = discoPlay.localScale.x;
                        while (discoPlay.localPosition.y <= 2.2)
                        {
                            discoPlay.Translate(Vector3.up * Time.deltaTime * 2);
                        }
                        discoPlay.parent = this.transform;
                        airDisc = true;

                    }
                    else
                    {
                        print("Torre vazia"); //depois vai ser um UI
                        //som de pam?
                    }
                }
                else
                {
                    if (torreD.childCount > 0)
                    {
                        discoBase = torreD.GetChild(torreD.childCount - 1);
                        if (discoPlayNumber <= discoBase.localScale.x)
                        {


                            discoPlay.parent = torreD;
                            //print("play z="+ discoPlay.localPosition.y+" base z =" + discoBase.localPosition.y);
                            while (discoPlay.localPosition.z >= discoBase.localPosition.z)
                            {
                                discoPlay.Translate(Vector3.forward * Time.deltaTime * -2);
                            }
                            while (discoPlay.localPosition.y >= discoBase.localPosition.y + 0.10)
                            {
                                discoPlay.Translate(Vector3.up * Time.deltaTime * -2);
                            }
                            airDisc = false;
                        }
                        else
                        {
                            print("Torre errada Bro " + discoPlayNumber);
                            //som de pem?
                        }
                    }
                    else
                    {
                        discoPlay.parent = torreD;
                        while (discoPlay.localPosition.z >= 0)
                        {
                            discoPlay.Translate(Vector3.forward * Time.deltaTime * -5);
                        }
                        while (discoPlay.localPosition.y >= -0.94f)
                        {
                            discoPlay.Translate(Vector3.up * Time.deltaTime * -5);
                        }
                        airDisc = false;

                    }
                }
                //pros outros botoes verifica como esta a torre

                //se tudo ok animacao
            }
            //PRESS E
            if (Input.GetButtonDown("TorreE"))
            {
                if (!airDisc)
                {
                    if (torreE.childCount > 0)
                    {
                        discoPlay = torreE.GetChild(torreE.childCount - 1);
                        discoPlayNumber = discoPlay.localScale.x;
                        while (discoPlay.localPosition.y <= 2.2)
                        {
                            discoPlay.Translate(Vector3.up * Time.deltaTime * 2);
                        }
                        discoPlay.parent = this.transform;
                        airDisc = true;

                    }
                    else
                    {
                        print("Torre vazia"); //depois vai ser um UI
                        //som de pam?
                    }
                }
                else
                {
                    if (torreE.childCount > 0)
                    {
                        discoBase = torreE.GetChild(torreE.childCount - 1);
                        if (discoPlayNumber <= discoBase.localScale.x)
                        {
                            discoPlay.parent = torreE;
                            //print("play z="+ discoPlay.localPosition.y+" base z =" + discoBase.localPosition.y);
                            while (discoPlay.localPosition.z <= discoBase.localPosition.z)
                            {
                                discoPlay.Translate(Vector3.forward * Time.deltaTime * 2);
                            }
                            while (discoPlay.localPosition.y >= discoBase.localPosition.y + 0.10)
                            {
                                discoPlay.Translate(Vector3.up * Time.deltaTime * -2);
                            }
                            airDisc = false;
                        }
                        else
                        {
                            print("Torre errada Bro " + discoPlayNumber);
                            //som de pem?
                        }
                    }
                    else
                    {
                        discoPlay.parent = torreE;

                        while (discoPlay.localPosition.z <= 0)
                        {
                            discoPlay.Translate(Vector3.forward * Time.deltaTime * 2);
                        }


                        while (discoPlay.localPosition.y >= -0.94)
                        {
                            print(discoPlay.localPosition);
                            discoPlay.Translate(Vector3.up * Time.deltaTime * -2);
                        }
                        airDisc = false;

                    }
                }
                //pros outros botoes verifica como esta a torre

                //se tudo ok animacao
            }
            //PRESS W
            if (Input.GetButtonDown("TorreC"))
            {
                if (!airDisc)
                {
                    if (torreC.childCount > 0)
                    {
                        discoPlay = torreC.GetChild(torreC.childCount - 1);
                        discoPlayNumber = discoPlay.localScale.x;
                        while (discoPlay.localPosition.y <= 2.2)
                        {
                            discoPlay.Translate(Vector3.up * Time.deltaTime * 2);
                        }
                        discoPlay.parent = this.transform;
                        airDisc = true;

                    }
                    else
                    {
                        print("Torre vazia"); //depois vai ser um UI
                        //som de pam?
                    }
                }
                else
                {
                    if (torreC.childCount > 0)
                    {
                        discoBase = torreC.GetChild(torreC.childCount - 1);
                        if (discoPlayNumber <= discoBase.localScale.x)
                        {
                            discoPlay.parent = torreC;
                            //print("play z="+ discoPlay.localPosition.y+" base z =" + discoBase.localPosition.y);
                            if (discoPlay.localPosition.z < 0)
                            {
                                while (discoPlay.localPosition.z <= 0)
                                {
                                    discoPlay.Translate(Vector3.forward * Time.deltaTime * 2);
                                }
                            }
                            else
                            {
                                while (discoPlay.localPosition.z >= 0)
                                {
                                    discoPlay.Translate(Vector3.forward * Time.deltaTime * -2);
                                }
                            }
                            while (discoPlay.localPosition.y >= discoBase.localPosition.y + 0.10)
                            {
                                discoPlay.Translate(Vector3.up * Time.deltaTime * -2);
                            }
                            airDisc = false;
                        }
                        else
                        {
                            print("Torre errada Bro " + discoPlayNumber);
                            //som de pem?
                        }
                    }
                    else
                    {
                        discoPlay.parent = torreC;
                        if (discoPlay.localPosition.z < 0)
                        {
                            while (discoPlay.localPosition.z <= 0)
                            {
                                discoPlay.Translate(Vector3.forward * Time.deltaTime * 2);
                            }

                        }
                        else
                        {
                            while (discoPlay.localPosition.z >= 0)
                            {
                                discoPlay.Translate(Vector3.forward * Time.deltaTime * -2);
                            }
                        }

                        while (discoPlay.localPosition.y >= -0.94)
                        {
                            print(discoPlay.localPosition);
                            discoPlay.Translate(Vector3.up * Time.deltaTime * -2);
                        }
                        airDisc = false;

                    }
                }
                //pros outros botoes verifica como esta a torre

                //se tudo ok animacao
            }

            if (torreE.childCount == level)
            {
                final.SetActive(true);
                anyButton.SetActive(true);
                isFinished = true;
            }

        }
        else {
            if (Input.anyKeyDown) {
                final.SetActive(false);
                anyButton.SetActive(false);
                level++;
                isFinished = false;
                haveDisc = true;
                this.Start();
            }
        }
        
    }
}
