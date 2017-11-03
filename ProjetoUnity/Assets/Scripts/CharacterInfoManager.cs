using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoManager : MonoBehaviour
{

    public ApiClient apiClient;

    public Text nameText;
    public Text Descricao;
    public Text Genero;
    public Text Classe;
    public Text Raça;
    public Text Nivel;


    public static CharacterInfoManager Instance = null;
    

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }
   

    public void UpdateTexts(Personagem pers)
    {
        nameText.text = "Nome: " + pers.Nome;
        Descricao.text = "Descrição: " + pers.Descricao;
        Genero.text = "Genero: " + ((pers.Sexo == 0) ? "Masculino" : "Feminino");
        Classe.text = "Classe: " + pers.Classe;
        Raça.text =  "Raça: " + pers.Raça;
        Nivel.text = "Nível: "+ pers.Nivel;

    }

}
