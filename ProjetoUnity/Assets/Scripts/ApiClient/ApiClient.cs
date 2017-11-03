using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    private const string _baseUrl = "http://localhost:52284/API/";

    private Personagem[] personagens;

    // Use this for initialization
    void Start()
    {         
        StartCoroutine(GetItensApiAsync());
    }

    //private IEnumerator PostItemApiAsync()
    //{
    //    WWWForm form = new WWWForm();

    //    form.AddField("Nome", "ItemFromUnity");
    //    form.AddField("Descricao", "Item enviado por POST para Unity");
    //    form.AddField("DanoMaximo", "5");
    //    form.AddField("Raridade", "5");
    //    form.AddField("TipoItemID", "2");

    //    using (UnityWebRequest request = UnityWebRequest.Post(_baseUrl + "/Itens/Create", form))
    //    {
    //        yield return request.Send();

    //        if (request.isNetworkError || request.isHttpError)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Envio do item efetuado com sucesso!");
    //        }
    //    }
    //}

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(_baseUrl + "/Personagens");
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            personagens = JsonHelper.getJsonArray<Personagem>(response);

            foreach (Personagem i in personagens)
            {
                ImprimirItem(i);
            }
            CharacterInfoManager.Instance.UpdateTexts(personagens[0]);
        }

        
    }

  

    private void ImprimirItem(Personagem i)
    {
        Debug.Log("---------- Dados Objeto ----------");
        //Debug.Log("======== " + i.Nome + " ===============");        

        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Sexo: " + i.Sexo);
        Debug.Log("Classe: " + i.Classe);
        Debug.Log("Raça: " + i.Raça);
        Debug.Log("Nivel: " + i.Nivel);

    }
}
