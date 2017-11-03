using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public enum Genero
{
    Masculino, Feminino
}

[System.Serializable]
public class Personagem
{
    
    public int PersonagemID;
    public string Nome;
    public string Descricao;
    public int Sexo;
    public string Classe;
    public string Raça;
    public int Nivel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
