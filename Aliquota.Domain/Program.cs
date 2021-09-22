using System;

namespace Aliquota.Domain {
    
    class ClienteIR {
        
        static void Main(string[] args){

            string resposta,resposta2;
            Double renda,ano, ir, ir2, ano_aplicacao, ano_resgate;
            Double ano_resgate2,ano_resgate3;
            //DateTime dt = DateTime.Now; tentei usar e deu erro algumas vezes ;-;
            //Console.WriteLine(dt.ToString());
        
            Console.WriteLine("Deseja fazer o resgate do seu imposto de renda ?");
            resposta=Console.ReadLine();

            if(resposta.ToLower()=="sim"){

                Console.WriteLine("Qual o ano que voce fez a aplicacao para o IR?");
                ano_aplicacao=double.Parse(Console.ReadLine());

                Console.WriteLine("Digite sua renda: ");
                renda=double.Parse(Console.ReadLine());
                
                //estrutura para a quantidade de tempo que a pessoa quer fazer o IR
                Console.WriteLine("O Resgate sera de 1 ano ou sera maior que 2 anos, se sim digite quantos anos voce quer fazer o resgate do IR?");
                ano=double.Parse(Console.ReadLine());
                if(ano==1){
                    //Calculando o IR de 1 ano
                    ano_resgate=(ano_aplicacao + 1.0);
                    ir=(renda*0.225);
                    Console.WriteLine("O resgate sera efetuado no ano de " + ano_resgate +" e o valor total a ser pago sera de " + ir +" reais \n");
                }if(ano>=2){
                    //Calculando o IR >2 anos.
                    ano_resgate=(ano_aplicacao + ano);
                    ir=(renda*0.15);
                    Console.WriteLine("O resgate sera efetuado no ano de " + ano_resgate +" e o valor total a ser pago sera de " + ir +" reais \n");
                }
                //Calculando o IR de 1 e 2 anos.
                Console.WriteLine("Deseja fazer o calculo de 1 e 2 anos?");
                resposta2=Console.ReadLine();
                if(resposta2.ToLower()=="sim"){
                    ano_resgate2=(ano_aplicacao + 1.0);
                    ano_resgate3=(ano_aplicacao + 2.0);
                    ir2=(renda*0.185);
                    Console.WriteLine("O resgate sera efetuado nos anos " + ano_resgate2 +" e "+ ano_resgate3 +", o valor total a ser pago sera de " + ir2 +" reais");
                }else{
                    Console.WriteLine("Obrigado, volte sempre!");
                }

                }else{
                Console.WriteLine("Obrigado, volte sempre!");
            }
        }
    }
}
