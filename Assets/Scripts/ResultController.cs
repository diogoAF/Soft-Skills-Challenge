using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour{
    public Text title;
    public Text description;

    void Awake(){
        EventManager.StartListening("result_analista_planejador", AnalistaPlanejador);
        EventManager.StartListening("result_comunicador_executor", ComunicadorExecutor);
    }

    public void AnalistaPlanejador(){
        title.text = "Analista e Planejador";
        description.text = "Tem como características ser detalhista e meticuloso. É um profissional com senso de competitividade e costuma ser corajoso ao defender seus pontos de vista. Tem facilidade para ser responsável, organizado e relaciona-se com facilidade.\n" +
            "É capaz de controlar rotinas repetitivas e processos executados diariamente. Adora mapear, analisar e aperfeiçoar fluxos de trabalho para garantir que tudo seja realizado da melhor maneira possível. Rápido para amenizar conflitos e atingir um ponto de equilíbrio. Como atenta-se ao planejamento, também é perfeccionista e cumpre os passos indicados com segurança.\n" +
            "Detesta trabalhar sob pressão, mas por outro lado, se destaca quando o assunto é o desenvolvimento de trabalhos com precisão. Gosta de ajudar as outras pessoas e, por isso, tende a trabalhar bem em equipe. Também é normal ter problemas com a ausência de decisão ou comando, pois são pouco autogerenciáveis. São bastante críticos com eles mesmos e com os outros, dificilmente entra em pânico, porque costuma planejar tudo antecipadamente. É bom para assumir lideranças de grupos que precisam atingir resultados rapidamente e de forma estratégica. Com esse tipo de profissional, jamais faltará força de vontade e disposição!";
    }

    public void ComunicadorExecutor(){
        title.text = "Comunicador e Executor";
        description.text = "No que se refere aos colegas, possui bons relacionamentos, e costuma influenciar outras pessoas rapidamente e contagiá-las com seu ponto de vista. Apesar disso, é um profissional que peca no planejamento e à análise, podendo acreditar muito em iniciativas pouco viáveis. Prefere atuar em equipe e costumam unir as pessoas ao seu redor e apaziguar o ambiente quando há conflitos.\n" + 
        "O lado negativo é a dificuldade em seguir processos, normas e cronogramas. Seu perfil é de uma pessoa otimista e positiva em relação aos resultados a serem alcançados. Seu maior estímulo no trabalho é poder participar das criações e auxiliar seus colegas com grande poder de persuasão e carisma. Gosta de obstáculos e dificuldades, porque seu senso de competitividade é elevado.\n" + 
        "Defende sempre seus pontos de vista, realiza o que é necessário a todo custo. Para isso, também demonstra elevada autoconfiança, além de ser objetivo, determinado e focado em resultados. Para conseguir fazer o que deseja, precisa de certa liberdade de ação.";
    }
}
