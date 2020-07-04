using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    protected ArrayList questions;
    protected ArrayList answeredQuetions;
    protected int curIndex = 0;
    protected int score = 0; 
    protected string curSceneName;
    
    // Start is called before the first frame update
    void Start(){
        // Prerarando as questões...
        initQuestions();
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public Question getCurrentQuestion(){
        return (Question) questions[curIndex];
    }

    public void setAnsweredQuetion(Answer answer){
        score += answer.value;
        answeredQuetions[curIndex] = answer;
        curIndex++;

    }

    public bool isQuestionsFinished(){
        curSceneName = SceneManager.GetActiveScene().name;

        if(curSceneName == "Forest"){
            return curIndex == ((questions.Count/2) -1);
        } else {
            return curIndex == (questions.Count -1);
        }
    }

    public void endSceneQuiz(){
        if(curSceneName == "Forest"){
            SceneManager.LoadScene("Winter");
        } else if(curSceneName == "Winter") {
            SceneManager.LoadScene("Cave");
        }
    }

    protected void initQuestions(){
        Answer a = new Answer("a) Em suas experiências e vivências. Prefere não pedir conselhos.", 2);
        Answer b = new Answer("b) Em suas intuições e reflexões a partir de conversas com outras pessoas.", 4);
        questions[0] = new Question("01. Em sua rotina profissional, você confia mais...", a, b);

        a = new Answer("a) Que você é uma pessoa muito sensitiva.", 4);
        b = new Answer("b) Que você é uma pessoa muito calculista.", 2);
        questions[1] = new Question("02. Em um feedback positivo você gosta que te digam...", a, b);
        
        a = new Answer("a) ficar na sua, tranquilo e quieto, pois é melhor manter a concentração nos assuntos que devem ser abordados.", 2);
        b = new Answer("b) conversar com os outros participantes, pois acredita que é importante o social com os colegas.", 4);
        questions[2] = new Question("03. Quando está esperando uma uma reunião começar, você prefere...", a, b);
        
        a = new Answer("a) Faz muito barulho, porém é prestativo.", 4);
        b = new Answer("b) Calado, porém não auxilia ninguém em nenhuma tarefa.", 2);
        questions[3] = new Question("04. No ambiente de trabalho, você acha que incomoda menos quem...", a, b);
        
        a = new Answer("a) Está planejado e organizado mas não tem quem te auxilie em alguma dificuldade.", 2);
        b = new Answer("b) Pode ser não planejada, para que atue de forma espontânea e você possa decidir posições diante de novos desafios.", 4);
        questions[4] = new Question("05. Você se sente melhor quando seu trabalho...", a, b);
        
        a = new Answer("a) Perguntar aos antigos funcionários da empresa como resolveram problemas passados e procurar por novas formas para resolvê-los.", 2);
        b = new Answer("b) Seguir suas inspirações e suas próprias ideias. Acredita que conversar com os funcionários antigos é importante, porém confia mais no seu instinto para resolver o problema.", 4);
        questions[5] = new Question("06. Para resolver problemas novos, você tende a...", a, b);
        
        a = new Answer("a) não te oferecem oportunidades de participar das decisções e não ter pessoas para conversar.", 4);
        b = new Answer("b) alguém que interfere seu trabalho com opiniões e fica observando o que está fazendo no seu computador.", 2);
        questions[6] = new Question("07. Em sua rotina de trabalho, você se sente mais incomodado quando...", a, b);
        
        a = new Answer("a) Alguém prático e realista, que também não interfira no que você está fazendo.", 2);
        b = new Answer("b) Alguém com imaginação e intuição aguçadas, que vai ficar opinando quando tiver dificuldade.", 4);
        questions[7] = new Question("08. Você prefere ter que tipo de colega no trabalho?", a, b);
        
        a = new Answer("a) Receber e definir sozinho suas metas e prazos.", 2);
        b = new Answer("b) Definir com um grupo de pessoas as metas e os prazos.", 4);
        questions[8] = new Question("09. Em sua profissão você gosta de...", a, b);
        
        a = new Answer("a) Conversar com várias pessoas, porém vai embora cedo pra não correr risco de falar alguma besteira com os colegas.", 4);
        b = new Answer("b) Conversar com várias pessoas, porém vai embora tarde já que tem seu grupo de colegas mais próximas no trabalho e não quer perder a oportunidade de trocar experiências.", 2);
        questions[9] = new Question("10. Em um happy hour da empresa, você tende a...", a, b);
        
        a = new Answer("a) um bom ouvinte e reservado.", 2);
        b = new Answer("b) uma pessoa comunicativa e expansiva.", 4);
        questions[10] = new Question("11. No trabalho, você se considera...", a, b);
        
        a = new Answer("a) Um pedido comovente.", 4);
        b = new Answer("b) Uma evidência convincente.", 2);
        questions[11] = new Question("12. Você é mais seduzido por...", a, b);
        
        a = new Answer("a) Mais calado, porém está sempre resolvendo problema dos outros.", 4);
        b = new Answer("b) Atencioso com todos, porém não gosta de diminuir a prioridade de suas tarefas para auxiliar alguém que está precisando de ajuda.", 2);
        questions[12] = new Question("13. Com as pessoas do trabalho, você geralmente é...", a, b);
        
        a = new Answer("a) Trabalhar remoto.", 2);
        b = new Answer("b) Trabalhar presencialmente.", 4);
        questions[13] = new Question("14. Para você, em seu trabalho, é preferível...", a, b);
        
        a = new Answer("a) Pode compartilhar e processar informações com outras pessoas.", 4);
        b = new Answer("b) Tem tempo para compreender e processar as informações sozinho.", 2);
        questions[14] = new Question("15. Você prefere aprender e trabalhar quando...", a, b);
        
        a = new Answer("a) em um ritmo constante para completar suas tarefas.", 2);
        b = new Answer("b) em explosões de energia, com períodos de folga entre eles.", 4);
        questions[15] = new Question("16. Geralmente você trabalha bem...", a, b);
        
        a = new Answer("a) Possui poucas informações e pode utilizar suas próprias teorias para novas descobertas.", 4);
        b = new Answer("b) Possui muitas teorias, detalhes e informações factuais para se basear.", 2);
        questions[16] = new Question("17. Você acredita que decide melhor suas atitudes quando...", a, b);
        
        a = new Answer("a) Você toma partido e prefere fazer logo pra mostrar serviço.", 4);
        b = new Answer("b) Acha melhor não se meter e correr o risco de não gostarem do que você decidiu fazer.", 2);
        questions[17] = new Question("18. Imagine que uma tarefa precisa ser feita mas ninguém se ofereceu para fazer...", a, b);
        
        a = new Answer("a) Com bastante cuidado, pois pensa nos riscos envolvidos e nas oportunidades que pode estragar.", 2);
        b = new Answer("b) Impulsivamente, pois não tem mais medo de arriscar do que perder a chance de mostrar seu diferencial.", 4);
        questions[18] = new Question("19. Você tende a tomar decisões...", a, b);
        
        a = new Answer("a) Sua habilidade de se relacionar com os outros e sugerir ideias que resolvam os problemas.", 4);
        b = new Answer("b) Sua racionalidade de pensamento e planejamento de ações.", 2);
        questions[19] = new Question("20. Você diria que sua maior qualidade é...", a, b);
    }
}
