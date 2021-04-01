using System;
using System.Collections.Generic;

namespace Banco
{
    public class Conta
    {   
        private TipoConta tipoConta {get; set;} 
        private string nome {get; set;}
        private double saldo {get; set;}
        private double credito {get; set;}
        private List<String> transacoes;

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito) 
        {
            this.tipoConta = tipoConta;
            this.nome = nome;
            this.saldo = saldo;
            this.credito = credito;
            transacoes = new List<String>();   
        }

        public bool sacar(double valorSaque) {
            if((this.saldo - valorSaque) < -this.credito){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
            salvarTransacao(1, valorSaque, null);
            return true;
        }

        public void depositar(double valorDeposito){
            this.saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
            salvarTransacao(2, valorDeposito, null);
        }

        public void transferir(double valorTransferencia, Conta contaDestino){
            if(this.sacar(valorTransferencia)){
                contaDestino.depositar(valorTransferencia);

                salvarTransacao(3, valorTransferencia, contaDestino.nome);
                contaDestino.salvarTransacao(4, valorTransferencia, nome);
            }
        }
        
        private void salvarTransacao(int tipoTransacao, double valor, string nomeConta){

            switch(tipoTransacao){

                //saque    
                case 1:
                    transacoes.Add("Foi feito um saque no valor de " + valor);
                    break;

                //deposito
                case 2:
                    transacoes.Add("Foi feito um deposito no valor de " + valor);
                    break;
                
                //transferencia feita
                case 3:
                    transacoes.Add("Foi feita uma transferencia no valor de " + valor + " para " + nomeConta);
                    break;

                //transferencia recebida
                case 4:
                    transacoes.Add("Foi recebida uma transferencia no valor de " + valor + " de " + nomeConta);
                    break;        
            }
        }

        public void exibirTransacoes(){
            for(int i = 0; i < transacoes.Count; i++){
                String transacao = transacoes[i];
                Console.WriteLine(i+1 + "- " + transacao);
            }    
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Crédito " + this.credito;
            
            return retorno;
        }
    }
}